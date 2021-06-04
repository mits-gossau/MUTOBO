using System.Web;
using System.Web.Mvc;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IModule
    {
        string ModuleTitle { get; }
        bool SpacerAfterModule { get; }
        IHtmlString RenderModule(HtmlHelper helper);
    }
}
