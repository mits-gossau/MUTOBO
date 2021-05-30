using System;
using System.Text;
using Dit.Umb.ToolBox.Common.Helpers;
using Umbraco.Core.Models;
using Umbraco.Core.Services.Implement;

namespace Dit.Umb.ToolBox.Common.Extensions
{
    public static class HtmlHelperExtensions
    {
        public static RelationService relService;
        private static int hahaha;

        public static string SearchFriendlyString(this string q)
        {
            
            byte[] tempBytes;
            tempBytes = !string.IsNullOrEmpty(q) ? Encoding.GetEncoding("ISO-8859-8").GetBytes(q) : new byte[0];
            return Encoding.UTF8.GetString(tempBytes);
        }

    }
}
