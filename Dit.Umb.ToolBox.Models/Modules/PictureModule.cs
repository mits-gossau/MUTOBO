using Dit.Umb.ToolBox.Models.Constants;
using Dit.Umb.ToolBox.Models.PoCo;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Models.Modules
{
    public class PictureModule : MutoboContentModule
    {

        public Image Image { get; set; }

        public int? Height => this.HasValue(DocumentTypes.PictureModule.Fields.Height)
            ? this.Value<int?>(DocumentTypes.PictureModule.Fields.Height)
            : null;


        public int? Width => this.HasValue(DocumentTypes.PictureModule.Fields.Width)
            ? this.Value<int?>(DocumentTypes.PictureModule.Fields.Width)
            : null;



        public PictureModule(IPublishedElement content) : base(content)
        {
        }
    }
}
