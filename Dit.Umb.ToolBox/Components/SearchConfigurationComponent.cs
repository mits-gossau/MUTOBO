using System;
using System.Text;
using Dit.Umb.ToolBox.Models.Constants;
using Examine;
using Examine.Providers;
using Umbraco.Core.Composing;
using Umbraco.Examine;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Components
{
    
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

            if (_examineManager.TryGetIndex("ExternalIndex", out externalIndex))
            {

                // FieldDefinitionCollection contains all indexed fields 
                externalIndex.FieldDefinitionCollection.AddOrUpdate(new FieldDefinition("contents", FieldDefinitionTypes.FullText));
                ((BaseIndexProvider)externalIndex).TransformingIndexValues += OnTransformingIndexValues; 

            }
            else
            {
                throw new Exception("Index not found");
            }
        }

        private void OnTransformingIndexValues(object sender, IndexingItemEventArgs e)
        {
            var combinedField = new StringBuilder();

            if (e.ValueSet.Category == IndexTypes.Content && e.ValueSet.ItemType == "articlePage")
            {

                foreach (var fieldValues in e.ValueSet.Values)
                {
                    foreach (var value in fieldValues.Value)
                    {
                        if (value != null)
                        {
                            combinedField.AppendLine(value.ToString());
                        }
                    }
                }
                e.ValueSet.Add("contents", combinedField.ToString());
            }
        }

        public void Terminate()
        {
        }
    }
}