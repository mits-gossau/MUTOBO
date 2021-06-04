using System.Web;
using System.Web.Mvc;

namespace Dit.Umb.ToolBox.Models.Interfaces
{
    public interface IModule
    {
        string ModuleTitle { get; }
        bool SpacerAfterModule { get; }
        IHtmlString RenderModule(HtmlHelper helper);
    }
}
