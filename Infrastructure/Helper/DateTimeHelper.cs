using System;

namespace Infrastructure.Helper
{
    public static class DateTimeHelper
    {
        public static int GetTotalDaysOfDateTime(this DateTime date)
        {
            TimeSpan diff = DateTime.Now - date;
            int days = (int)Math.Abs(Math.Round(diff.TotalDays));
            return days;
        }
    }
}