using System;
using System.Collections.Generic;
using System.Text;
using Dit.Umb.Mutobo.Constants;
using Examine;
using Examine.LuceneEngine.Providers;
using Examine.Providers;
using Newtonsoft.Json;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Examine;
using Umbraco.Web;
using Umbraco.Web.Composing;
using UmbracoExamine.PDF;

namespace Dit.Umb.Mutobo.Components
{
    [ComposeAfter(typeof(ExaminePdfComposer))]
    public class RegisterPDFMultiSearcherComposer : ComponentComposer<SearchConfigurationComponent>, IUserComposer
    {
    }

    public class SearchConfigurationComponent : IComponent
    {

        private readonly IExamineManager _examineManager;
        private readonly IUmbracoContextFactory _contextFactory;


        public SearchConfigurationComponent(IExamineManager examineManager, IUmbracoContextFactory contextFactory)
        {

            // inject ExamineManager
            _examineManager = examineManager;
            //
            _contextFactory = contextFactory;
        }



        public void Initialize()
        {
            IIndex externalIndex = null;
            IIndex pdfIndex = null;

            if (_examineManager.TryGetIndex("ExternalIndex", out externalIndex)
                && _examineManager.TryGetIndex(PdfIndexConstants.PdfIndexName, out pdfIndex))
            {
                // FieldDefinitionCollection contains all indexed fields 
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition("contents", FieldDefinitionTypes.FullText));
                ((BaseIndexProvider)externalIndex).TransformingIndexValues += OnTransformingIndexValues;

                //register multisearcher
                var multisearch = new MultiIndexSearcher("MultiSearcher", new IIndex[] { externalIndex, pdfIndex });
                _examineManager.AddSearcher(multisearch);

            }
            else
            {
                throw new Exception("Index not found");
            }
        }

        private void OnTransformingIndexValues(object sender, IndexingItemEventArgs e)
        {
            if (int.TryParse(e.ValueSet.Id, out var nodeId))
                switch (e.ValueSet.ItemType)
                {

                    case "contentPage":
                        using (var umbracoContext = _contextFactory.EnsureUmbracoContext())
                        {
                            IPublishedContent contentNode = umbracoContext.UmbracoContext.Content.GetById(nodeId);
                            IPublishedElement element = umbracoContext.UmbracoContext.Content.GetById(nodeId);

                            if (contentNode != null)
                            {
                                var contentRichtext = string.Empty;
                                if (element.Value<IEnumerable<IPublishedElement>>(DocumentTypes.ContentPage.Fields.Modules) != null)
                                {
                                    foreach (var item in element.Value<IEnumerable<IPublishedElement>>(DocumentTypes.ContentPage.Fields.Modules))
                                    {

                                        if (item.HasProperty("richText"))
                                        {
                                            var ncRichtext = item.GetProperty("richText").GetValue();
                                            contentRichtext += " " + ncRichtext;
                                        }
                                        
                                    }

                                    e.ValueSet.Set("modules", contentRichtext);
                                }
                                
                            }

                        }
                        break;
                }


        }

        public void Terminate()
        {
        }
    }
}