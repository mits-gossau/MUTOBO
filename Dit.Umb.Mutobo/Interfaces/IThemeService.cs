using System.Collections.Generic;
using Dit.Umb.Mutobo.PoCo;
using Umbraco.Core.Models.PublishedContent;

namespace Dit.Umb.Mutobo.Interfaces
{
    public interface IThemeService
    {
        ITheme GetTheme(IPublishedContent content);
        IEnumerable<Font> GetFonts();
    }
}