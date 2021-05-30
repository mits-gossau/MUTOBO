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
        public bool HideAbstract => Content.Value<bool>(DocumentTypes.ArticlePage.Fields.HideAbstract);
        public string MainContent => Content.Value<string>(DocumentTypes.ArticlePage.Fields.MainContent);



        public IEnumerable<Image> EmotionImages  { get; set; }


        public ArticlePage(IPublishedContent content) : base(content)
        {

        }


    }
}
