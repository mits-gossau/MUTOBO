using System.Text;
using System.Web;
using Dit.Umb.Mutobo.Enum;
using Dit.Umb.Mutobo.Interfaces;

namespace Dit.Umb.Mutobo.PoCo
{
    public class EmptyTheme : ITheme
    {
        public EPageTheme PageTheme { get; set; }
        public string BackgroundColor { get; set; }
        public string ColorHover { get; set; }
        public string ColorSecondary { get; set; }
        public string Color { get; set; }
        public string FooterBackgroundColor { get; set; }
        public string FooterColorHover { get; set; }
        public string FooterColor { get; set; }
        public string HeaderBackgroundColor { get; set; }
        public string HeaderColor { get; set; }
        public string NavigationBackgroundColor { get; set; }
        public string NavigationColorHover { get; set; }
        public string NavigationColor { get; set; }
        public string NavigationHrColor { get; set; }
        public string HrColor { get; set; }

        public HtmlString GetDynamicCssProperties()
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("<style>html {");

            if (!string.IsNullOrEmpty(Color))
            {
                stringBuilder.AppendLine($"--color: #{Color};");
            }

            if (!string.IsNullOrEmpty(BackgroundColor))
            {
                stringBuilder.AppendLine($"--background-color: #{BackgroundColor};");
            }

            //if (!string.IsNullOrEmpty(ColorSecondary))
            //{
            //    stringBuilder.AppendLine($"--color-secondary: #{ColorSecondary};");
            //}

            if (!string.IsNullOrEmpty(ColorHover))
            {
                stringBuilder.AppendLine($"--color-hover: #{ColorHover};");
            }

            //if (!string.IsNullOrEmpty(FooterBackgroundColor))
            //{
            //    stringBuilder.AppendLine($"--footer-background-color: #{FooterBackgroundColor};");
            //}

            //if (!string.IsNullOrEmpty(HeaderBackgroundColor))
            //{
            //    stringBuilder.AppendLine($"--header-background-color: #{HeaderBackgroundColor};");
            //}

            //if (!string.IsNullOrEmpty(FooterColorHover))
            //{
            //    stringBuilder.AppendLine($"--footer-color-hover: #{FooterColorHover};");
            //}

            //if (!string.IsNullOrEmpty(FooterColor))
            //{
            //    stringBuilder.AppendLine($"--footer-color: #{FooterColor};");
            //}

            //if (!string.IsNullOrEmpty(HeaderColor))
            //{
            //    stringBuilder.AppendLine($"--header-color: #{HeaderColor};");
            //}

            //if (!string.IsNullOrEmpty(NavigationBackgroundColor))
            //{
            //    stringBuilder.AppendLine($"--navigation-background-color: #{NavigationBackgroundColor};");
            //}

            //if (!string.IsNullOrEmpty(NavigationColor))
            //{
            //    stringBuilder.AppendLine($"--navigation-color: #{NavigationColor};");
            //}

            //if (!string.IsNullOrEmpty(NavigationColorHover))
            //{
            //    stringBuilder.AppendLine($"--navigation-color-hover: #{NavigationColorHover};");
            //}

            //if (!string.IsNullOrEmpty(NavigationHrColor))
            //{
            //    stringBuilder.AppendLine($"--navigation-color-hover: #{NavigationHrColor};");
            //}

            //if (!string.IsNullOrEmpty(HrColor))
            //{
            //    stringBuilder.AppendLine($"--hr-color: #{HrColor};");
            //}

            
            stringBuilder.AppendLine($"--playlist-item-a-text-decoration: none;");
            stringBuilder.AppendLine($"--playlist-item-a-text-decoration-hover: underline;");

            stringBuilder.Append("}</style>");
            return new HtmlString(stringBuilder.ToString());


        }
    }
}
