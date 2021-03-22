using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.ToolBox.Services
{
    public interface IMutoboContentService
    {
        IEnumerable<MutoboContentModule> GetContent(IPublishedContent content, string fieldName);
    }
}