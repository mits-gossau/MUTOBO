using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Models.Modules
{
    public class DocumentComponent : MutoboContentModule
    {



        public DocumentComponent(IPublishedElement content) : base(content)
        {
        }
    }
}
