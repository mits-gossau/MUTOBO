using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Enum;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.Modules
{

    /// <summary>
    /// class for a flying teaser could be inhered from Teaser?
    /// </summary>
    public class Flyer : MutoboContentModule
    {
        public string Title => this.Value<string>(DocumentTypes.Flyer.Fields.FlyerTitle);

        // Attributes for Frontend
        public string Color => this.Value<string>(DocumentTypes.Flyer.Fields.Color);

        public EDirection Direction => this.HasValue(DocumentTypes.Flyer.Fields.Direction) ?
            (EDirection) System.Enum.Parse(typeof(EDirection), this.Value<string>(DocumentTypes.Flyer.Fields.Direction)) :
            (EDirection)System.Enum.Parse(typeof(EDirection), "Undefined");

        public int Timer => this.Value<int>(DocumentTypes.Flyer.Fields.Timer);

        public EPosition Position =>
            (EPosition) System.Enum.Parse(typeof(EPosition), this.Value<string>(DocumentTypes.Flyer.Fields.Position));

        public int Height => this.Value<int>(DocumentTypes.Flyer.Fields.Height);
        public int Width => this.Value<int>(DocumentTypes.Flyer.Fields.Width);
        public int Rotation => this.Value<int>(DocumentTypes.Flyer.Fields.Rotation);
        public int MarginTop => this.Value<int>(DocumentTypes.Flyer.Fields.MarginTop);
        public int MarginSide => this.Value<int>(DocumentTypes.Flyer.Fields.MarginSide);
        public int? TextHeight => this.Value<int?>(DocumentTypes.Flyer.Fields.TextHeight);
        public int? TextWidth => this.Value<int?>(DocumentTypes.Flyer.Fields.TextWidth);



        public Image Image { get; set; }
        public string TeaserText { get; set; }
        public Umbraco.Web.Models.Link Link { get; set; }

        public Flyer(IPublishedElement content) : base(content)
        {
        }
    }
}
