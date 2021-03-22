using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface IVideoService
    {
        Video GetVideo(IPublishedContent node, int? width = null, int? height = null, bool showControls = true);
    }
}