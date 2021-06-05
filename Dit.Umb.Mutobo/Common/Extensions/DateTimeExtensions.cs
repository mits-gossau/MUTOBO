using System;
using System.Globalization;
using System.Web.Mvc;

namespace Dit.Umb.Mutobo.Common.Extensions
{
    public static class DateTimeExtensions
    {


        /// <summary>
        /// Formats a DateTime in a specialized local formatted string.
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static MvcHtmlString ToClassicsDateString(this DateTime dateTime)
        {
            string html = String.Empty;
            switch (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower())
            {
                case "en":
                    html = $"{dateTime.ToString("dddd").ToUpper()}, {dateTime:dd}. {dateTime.ToString("MMMM").ToUpper()} {dateTime:yyyy}, {dateTime.TimeString()}";
                    break;
                case "fr":
                    if (dateTime.Minute == 0)
                        html = $"{dateTime.ToString("dddd").ToUpper()} {dateTime:dd} {dateTime.ToString("MMMM").ToUpper()} {dateTime:yyyy} {dateTime.TimeString()}";
                    else
                        html = $"{dateTime.ToString("dddd").ToUpper()} {dateTime:dd} {dateTime.ToString("MMMM").ToUpper()} {dateTime:yyyy} {dateTime.TimeString()}";
                    break;
                case "de":
                default:
                    html = $"{dateTime.ToString("dddd").ToUpper()}, {dateTime:dd}. {dateTime.ToString("MMMM").ToUpper()} {dateTime:yyyy}, {dateTime.TimeString()}";
                    break;
            }

            return new MvcHtmlString(html);

        }

        public static MvcHtmlString SingleDateWithStarsString(this DateTime dateTime) {

            return new MvcHtmlString(string.Format("<span>{0:dd*MM*yy}</span>", dateTime));
        }

        public static MvcHtmlString DateWithStarsAndDayString(this DateTime dateTime, bool upperCase = false)
        {
            string day = dateTime.ToString("dddd").Substring(0, 2);
            if (upperCase)
                day = day.ToUpper();

            return new MvcHtmlString(day + ", " + dateTime.SingleDateWithStarsString());
        }

        public static MvcHtmlString TimeString(this DateTime dateTime)
        {
            string html = String.Empty;
            switch (CultureInfo.CurrentCulture.TwoLetterISOLanguageName.ToLower())
            {
                case "en":
                    html = $"<span> {dateTime:h:mm tt}</span>";
                    break;
                case "fr":
                    if (dateTime.Minute == 0)
                        html = $"<span> À {dateTime:HH} H</span>";
                    else
                        html = $"<span> À {dateTime:HH} H {dateTime:mm}</span>";
                    break;
                case "de":
                default:
                    html = $"<span> {dateTime:HH}.{dateTime:mm} UHR</span>";
                    break;
            }

            return new MvcHtmlString(html);
        }


    }
}
