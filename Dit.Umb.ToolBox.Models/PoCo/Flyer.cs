using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.Enum;
using Dit.Umb.ToolBox.Models.PageModels;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Models;

namespace Dit.Umb.ToolBox.Models.PoCo
{

    /// <summary>
    /// class for a flying teaser could be inhered from Teaser?
    /// </summary>
    public class Flyer : MutoboContentModule
    {
        public string Title => this.Value<string>(DocumentTypes.Flyer.Fields.FlyerTitle);

        // Attributes for Frontend
        public string Color => this.Value<string>(DocumentTypes.Flyer.Fields.Color);

        public EDirection Direction =>
            (EDirection) System.Enum.Parse(typeof(EDirection), this.Value<string>(DocumentTypes.Flyer.Fields.Direction));

        public int Timer => this.Value<int>(DocumentTypes.Flyer.Fields.Timer);

        public EPosition Position =>
            (EPosition) System.Enum.Parse(typeof(EPosition), this.Value<string>(DocumentTypes.Flyer.Fields.Position));

        public int Height => this.Value<int>(DocumentTypes.Flyer.Fields.Height);
        public int Width => this.Value<int>(DocumentTypes.Flyer.Fields.Width);
        public int Rotation => this.Value<int>(DocumentTypes.Flyer.Fields.Rotation);

        public Image Image { get; set; }
        public string TeaserText { get; set; }
        public Umbraco.Web.Models.Link Link { get; set; }

        public Flyer(IPublishedElement content) : base(content)
        {
        }
    }
}
