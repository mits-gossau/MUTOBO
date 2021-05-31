using System.Web;
using System.Web.Mvc;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Interfaces;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.Modules
{
    public class MutoboContentModule : PublishedElementModel, IModule
    {

        public string ModuleTitle => this.HasValue(Compositions.Module.Fields.ModuleTitle)
            ? this.Value<string>(Compositions.Module.Fields.ModuleTitle) : null;

        public bool SpacerAfterModule => this.Value<bool>(Compositions.Module.Fields.SpacerAfterModule);
        public IHtmlString RenderModule(HtmlHelper helper)
        {
            throw new System.NotImplementedException();
        }

        public MutoboContentModule(IPublishedElement content) : base(content)
        {
        }
    }
}
