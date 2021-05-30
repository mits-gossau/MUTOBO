using System.Text;
using System.Web;
using Dit.Umb.ToolBox.Models.Enum;

namespace Dit.Umb.ToolBox.Models.Interfaces
{
    public interface ITheme
    {
        EPageTheme PageTheme { get;  }
        string BackgroundColor { get; }
        string ColorHover { get; }
        string ColorSecondary { get; }
        string Color { get; }
        string FooterBackgroundColor { get; }
        string FooterColorHover { get; }
        string FooterColor { get; }
        string HeaderBackgroundColor { get; }
        string HeaderColor { get; }
        string NavigationBackgroundColor { get; }
        string NavigationColorHover { get; }
        string NavigationColor { get; }
        string NavigationHrColor { get; }
        string HrColor { get; }
        HtmlString GetDynamicCssProperties();
    }
}