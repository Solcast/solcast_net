using System;

namespace Solcast
{
    public static class Extensions
    {
        public static DateTime ConvertTime(this DateTime timeStamp, TimeZoneInfo current = null)
        {
            return TimeZoneInfo.ConvertTime(timeStamp, current ?? TimeZoneInfo.Utc);
        }
    }
}