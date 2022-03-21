using System.Collections.Generic;
using Dit.Umb.Mutobo.Modules;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IMutoboSimpleContentService
    {
        IEnumerable<MutoboContentModule> GetSimpleContent(IPublishedContent content, string fieldName);
    }
}