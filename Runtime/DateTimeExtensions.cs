using System;

namespace JasonStorey
{
    public static class DateTimeExtensions
    {
        public static int GetAge(this DateTimeOffset dateOfBirth)
        {
            var today = DateTimeOffset.Now;
            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (dateOfBirth.Year * 100 + dateOfBirth.Month) * 100 + dateOfBirth.Day;
            return (a - b) / 10000;
        }

        public static string ToFriendlyDuration(this DateTimeOffset date) => 
            date > DateTimeOffset.Now ? date.ToFutureDuration() : date.ToPastDuration();

        static string ToPastDuration(this DateTimeOffset dateTime)
        {
            var when = dateTime;
            var ts = DateTimeOffset.Now.Subtract(when);
            if (ts.TotalMinutes < 3)
                return "just now";
            if (ts.TotalHours < 1)
                return $"{ts.TotalMinutes:##} minutes ago";
            if (ts.TotalDays < 1)
            {
                return ts.TotalHours <= 1
                    ? "An hour ago"
                    : $"{ts.TotalHours:##} hours ago";
            }

            if (ts.TotalDays <= 1)
                return "Yesterday";
            if (ts.TotalDays <= 3)
                return "A Few Days Ago";
            if (ts.TotalDays < 7)
                return string.Format("{0:##} Days Ago", ts.TotalDays);
            if (ts.TotalDays < 8)
                return "A Week Ago";
            if (ts.TotalDays > 26)
                return $"Over a month ago";
            return "a long time ago";
        }

        static string ToFutureDuration(this DateTimeOffset dateTime)
        {
            var when = dateTime;
            var ts = when.Subtract(DateTimeOffset.Now);
            if (ts.TotalMinutes < 1)
                return "Now";
            if (ts.TotalHours < 1)
                return $"In {ts.TotalMinutes:##} minutes";
            if (ts.TotalDays < 1)
            {
                return ts.TotalHours <= 1
                    ? "In an hour"
                    : $"In {ts.TotalHours:##} hours";
            }

            if (ts.TotalDays <= 1)
                return $"Tomorrow";
            if (ts.TotalDays <= 3)
                return $"In A Few Days";
            if (ts.TotalDays < 7)
                return $"In {ts.TotalDays:##} Days";
            if (ts.TotalDays < 8)
                return $"In A Week";
            if (ts.TotalDays > 26)
                return $"In a month";
            return "In a long time";
        }

        public static DateTime ToDateTime(this DateTimeOffset dateTimeOffset) => dateTimeOffset.DateTime;
        
        public static DateTimeOffset ToDateTimeOffset(this DateTime dateTime)
        {
            DateTimeOffset dateTimeOffset = dateTime;
            return dateTimeOffset;
        }
    }
}