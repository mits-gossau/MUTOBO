using Dit.Umb.Mutobo.Constants;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.PoCo
{
    public class PictureLink : PublishedElementModel
    {
        public Image Image { get; set; }
        public Umbraco.Web.Models.Link Link => this.HasValue(DocumentTypes.PictureLink.Fields.Link)
            ? this.Value<Umbraco.Web.Models.Link>(DocumentTypes.PictureLink.Fields.Link)
        : null;
        public Umbraco.Web.Models.Link LogoLink => this.HasValue(DocumentTypes.PictureLink.Fields.LogoLink)
            ? this.Value<Umbraco.Web.Models.Link>(DocumentTypes.PictureLink.Fields.LogoLink)
            : null;
        public string Text => this.HasValue(DocumentTypes.PictureLink.Fields.Text) ? this.Value<string>(DocumentTypes.PictureLink.Fields.Text)
        : string.Empty;


        public int? MaxHeight =>  this.Value<int?>(DocumentTypes.PictureLink.Fields.MaxHeight);
        public int? PaddingTop => this.Value<int?>(DocumentTypes.PictureLink.Fields.PaddingTop);
        public int? PaddingRight => this.Value<int?>(DocumentTypes.PictureLink.Fields.PaddingRight);
        public int? PaddingBottom => this.Value<int?>(DocumentTypes.PictureLink.Fields.PaddingBottom);
        public int? PaddingLeft => this.Value<int?>(DocumentTypes.PictureLink.Fields.PaddingLeft);

        public PictureLink(IPublishedElement content) : base(content)
        {


        }
    }
}
