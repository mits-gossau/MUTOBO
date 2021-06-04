using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Interfaces;
using Dit.Umb.ToolBox.Models.Modules;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Link = Umbraco.Web.Models.Link;

namespace Dit.Umb.MKulturProzent.Classics.Models.Poco
{
    public class TextImageSlide : MutoboContentModule, ISliderItem
    {
        public Image Image { get; set; }

        public string Text => this.HasValue(DocumentTypes.TextImageSlide.Fields.Text)
            ? this.Value<string>(DocumentTypes.TextImageSlide.Fields.Text)
            : null;

        public Link Link => this.HasValue(DocumentTypes.TextImageSlide.Fields.Link)
            ? this.Value<Umbraco.Web.Models.Link>(DocumentTypes.TextImageSlide.Fields.Link)
            : null;
        public string Title => this.HasValue(DocumentTypes.TextImageSlide.Fields.Title)
            ? this.Value<string>(DocumentTypes.TextImageSlide.Fields.Title)
            : null;

        public TextImageSlide(IPublishedElement content) : base(content)
        {
        }
    }
}
