using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace Solcast
{
    public static class Extensions
    {
        public static DateTime ConvertTime(this DateTime timeStamp, TimeZoneInfo current = null)
        {
            return TimeZoneInfo.ConvertTime(timeStamp, current ?? TimeZoneInfo.Utc);
        }       

        public static void RateLimitReset(this HttpResponseMessage message)
        {
            if (!message.Headers.TryGetValues("X-Rate-Limit-Remaining", out var limits))
            {
                return;
            }
            var limitText = (limits ?? new List<string>()).FirstOrDefault();
            if (limitText == null)
            {
                return;
            }
            if (!long.TryParse(limitText, out var limit))
            {
                return;
            }
            if (limit == 0)
            {
                throw new HttpRequestException("You have exceeded your current threshold limit, please wait longer between sending requests");
            }
        }   
    }
}