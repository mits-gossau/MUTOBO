using System.Collections.Generic;

namespace Dit.Umb.Mutobo.Interfaces
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