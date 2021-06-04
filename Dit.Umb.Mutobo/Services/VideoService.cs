using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Services
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
