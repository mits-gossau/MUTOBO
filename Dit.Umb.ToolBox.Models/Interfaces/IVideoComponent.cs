using System;
using System.Web;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Models.Interfaces
{
    public interface IVideoComponent
    {
        Video Video { get;  }
        String Embedded { get; }
        String Text { get; }
        int? Width { get; }
        int? Height { get; }
        IHtmlString RenderIFrame(int? width = null, int? height = null);
    }
}