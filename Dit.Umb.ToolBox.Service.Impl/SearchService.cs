using System;
using System.Collections.Generic;
using Dit.Umb.ToolBox.Common.Exceptions;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PageModels;
using Examine;
using Examine.Search;
using Serilog.Core;
using Umbraco.Examine;
using Umbraco.Core;
using Umbraco.Web;
using SearchResult = Dit.Umb.ToolBox.Models.PoCo.SearchResult;
using Dit.Umb.ToolBox.Models.PoCo;
using System.Linq;
using UmbracoExamine.PDF;
using Examine.Providers;
using Umbraco.Core.Services.Implement;
using Umbraco.Core.Models;
using Dit.Umb.ToolBox.Common.Extensions;
using Umbraco.Core.Composing;
using Umbraco.Core.Models.PublishedContent;
using DictionaryKeys = Dit.Umb.ToolBox.Models.Constants.DictionaryKeys;
using DocumentTypes = Dit.Umb.ToolBox.Models.Constants.DocumentTypes;


namespace Dit.Umb.ToolBox.Services.Impl
{
    public class SearchService : BaseService, ISearchService
    {

        private readonly IPageLayoutService _pageLayoutService;


        public SearchService(IPageLayoutService pageLayoutService)
        {
            _pageLayoutService = pageLayoutService;
        }



        public Dit.Umb.ToolBox.Models.PageModels.SearchResultModel PerformSearch(string term)
        {

            Dit.Umb.ToolBox.Models.PageModels.SearchResultModel result = null;
            try
            {
                // create the result object and assign the search term 
                result = new Dit.Umb.ToolBox.Models.PageModels.SearchResultModel (Helper.AssignedContentItem)
                {
                    HeaderConfiguration = _pageLayoutService.GetHeaderConfiguration(Helper.AssignedContentItem),
                    FooterConfiguration = _pageLayoutService.GetFooterConfiguration(Helper.AssignedContentItem),
                    Term = term
                };
            }
            catch (AppSettingsException e)
            {
                _logger.Error(this.GetType(), e, $"{AppConstants.LoggingPrefix} {e.Message}");
                throw e;
            }

            var pages = new List<SearchResult>();
            //if (ExamineManager.Instance.TryGetIndex("ExternalIndex", out var index))

            if (ExamineManager.Instance.TryGetSearcher("MultiSearcher", out var index))
            {
                var currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture.Name.ToString().ToLower();
                var searchTerm = Common.Extensions.HtmlHelperExtensions.SearchFriendlyString(term);
                var diffFields = new[] { "nodeName", "__NodeTypeAlias", "fileTextContent", "abstract_" + currentCulture, "abstract", "mainContent", "city", "cities", "cityName", "location", "pageTitle", "modules", "orchestra", "artists", "shortDescription_" + currentCulture, "programAccordeon_" + currentCulture };
                var tmpResults = index.CreateQuery(null, BooleanOperation.And)
                    //.ParentId(1207)
                    .GroupedOr(diffFields, searchTerm)
                    .Execute();

                var results = tmpResults.Distinct();


                foreach (var res in results)
                {

                    var mediaNode = Helper.Media(res.Id);
                    var node = Helper.Content(res.Id);

                    if (mediaNode != null)
                    {

                        if (mediaNode.ItemType == PublishedItemType.Media)
                        {
                            var linkedPages = GetLinkedPages(mediaNode).ToList();

                            var documentSearchResult = new Document()
                            {
                                Url = mediaNode.MediaUrl(),
                                Name = $"{Umbraco.Web.Composing.Current.UmbracoHelper.GetDictionaryValue(DictionaryKeys.Global.Download)} => {mediaNode.Name}" 
                            };


                            SearchResult existingPage = pages?.FirstOrDefault();

                            foreach (var page in linkedPages)
                            {
                                existingPage = pages.FirstOrDefault(p => p.Id == page.Id);

                                if (existingPage == null)
                                {
                                    existingPage =
                                        new SearchResult()
                                        {
                                            Id = page.Id,
                                            Url = page.Url(),
                                            Abstract =
                                                page.HasProperty(Dit.Umb.ToolBox.Models.Constants
                                                    .DocumentTypes.ArticlePage.Fields.Abstract)
                                                    ? page.Value<string>(Dit.Umb.ToolBox.Models.Constants
                                                        .DocumentTypes.ArticlePage.Fields.Abstract)
                                                    : string.Empty,
                                            Title = page.HasProperty(Dit.Umb.ToolBox.Models.Constants.DocumentTypes.BasePage.Fields.PageTitle) ? page.Value<string>(Models.Constants.DocumentTypes.BasePage.Fields.PageTitle) : string.Empty,
                                            UrlTitle = Umbraco.Web.Composing.Current.UmbracoHelper.GetDictionaryValue(DictionaryKeys.Global.ReadMore),
                                            Documents = new List<Document>(){documentSearchResult}
                                        };

                                    pages.Add(existingPage);
                                }
                                else
                                {
                                    existingPage.Documents.Add(documentSearchResult);
                                }

                            }

                        }

                    }
                    else
                    {



                        if (!node.Value<bool>(DocumentTypes.BasePage.Fields.ExcludeFromSearch))
                        {
                            SearchResult existingPage = pages?.FirstOrDefault();
                            existingPage = pages.FirstOrDefault(p => p.Id == node.Id);

                            if (existingPage == null)
                            {
                                pages.Add(new SearchResult()
                                {
                                    Id = node.Id,
                                    Url = node.Url(),
                                    Abstract = node.HasProperty(Dit.Umb.ToolBox.Models.Constants.DocumentTypes.ArticlePage.Fields.Abstract) ? node.Value<string>(Dit.Umb.ToolBox.Models.Constants.DocumentTypes.ArticlePage.Fields.Abstract) : string.Empty,
                                    Title = node.HasProperty(Dit.Umb.ToolBox.Models.Constants.DocumentTypes.BasePage.Fields.PageTitle) ? node.Value<string>(Models.Constants.DocumentTypes.BasePage.Fields.PageTitle) : string.Empty,
                                    UrlTitle = Umbraco.Web.Composing.Current.UmbracoHelper.GetDictionaryValue(DictionaryKeys.Global.ReadMore),

                                });
                            }

                        }
                    }
                }

                result.Results = pages.Distinct();
                return result;
            }

            throw new SearchException("ExternalIndex is not present");
        }





