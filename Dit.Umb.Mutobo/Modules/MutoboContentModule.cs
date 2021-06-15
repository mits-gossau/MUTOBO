using System.Web;
using System.Web.Mvc;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Modules
{
    public class MutoboContentModule : PublishedElementModel, IModule
    {
        public string ModuleTitle => this.HasValue(Constants.Compositions.Module.Fields.ModuleTitle)
            ? this.Value<string>(Constants.Compositions.Module.Fields.ModuleTitle) : null;
        
        public bool SpacerAfterModule => this.Value<bool>(Constants.Compositions.Module.Fields.SpacerAfterModule);
        
        public int SortOrder { get; set; }

        public virtual IHtmlString RenderModule(HtmlHelper helper)
        {
            throw new System.NotImplementedException();
        }

        public  MutoboContentModule(IPublishedElement content) : base(content)
        {
        }
    }
}
