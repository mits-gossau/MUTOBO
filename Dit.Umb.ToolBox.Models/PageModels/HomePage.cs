using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models.ContentEditing;

namespace Dit.Umb.ToolBox.Models.PageModels
{
    public class HomePage : BasePage
    {
        public string SloganTitle { get; set; }
        public string SloganSubTitle { get; set; }
        public IEnumerable<Flyer> FlyerList { get; set; }

        public IEnumerable<ArticlePage> TeaserList { get; set; }

        public HomePage(IPublishedContent content) : base(content)
        {



        }
    }
}