        public IEnumerable<IPublishedContent> GetLinkedPages(IPublishedContent media)
        {
            var result = new List<IPublishedContent>();

            var homepage = Helper
                .ContentAtRoot()
                .FirstOrDefault(p => p.ContentType.Alias == DocumentTypes.HomePage.Alias);

            foreach (var page in homepage.DescendantsOrSelf())
            {

                foreach (var prop in page.Properties)
                {
                    if (prop.GetValue() is IPublishedContent content)
                    {
                        if (content.Id == media.Id)
                            result.Add(page);
                    }
                    else if (prop.GetValue() is IPublishedElement element)
                    {
                        if (IsLinkedElementType(element, media.Id))
                        {
                            result.Add(page);
                        }
                    }
                    else if (prop.GetValue() is IEnumerable<IPublishedElement> elementList)
                    {
                        foreach (var el in elementList)
                        {
                            if (IsLinkedElementType(el, media.Id))
                            {
                                result.Add(page);
                            }
                        }
                    }
                }

            }

            return result;
        }


        private bool IsLinkedElementType(IPublishedElement element, int mediaId)
        {
            var result = false;

            foreach (var prop in element.Properties)
            {
                // TODO fix this
                if (prop.GetValue() is IPublishedContent content)
                {
                    result = content.Id == mediaId;
                }
                else if (prop.GetValue() is IPublishedElement childElement)
                {
                    result |= IsLinkedElementType(childElement, mediaId);
                }
                else if (prop.GetValue() is IEnumerable<IPublishedElement> elementList)
                {
                    foreach (var el in elementList)
                    {
                        result |= IsLinkedElementType(el, mediaId);
                    }

                }
            }

            return result;
        }







        public IEnumerable<ISearchResult> GetPageOfSearchResults(string term, int pageNumber, out long totalItemCount, string[] docTypeAliases, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Umbraco.Core.Models.PublishedContent.IPublishedContent> GetPageOfContentSearchResults(string term, int pageNumber, out long totalItemCount, string[] docTypeAliases, int pageSize = 10)
        {
            throw new NotImplementedException();
        }


    }
}
