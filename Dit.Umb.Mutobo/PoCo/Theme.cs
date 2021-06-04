using System.Text;
using System.Web;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Enum;
using Dit.Umb.Mutobo.Interfaces;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.Mutobo.PoCo
{
    public class Theme : PublishedElementModel, ITheme
    {


        public EPageTheme PageTheme => this.HasValue(DocumentTypes.Theme.Fields.PageTheme)
            ? (EPageTheme) System.Enum.Parse(typeof(EPageTheme),
                this.Value<string>(DocumentTypes.Theme.Fields.PageTheme))
            : EPageTheme.Cyan;

        public string BackgroundColor => this.HasValue(DocumentTypes.Theme.Fields.BackgroundColor)
            ? this.Value<string>(DocumentTypes.Theme.Fields.BackgroundColor) : null;
        public string ColorHover => this.HasValue(DocumentTypes.Theme.Fields.ColorHover) ? this.Value<string>(DocumentTypes.Theme.Fields.ColorHover) : null;
        public string ColorSecondary => this.HasValue(DocumentTypes.Theme.Fields.ColorSecondary) ? this.Value<string>(DocumentTypes.Theme.Fields.ColorSecondary) : null;
        public string Color => this.HasValue(DocumentTypes.Theme.Fields.Color) ? this.Value<string>(DocumentTypes.Theme.Fields.Color) : null;

        public string FooterBackgroundColor => this.HasValue(DocumentTypes.Theme.Fields.FooterBackgroundColor) ? this.Value<string>(DocumentTypes.Theme.Fields.FooterBackgroundColor) : null;
        public string FooterColorHover => this.HasValue(DocumentTypes.Theme.Fields.FooterColorHover) ? this.Value<string>(DocumentTypes.Theme.Fields.FooterColorHover) : null;
        public string FooterColor => this.HasValue(DocumentTypes.Theme.Fields.FooterColor) ? this.Value<string>(DocumentTypes.Theme.Fields.FooterColor) : null;
        public string HeaderBackgroundColor => this.HasValue(DocumentTypes.Theme.Fields.HeaderBackgroundColor) ? this.Value<string>(DocumentTypes.Theme.Fields.HeaderBackgroundColor) : null;

        public string HeaderColor => this.HasValue(DocumentTypes.Theme.Fields.HeaderColor) ? this.Value<string>(DocumentTypes.Theme.Fields.HeaderColor) : null;
        public string NavigationBackgroundColor => this.HasValue(DocumentTypes.Theme.Fields.NavigationBackgroundColor) ? this.Value<string>(DocumentTypes.Theme.Fields.NavigationBackgroundColor) : null;
        public string NavigationColorHover => this.HasValue(DocumentTypes.Theme.Fields.NavigationColorHover) ? this.Value<string>(DocumentTypes.Theme.Fields.NavigationColorHover) : null;
        public string NavigationColor => this.HasValue(DocumentTypes.Theme.Fields.NavigationColor) ? this.Value<string>(DocumentTypes.Theme.Fields.NavigationColor) : null;

        public string NavigationHrColor => this.HasValue(DocumentTypes.Theme.Fields.NavigationHrColor) ? this.Value<string>(DocumentTypes.Theme.Fields.NavigationHrColor) : null;

        public string HrColor => this.HasValue(DocumentTypes.Theme.Fields.HrColor) ? this.Value<string>(DocumentTypes.Theme.Fields.HrColor) : null;


        public Theme(IPublishedElement content) : base(content)
        {


        }



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
