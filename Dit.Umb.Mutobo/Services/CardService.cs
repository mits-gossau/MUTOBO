using System.Collections.Generic;
using System.Linq;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Dit.Umb.Mutobo.Services
{
    public class CardService : BaseService, ICardService
    {
        private readonly IImageService _imageService;


        public CardService(IImageService imageService)
        {
            _imageService = imageService;
        }


        public IEnumerable<Card> GetCards(IPublishedElement content, string fieldName)
        {
            if (!content.HasValue(fieldName))
                return null;

            var result = content.Value<IEnumerable<IPublishedElement>>(fieldName)
                .Where(c => c.ContentType.Alias == DocumentTypes.Card.Alias).Select((element, index) => new
                {
                    element = new Card(element)
                    {
                        SortOrder = index,
                        Image = element.HasValue(DocumentTypes.Card.Fields.Image)
                            ? _imageService.GetImage(element.Value<IPublishedContent>(DocumentTypes.Card.Fields.Image), 160,
                                160, ImageCropMode.Crop)
                            : null
                    },
                    index
                }).Select(e => e.element);

            var returnValue = result.Concat(content.Value<IEnumerable<IPublishedElement>>(fieldName)
                .Where(c => c.ContentType.Alias == DocumentTypes.PersonnelCard.Alias).Select((element, index) => new
                {
                    element = new PersonnelCard(element)
                    {
                        SortOrder = index,
                        Image = element.HasValue(DocumentTypes.Card.Fields.Image)
                            ? _imageService.GetImage(element.Value<IPublishedContent>(DocumentTypes.Card.Fields.Image),
                                160,
                                160, ImageCropMode.Min)
                            : null
                    },
                    index
                }).Select(e => e.element));


            return returnValue.OrderBy(e => e.SortOrder);
        }
    }
}
