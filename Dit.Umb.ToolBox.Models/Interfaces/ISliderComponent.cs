using System.Collections.Generic;
using Dit.Umb.ToolBox.Models.Constants;

namespace Dit.Umb.ToolBox.Models.Interfaces
{
    public interface ISliderComponent
    {
        IEnumerable<ISliderItem> Slides { get; }
        int? Height { get; }
        int? Interval { get; }
        int? Width { get; }
        string GetPictureNameSpace();
    }
}