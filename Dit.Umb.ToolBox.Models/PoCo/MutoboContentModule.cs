using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Interfaces;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class MutoboContentModule : PublishedElementModel, IModule
    {

        public string ModuleTitle => this.HasValue(Compositions.Module.Fields.ModuleTitle)
            ? this.Value<string>(Compositions.Module.Fields.ModuleTitle) : null;

        public bool SpacerAfterModule => this.Value<bool>(Compositions.Module.Fields.SpacerAfterModule);
        public MutoboContentModule(IPublishedElement content) : base(content)
        {
        }
    }
}
