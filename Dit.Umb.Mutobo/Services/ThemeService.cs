using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Dit.Umb.Mutobo.Constants;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Dit.Umb.Mutobo.Services;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace Dit.Umb.ToolBox.Services.Impl
{
    public class ThemeService : BaseService, IThemeService
    {

        private readonly IConfigurationService _configurationService;


        public ThemeService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }




        public virtual ITheme GetTheme(IPublishedContent content)
        {
            
            var theme = content?.AncestorsOrSelf()?
                .FirstOrDefault(c => c.HasValue(DocumentTypes.BasePage.Fields.Theme))?
                .Value<IEnumerable<IPublishedElement>>(DocumentTypes.BasePage.Fields.Theme)?
                .FirstOrDefault();

            if (theme != null)
                return new Theme(theme);

            return null;
        }



        public IEnumerable<Font> GetFonts()
        {
            var result = new List<Font>();
            var wcDirectory = HttpContext.Current.Server.MapPath($"~/{_configurationService.GetAppSettingValue("Toolbox.WebComponentsFontsFolder")}");
            var di = new DirectoryInfo(wcDirectory);
            var i = 0;
            var fonts = di.GetFiles("*.woff", SearchOption.AllDirectories)
                .Concat(di.GetFiles("*.woff2", SearchOption.AllDirectories))
                .Concat(di.GetFiles("*.eot", SearchOption.AllDirectories))
                .Concat(di.GetFiles("*.TTF", SearchOption.AllDirectories))
                .Concat(di.GetFiles("*.svg", SearchOption.AllDirectories));


            var fileInfos = fonts as FileInfo[] ?? fonts.ToArray();
            foreach (var font in fileInfos)
            {
                var fontName = font.Name.Split('.')[0];
                result.Add(new Font
                {
                    Name = fontName,
                    Files = fileInfos.Where(f => f.Name.StartsWith(fontName))
                });
                i++;
            }

            return result;
        }
    }

}
