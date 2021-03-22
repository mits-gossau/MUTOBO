using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dit.Umb.ToolBox.Common.Extensions
{
    public static class DateTimeExtensions
    {


        /// <summary>
        /// Formats a DateTime in a specialized local formatted string.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToClassicsDateString(this DateTime dateTime)
        {
            switch (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower())
            {
                case "en":
                    return
                        $"{dateTime.ToString("dddd").ToUpper()}, {dateTime:dd}. {dateTime.ToString("MMMM").ToUpper()} {dateTime:yyyy}, <span> {dateTime:h:mm tt}</span>";
                
                case "fr":
                    if (dateTime.Minute == 0)
                        return $"{dateTime.ToString("dddd").ToUpper()} {dateTime:dd}. {dateTime.ToString("MMMM").ToUpper()} {dateTime:yyyy} <span> À {dateTime:HH} H</span>";

                    return $"{dateTime.ToString("dddd").ToUpper()} {dateTime:dd}. {dateTime.ToString("MMMM").ToUpper()} {dateTime:yyyy} <span> À {dateTime:HH} H {dateTime:mm}</span>";

                case "de":
                default:
                    return $"{dateTime.ToString("dddd").ToUpper()}, {dateTime:dd}. {dateTime.ToString("MMMM").ToUpper()} {dateTime:yyyy}, <span> {dateTime:HH}.{dateTime:mm} UHR</span>";
            }

        }

        public static string SingleDateWithStarsString(this DateTime dateTime) {
            
            return string.Format("<span>{0:dd*MM*yy}</span>", dateTime);
        }


        

    }
}
