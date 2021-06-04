using System.Collections.Generic;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.PageModels
{
    public class TeaserPage : ArticlePage
    {

        public IEnumerable<ArticlePage> Teasers { get; set; }

        public TeaserPage(IPublishedContent content) : base(content)
        {


        }
    }
}
