using System.Web.Mvc;
using Dit.Umb.ToolBox.Common.Poco;
using Dit.Umb.ToolBox.Services;

namespace Dit.Umb.ToolBox.Common.Helpers
{
    public static class LayoutHelper
    {
        public static ImageSize GetImageSize(int factor = 1)
        {
            var configService =
                (IConfigurationService) DependencyResolver.Current.GetService(typeof(IConfigurationService));

            return new ImageSize()
            {
                Width = configService.GetAppSettingIntValue("ImageDefaultWidth") ?? 0,
                Height = configService.GetAppSettingIntValue("ImageDefaultHeight") ?? 0
            };
        }
    }
}
