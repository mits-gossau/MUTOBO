using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web.UI.WebControls;
using Dit.Umb.ToolBox.Models.PageModels;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.MKulturProzent.Classics.Models.Pages
{
    public class ContentPage : ArticlePage
    {
        public IEnumerable<MutoboContentModule> Modules { get; set; }

        public ContentPage(IPublishedContent content) : base(content)
        {
        }
    }
}
