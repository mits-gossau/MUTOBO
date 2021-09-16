using System.Web.Mvc;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.Logging;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace Dit.Umb.Mutobo.Composer
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class LogComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {

            var configService =
                (IConfigurationService) DependencyResolver.Current.GetService(typeof(IConfigurationService));

            var useAzureTableLogs = configService.GetAppSettingBoolValue("UseAzureTableLogs") ?? false;

            if (useAzureTableLogs)
            {

                composition.SetLogViewer<AzureTableLogViewer>();

            }

        }
    }
}