using System.Collections.Generic;
using System.Linq;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Services
{
    public class PictureLinkService : BaseService, IPictureLinkService
    {
        private readonly IImageService _imageService;


        public PictureLinkService(IImageService imageService)
        {
            _imageService = imageService;
        }



        public IEnumerable<PictureLink> GetPictureLinks(IEnumerable<IPublishedElement> elements)
        {
            return elements.Select(e => new PictureLink(e)
            {
                Image = e.HasValue(DocumentTypes.PictureLink.Fields.Image) ? 
                    _imageService.GetImage(e.Value<IPublishedContent>(DocumentTypes.PictureLink.Fields.Image)) 
                    : null
            });
        }
    }
}
