using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Services.Impl
{
    public class VideoService : IVideoService
    {
        public Video GetVideo(IPublishedContent node, int? width = null, int? height = null, bool showControls = true)
        {
            return new Video()
            {
                Width = width,
                Height = height,
                ShowControls = showControls,
                Source = node.MediaUrl()
            };
        }
    }
}
