using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PageModels
{
    public class TeaserPage : ArticlePage
    {

        public IEnumerable<ArticlePage> Teasers { get; set; }

        public TeaserPage(IPublishedContent content) : base(content)
        {


        }
    }
}
