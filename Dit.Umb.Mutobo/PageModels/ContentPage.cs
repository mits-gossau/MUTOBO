using System.Collections.Generic;
using Dit.Umb.Mutobo.Modules;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.PageModels
{
    public class ContentPage : ArticlePage
    {
        public IEnumerable<MutoboContentModule> Modules { get; set; }

        public ContentPage(IPublishedContent content) : base(content)
        {
        }
    }
}
