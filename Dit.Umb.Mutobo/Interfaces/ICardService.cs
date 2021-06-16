using System.Collections.Generic;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface ICardService
    {
        IEnumerable<Card> GetCards(IPublishedElement element, string fieldName);
    }
}