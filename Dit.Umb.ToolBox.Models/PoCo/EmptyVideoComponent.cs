using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Dit.Umb.ToolBox.Models.Interfaces;

namespace Dit.Umb.ToolBox.Models.PoCo
{
    public class EmptyVideoComponent : IVideoComponent, ISliderItem
    {
        public Video Video { get; set; }
        public string Embedded { get; set; }
        public string Text { get; set; }
        public int? Width { get; set; }
        public int? Height { get; set; }


        public IHtmlString RenderIFrame(int? width = null, int? height = null)
        {
            var newWidth = width ?? Width;
            var newHeight = height ?? Height;
            var result = Embedded;

            if (newWidth.HasValue)
            {
                result = Regex.Replace(result, "width=\"([0-9]{1,4})\"", $"width=\"{newWidth}\"", RegexOptions.IgnoreCase);
            }


            if (newHeight.HasValue)
            {
                result = Regex.Replace(result, "height=\"([0-9]{1,4})\"", $"height=\"{newHeight}\"", RegexOptions.IgnoreCase);

            }


            return new HtmlString(result);
        }
    }
}
