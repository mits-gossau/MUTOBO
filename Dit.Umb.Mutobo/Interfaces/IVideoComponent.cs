using System;
using System.Web;
using Dit.Umb.Mutobo.PoCo;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IVideoComponent: IModule
    {
        Video Video { get;  }
        String Embedded { get; }
        String Text { get; }
        int? Width { get; }
        int? Height { get; }
        IHtmlString RenderIFrame(int? width = null, int? height = null);


    }
}