using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class PictureLink : PublishedElementModel
    {
        public Image Image { get; set; }
        public Umbraco.Web.Models.Link Link { get; set; }

        public string Text => this.Value<string>(DocumentTypes.PictureLink.Fields.Text);
        public PictureLink(IPublishedElement content) : base(content)
        {

            Link = content.Value<Umbraco.Web.Models.Link>(DocumentTypes.PictureLink.Fields.Link);

        }
    }
}
