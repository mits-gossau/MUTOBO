using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Enum;
using Dit.Umb.Mutobo.Interfaces;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.Modules
{
    public class SliderComponent : MutoboContentModule, ISliderComponent, IModule
    {

        public IEnumerable<ISliderItem> Slides { get; set; }

        public int? Height => this.HasValue(DocumentTypes.SliderComponent.Fields.Height) && this.Value<int?>(DocumentTypes.SliderComponent.Fields.Height) > 0
            ? this.Value<int?>(DocumentTypes.SliderComponent.Fields.Height)
            : null;
        public int? Interval =>  this.HasValue(DocumentTypes.SliderComponent.Fields.Interval)
            ? this.Value<int?>(DocumentTypes.SliderComponent.Fields.Interval)
        : null;



        public int? Width => this.HasValue(DocumentTypes.SliderComponent.Fields.Width) && this.Value<int?>(DocumentTypes.SliderComponent.Fields.Width) > 0
            ? this.Value<int?>(DocumentTypes.SliderComponent.Fields.Width)
            : null;

        public string GetPictureNameSpace()
        {
            var result = "carousel-picture-";
            EGalleryType galleryType = EGalleryType.FullWidth;

            if (this.HasValue(DocumentTypes.SliderComponent.Fields.DisplayType))
            {
                galleryType = (EGalleryType) System.Enum.Parse(typeof(EGalleryType),
                    this.Value<string>(DocumentTypes.SliderComponent.Fields.DisplayType));

                if (galleryType == EGalleryType.Boxed)
                    result = "picture-";
            }

            return result;
        }

        public override IHtmlString RenderModule(HtmlHelper helper)
        {
            var bld = new StringBuilder();
            bld.Append(helper.Partial("~/Views/Partials/Slider.cshtml", this));

            if (SpacerAfterModule)
            {
                bld.Append("<div class=\"spacer\"></div>");
            }

            return new HtmlString(bld.ToString());
        }

        public SliderComponent(IPublishedElement content) : base(content)
        {
        }
    }
}