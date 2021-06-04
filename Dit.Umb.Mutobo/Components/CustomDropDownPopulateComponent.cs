using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Dit.Umb.Mutobo.Common.Exceptions;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.Services;
using Umbraco.Core.Composing;
using Umbraco.Core.PropertyEditors;
using Umbraco.Web.PropertyEditors;

namespace Dit.Umb.Mutobo.Components
{
    public class CustomDropDownPopulateComponent : IComponent
    {
        private readonly IConfigurationService _configurationService;
        


        public CustomDropDownPopulateComponent(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }



        public void Initialize()
        {

            var dataTypeId = _configurationService.GetAppSettingIntValue("Toolbox.Theme.DropDown.FontFamily");


            if (!dataTypeId.HasValue)
                throw new AppSettingsException("There is value 'Toolbox.Theme.DropDown.FontFamily' key in the AppSettings.config file");

            var dataType = Current.Services.DataTypeService.GetDataType(dataTypeId.Value);

            if (dataType == null)
                Current.Logger.Info(this.GetType(), "Missing DataType for Theme Dropdown");
                return;

            ((ValueListConfiguration)dataType.Configuration).Items.Clear();

            ((ValueListConfiguration)dataType.Configuration).Items.AddRange(GetAvailableFonts());

            Current.Services.DataTypeService.Save(dataType);

        }


        private IEnumerable<ValueListConfiguration.ValueListItem> GetAvailableFonts()
        {
            var result = new List<ValueListConfiguration.ValueListItem>();
            var wcDirectory = HttpContext.Current.Server.MapPath($"~/{_configurationService.GetAppSettingValue("Toolbox.WebComponentsFontsFolder")}");
            var di = new DirectoryInfo(wcDirectory);
            var fonts = di.GetFiles("*.woff", SearchOption.AllDirectories)
                .Concat(di.GetFiles("*.woff2", SearchOption.AllDirectories))
                .Concat(di.GetFiles("*.eot", SearchOption.AllDirectories))
                .Concat(di.GetFiles("*.TTF", SearchOption.AllDirectories))
                .Concat(di.GetFiles("*.svg", SearchOption.AllDirectories));

            var i = 0;

            foreach (var font in fonts)
            {
                var fontName = font.Name.Split('.')[0];

                if (result.All(e => e.Value != fontName))
                {
                    result.Add(new ValueListConfiguration.ValueListItem()
                    {
                        Value = fontName,
                        Id = i
                    });
                }

                i++;
            }

            return result;


        }

        public void Terminate()
        {
            throw new NotImplementedException();
        }
    }
}