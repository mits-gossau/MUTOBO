using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PageModels
{
    public class ArticlePage : BasePage
    {

        public string Abstract => Content.Value<string>(DocumentTypes.ArticlePage.Fields.Abstract);
        public string MainContent => Content.Value<string>(DocumentTypes.ArticlePage.Fields.MainContent);
        public IEnumerable<Image> EmotionImages  { get; set; }
        public int? Height => Content.Value<int>(DocumentTypes.ArticlePage.Fields.TeaserImageHeight);
        public int? Width => Content.Value<int>(DocumentTypes.ArticlePage.Fields.TeaserImageWidth);


        public ArticlePage(IPublishedContent content) : base(content)
        {

        }


    }
}
