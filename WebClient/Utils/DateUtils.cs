using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace WebClient.Utils
{
    internal static class DateUtils
    {
        public static string ToJalaliDate(this DateTime date, string separator = "-")
        {
            var persianCalendar = new PersianCalendar();
            return $"{persianCalendar.GetYear(date)}{separator}{persianCalendar.GetMonth(date):00}{separator}{persianCalendar.GetDayOfMonth(date):00}";
        }
        internal static readonly Dictionary<string, string> MonthsMapping = new()
        {
            {"فروردین", "01"},
            {"اردیبهشت", "02"},
            {"خرداد", "03"},
            {"تیر", "04"},
            {"مرداد", "05"},
            {"شهریور", "06"},
            {"مهر", "07"},
            {"آبان", "08"},
            {"آذر", "09"},
            {"دی", "10"},
            {"بهمن", "11"},
            {"اسفند", "12"},
        };
        internal static DateTime ConvertPersianDateToGregorian(string date, char separator = '/')
        {
            date = PersianCharUtils.ArToFaNumber(date);
            date = PersianCharUtils.FaToEnNumber(date);
            var persianCalendar = new PersianCalendar();
            var s = date.Split(separator);
            if (s[0].Length == 2)
            {
                s[0] = "13" + s[0];
            }
            return new DateTime(int.Parse(s[0]), int.Parse(s[1]), int.Parse(s[2]), persianCalendar);
        }
        
    }
}