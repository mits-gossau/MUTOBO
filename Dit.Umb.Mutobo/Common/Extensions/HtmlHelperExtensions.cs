using System.Text;
using Umbraco.Core.Services.Implement;

namespace Dit.Umb.Mutobo.Common.Extensions
{
    public static class HtmlHelperExtensions
    {
     
  

        public static string SearchFriendlyString(this string q)
        {
            
            byte[] tempBytes;
            tempBytes = !string.IsNullOrEmpty(q) ? Encoding.GetEncoding("ISO-8859-8").GetBytes(q) : new byte[0];
            return Encoding.UTF8.GetString(tempBytes);
        }

    }
}
