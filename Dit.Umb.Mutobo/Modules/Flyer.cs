using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Enum;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Modules
{

    /// <summary>
    /// class for a flying teaser could be inhered from Teaser?
    /// </summary>
    public class Flyer : MutoboContentModule, IModule
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


        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();

            if (Timer > 0)
            {
                switch (Direction)
                {
                    case EDirection.Right:
                        bld.Append(helper.Partial("~/Views/Partials/Flyer_right.cshtml",
                            this));
                        break;

                    default:
                    case EDirection.Left:
                        bld.Append(helper.Partial("~/Views/Partials/Flyer_left.cshtml", this));
                        break;
                }
            }
            else
            {
                switch (Direction)
                {
                    case EDirection.Right:
                        bld.Append(helper.Partial("~/Views/Partials/IntersectionFlyer_right.cshtml",
                            this));
                        break;

                    default:
                    case EDirection.Left:
                        bld.Append(helper.Partial("~/Views/Partials/IntersectionFlyer_left.cshtml", this));
                        break;
                }

            }

            return new MvcHtmlString(bld.ToString());
        }


    }
}
