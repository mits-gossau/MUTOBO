using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using Dit.Umb.Mutobo.Interfaces;
using Dit.Umb.Mutobo.PoCo;
using Dit.Umb.Mutobo.Services;
using NUglify;
using NUglify.JavaScript;
using Umbraco.Core;

namespace Dit.Umb.ToolBox.Services.Impl
{
    public class ScriptService : BaseService, IScriptService
    {

        private readonly IConfigurationService _configurationService;


        public ScriptService(IConfigurationService configurationService)
        {
            _configurationService = configurationService;
        }



        public string GetWebComponentsBundled()
        {
            var wcDirectory = HttpContext.Current.Server.MapPath($"~/{_configurationService.GetAppSettingValue("Toolbox.WebComponentsBaseFolder")}");
            var files = GetJsFiles(wcDirectory);
            return GetMinifiedJs(files);
        }



        private IEnumerable<ScriptInfo> GetJsFiles(string dir)
        {
            List<ScriptInfo> result = new List<ScriptInfo>();

            try
            {
                var di = new DirectoryInfo(dir);
                var files = di.GetFiles("*.js", SearchOption.AllDirectories);


                foreach (var fi in files)
                {

                    if (fi.FullName.Contains("Shadow.js") || fi.FullName.Contains("shadow.js"))
                        result.Add(new ScriptInfo()
                        {
                            FileInfo = fi,
                            Priority = 1
                        });
                    else if (fi.FullName.Contains("prototypes"))
                        result.Add(new ScriptInfo()
                        {
                            FileInfo = fi,
                            Priority = 2
                        });
                    else
                        result.Add(new ScriptInfo()
                        {
                            FileInfo = fi,
                            Priority = 99
                        });


                }

                return result.OrderBy(si => si.Priority);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetMinifiedJs(IEnumerable<ScriptInfo> files)
        {
            var builder = new StringBuilder();
            var counter = 0;
            string line;

            files = files.OrderBy(f => f.Priority);

            try
            {
                foreach (var fi in files)
                {
                    using (var reader = new StreamReader(fi.FileInfo.FullName))
                    {
                        while ((line = reader.ReadLine()) != null)
                        {
                            if (line.TrimStart().StartsWith("export default "))
                                builder.AppendLine(line.Replace("export default ", string.Empty));
                            else if (line.TrimStart().StartsWith("export const "))
                                builder.AppendLine(line.Replace("export const ", "const "));
                            else if (line.TrimStart().StartsWith("import('../"))
                                builder.AppendLine(line.Replace("../",$"/{_configurationService.GetAppSettingValue("Toolbox.WebComponentsBaseFolder")}"));
                            else if (!(line.TrimStart().StartsWith("import ")))
                                builder.AppendLine(line);
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            var code = builder.ToString();


            var minifiedString = Uglify.Js(code, new CodeSettings()
            {
                LocalRenaming = LocalRenaming.KeepAll,

            });

            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
           

            var result = minifiedString.Code.Replace(Environment.NewLine, " ");
            result = regex.Replace(result, " ");
            return result;


        }

        public static string CssMinifier(Match match)
        {

            return match.Value;
        }
    }
}
