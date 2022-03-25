using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Umbraco.Web.Composing;

namespace Dit.Umb.Mutobo.Extentions
{
    public static class HtmlHelperExtensions
    {
        public static HtmlString UmbracoTranslation(this HtmlHelper helper, string value)
        {
            return new HtmlString(Current.UmbracoHelper.GetDictionaryValue(value, "TRANSLATE: " + value));
        }
    }
}
