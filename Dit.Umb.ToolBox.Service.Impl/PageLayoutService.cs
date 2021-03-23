using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using Dit.Umb.Toolbox.Common.ContentExtensions;
using Dit.Umb.ToolBox.Common.Exceptions;
using Dit.Umb.ToolBox.Common.Extensions;
using Dit.Umb.ToolBox.Models.Configuration;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Core.Services;
using Umbraco.Web;
using Umbraco.Web.Composing;

namespace Dit.Umb.ToolBox.Services.Impl
{
    public class PageLayoutService : BaseService, IPageLayoutService
    {
        private readonly INavigationService _navigationService;
        private readonly ILocalizationService _localizationService;
        private readonly IImageService _imageService;
        private readonly IPictureLinkService _pictureLinkService;


        public PageLayoutService(
            INavigationService navigationService,
            ILocalizationService localizationService,
            IImageService imageService,
            IPictureLinkService pictureLinkService)
        {
            _navigationService = navigationService;
            _localizationService = localizationService;
            _imageService = imageService;
            _pictureLinkService = pictureLinkService;
        }

        public HeaderConfiguration GetHeaderConfiguration(IPublishedContent content = null)
        {
            HeaderConfiguration headerConfig = null;
            var branch = content?.AncestorsOrSelf().ToList();
            var index = 0;


            if (branch != null)
            {
                do
                {
                    headerConfig = branch[index].HasValue(DocumentTypes.BasePage.Fields.HeaderConfiguration)
                        ? new HeaderConfiguration(branch[index].Value<IEnumerable<IPublishedElement>>(DocumentTypes.BasePage.Fields.HeaderConfiguration).FirstOrDefault()) : null;
                    index++;
                } while (index < branch.Count() && headerConfig == null);
            }







            if (headerConfig != null)
                return new HeaderConfiguration(headerConfig)
                {
                    NavigationItems = _navigationService.GetNavigation(),
                    Logo = _imageService.GetImage(headerConfig.Value<IPublishedContent>(DocumentTypes.Configuration.Logo), height: 100),
                    Languages = _localizationService.GetAllLanguages()
                            .Where(l => !Equals(l.CultureInfo, CultureInfo.CurrentCulture))
                            .Select(a => new Language()
                            {
                                Name = a.CultureInfo.NativeName.Split(' ')[0],
                                ISO = a.CultureInfo.TwoLetterISOLanguageName
                            }),
                    GlobalSlogan = GetGlobalSlogan()

                };

            return null;


        }

        public FooterConfiguration GetFooterConfiguration(IPublishedContent content = null)
        {


            FooterConfiguration footerConfig = null;
            var branch = content?.AncestorsOrSelf().ToList();
            var index = 0;


            if (branch != null)
            {
                do
                {
                    footerConfig = branch[index].HasValue(DocumentTypes.BasePage.Fields.FooterConfiguration)
                        ? new FooterConfiguration(branch[index].Value<IEnumerable<IPublishedElement>>(DocumentTypes.BasePage.Fields.FooterConfiguration).FirstOrDefault()) : null;
                    index++;
                } while (index < branch.Count() && footerConfig == null);
            }


            if (footerConfig != null)
            {
                var nodes = footerConfig.HasValue(DocumentTypes.FooterConfiguration.Fields.NavigationArea) ?
    footerConfig.Value<IEnumerable<IPublishedElement>>(DocumentTypes.FooterConfiguration.Fields.NavigationArea)
    : new List<IPublishedElement>();
                var linkBlocks = new List<FooterNavBlock>();



                foreach (var node in nodes)
                {
                    var contentNode = Current.UmbracoHelper.Content(node.Value<IPublishedContent>(DocumentTypes.FooterNavBlock.StartNode).Id);
                    linkBlocks.Add(GetFooterLinkBlock(contentNode));
                }

                var footerLinks = footerConfig.Value<IEnumerable<Umbraco.Web.Models.Link>>(DocumentTypes.FooterConfiguration.Fields.Links) ??
                                  new List<Umbraco.Web.Models.Link>();

                var contactNode = footerConfig.HasValue(DocumentTypes.FooterConfiguration.Fields.ContactArea) ?
                    footerConfig.Value<IEnumerable<IPublishedElement>>(DocumentTypes.FooterConfiguration.Fields.ContactArea)
                        .Select(e => new FooterContactArea(e))
                    : new List<FooterContactArea>();


                var langs = _localizationService.GetAllLanguages().ToList();


                return new FooterConfiguration(footerConfig)
                {
                    FooterNavBlocks = linkBlocks,
                    FooterContactBlock = contactNode,
                    Languages = _localizationService.GetAllLanguages()
                        .Where(l => !Equals(l.CultureInfo, CultureInfo.CurrentCulture))
                        .Select(a => new Language()
                        {
                            Name = a.CultureInfo.NativeName.Split(' ')[0],
                            ISO = a.CultureInfo.TwoLetterISOLanguageName
                        }),
                    PictureLinks = footerConfig.HasValue(DocumentTypes.FooterConfiguration.Fields.PictureLinks) ?
                        _pictureLinkService.GetPictureLinks(footerConfig.Value<IEnumerable<IPublishedElement>>(DocumentTypes.FooterConfiguration.Fields.PictureLinks)) :
                        new List<PictureLink>()
                };
            }


            return null;

        }

        private Slogan GetGlobalSlogan()
        {
            var homePage = Current.UmbracoHelper
                .ContentAtRoot()
                .FirstOrDefault(c => c.ContentType.Alias == DocumentTypes.HomePage.Alias);

            if (homePage == null)
                throw new Exception("No Page with the document type homePage found!");

            return new Slogan()
            {
                SubTitle = homePage.HasValue(DocumentTypes.HomePage.Fields.SloganSubTitle) ?
                    homePage.Value<string>(DocumentTypes.HomePage.Fields.SloganSubTitle) : string.Empty,
                Title = homePage.HasValue(DocumentTypes.HomePage.Fields.SloganTitle) ?
                    homePage.Value<string>(DocumentTypes.HomePage.Fields.SloganTitle) : string.Empty
            };

        }

        private FooterNavBlock GetFooterLinkBlock(IPublishedContent parentNode)
        {

            return new FooterNavBlock()
            {
                Title = new Link() { Text = parentNode.Name, Url = parentNode.Url() },
                Children = parentNode.Children.Select(c => new Link()
                {
                    Url = c.GetDitUrl(),
                    Text = c.Name,
                    Target = c.GetLinkTarget()

                })
            };
        }
    }
}

