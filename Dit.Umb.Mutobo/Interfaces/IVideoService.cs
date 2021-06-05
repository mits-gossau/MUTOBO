using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IVideoService
    {
        Video GetVideo(IPublishedContent node, int? width = null, int? height = null, bool showControls = true);
    }
}