using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeterOff.Core.Models
{
    public static class DateTimeHelpers
    {
        public static DateTime GetNowDatetime()
        {
            int zoneDifference = 2;// int.Parse(ConfigurationManager.AppSettings["zoneDifference"]);
            return DateTime.UtcNow.AddHours(zoneDifference);
        }
        public static string GetNowDatetimeString()
        {
            return GetNowDatetime().ToString(CultureInfo.InvariantCulture);
        }
        public static DateTime GetTodayDate()
        {
            return DateTime.Today;
        }

        public static DateTime GetFormateDateFromString(this string dateString)
        {
            if (dateString.Length <= 7)
            {
                dateString = "01/" + dateString;
            }
            return Convert.ToDateTime(dateString.Substring(0, 10), new CultureInfo("ar-EG"));
        }

        public static string GetFormateDateStringFromString(this string dateString)
        {
            string[] array = new string[] { };
            if (dateString.Contains("/"))
            {
                array = dateString.Split('/');
            }
            else if (dateString.Contains("-"))
            {
                array = dateString.Split('-');
            }
            else
            {
                array = dateString.Split('.');
            }
            var date = array[1].ToString() + "/" + array[0].ToString() + "/" + array[2].ToString();
            return date;
        }

        public static DateTime GetFormateDateTimeFromString(this string dateString)
        {
            if (dateString.Length <= 7)
            {
                dateString = "01/" + dateString;
            }
            DateTime date = Convert.ToDateTime(dateString, new CultureInfo("ar-EG"));
            return date;
        }
        public static string AgeToReadableString(this TimeSpan span)
        {
            string formatted = String.Format("{0}{1}{2}",
                span.Duration().Days > 0 ? String.Format("{0:0} D, ", span.Days) : String.Empty,
                span.Duration().Hours > 0 ? String.Format("{0:0} H, ", span.Hours) : String.Empty,
                span.Duration().Minutes > 0 ? String.Format("{0:0} M, ", span.Minutes) : String.Empty,
                span.Duration().Seconds > 0 ? String.Format("{0:0} S", span.Seconds) : String.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (String.IsNullOrEmpty(formatted)) formatted = "Just Now";

            return formatted;
        }
        public static string DurationToReadableString(this TimeSpan span)
        {
            string formatted = String.Format("{0}{1}{2}",
                span.Duration().Days > 0 ? String.Format("{0:0} D, ", span.Days) : String.Empty,
                span.Duration().Hours > 0 ? String.Format("{0:0} H, ", span.Hours) : String.Empty,
                span.Duration().Minutes > 0 ? String.Format("{0:0} M, ", span.Minutes) : String.Empty,
                span.Duration().Seconds > 0 ? String.Format("{0:0} S", span.Seconds) : String.Empty);

            if (formatted.EndsWith(", ")) formatted = formatted.Substring(0, formatted.Length - 2);

            if (String.IsNullOrEmpty(formatted)) formatted = "Just Few Seconds";

            return formatted;
        }

        public static string GetFormatedMonthYear(this string value)
        {
            DateTime date;
            if (!DateTime.TryParseExact(value, "MMMM yyyy", null, DateTimeStyles.None, out date))
                return string.Empty;
            return date.ToString("MM/yyyy");
        }
        public static DateTime GetDateFromUnixTimeStamp(this double unixTimeStamp)
        {
            var dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dtDateTime = dtDateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dtDateTime;
        }
        
        private static string[] GetFormats()
        {
            return new[]
            {
                IsoDateFormat, DateTimeFormat, DateFormat,UserDateFormat1,UserDateFormat2,UserDateFormat3, ShortYearDateFormat, LongYeayIsoDateFormat, MonthYearFormat,
                DateTimeFormat.Replace('/', '.'),
                DateTimeFormat.Replace('/', '-'),
                DateFormat.Replace('/', '.'),
                DateFormat.Replace('/', '-'),
                ShortYearDateFormat.Replace('/', '.'),
                ShortYearDateFormat.Replace('/', '-'),
                 UserDateFormat1.Replace('/', '-'),
                 UserDateFormat2.Replace('/', '-'),
                 UserDateFormat3.Replace('/', '-'),
            };
        }
        public static string DateFormat => "dd/MM/yyyy";
        public static string DateTimeFormat => "dd/MM/yyyy HH:mm";
        public static string IsoDateFormat => "yyMMdd";
        public static string LongYeayIsoDateFormat => "yyyyMMdd";
        public static string ShortYearDateFormat => "dd/MM/yy";
        public static string UserDateFormat1 => "d/M/yyyy";
        public static string UserDateFormat2 => "dd/M/yyyy";
        public static string UserDateFormat3 => "d/MM/yyyy";
        public static string MonthYearFormat => "MMMM yyyy";

        public static bool IsValidDate(string dateTime)
        {
            if (string.IsNullOrEmpty(dateTime))
                return false;
            if (dateTime.Length <= 7)
            {
                dateTime = "01/" + dateTime;
            }
            var date = dateTime.Length == 7 ? dateTime.Remove(0, 1) : dateTime;
            var formats = GetFormats();
            DateTime retDate;
            var parsed = DateTime.TryParseExact(date, formats, null, DateTimeStyles.None, out retDate);
            return parsed;
        }
    }
}
