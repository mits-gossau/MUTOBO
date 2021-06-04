using System.Collections.Generic;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.PageModels
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
