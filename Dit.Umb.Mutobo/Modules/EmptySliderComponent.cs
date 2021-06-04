using System.Collections.Generic;
using Dit.Umb.Mutobo.Enum;
using Dit.Umb.Mutobo.Interfaces;

namespace Dit.Umb.Mutobo.Modules
{
    public class EmptySliderComponent : ISliderComponent
    {
        public IEnumerable<ISliderItem> Slides { get; set; }
        public int? Height { get; set; }
        public int? Interval { get; set; }
        public int? Width { get; set; }
        public EGalleryType GalleryType { get; set; }


        public string GetPictureNameSpace()
        {
            var result = "carousel-picture-";


            if (GalleryType == EGalleryType.Boxed)
                result = "picture-";
   

            return result;
        }


        public EmptySliderComponent()
        {
            
        }
    }
}
