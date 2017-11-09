using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using ServiceStack.Text;

namespace Solcast
{
    public static class HttpResponseMessageExtensions
    {
        public static IEnumerable<string> HeaderValue(this HttpResponseHeaders headers, string name)
        {
            if (headers == null ||
                string.IsNullOrEmpty(name))
            {
                return null;
            }

            var match = headers.FirstOrDefault(z => string.Equals(z.Key, name, StringComparison.InvariantCultureIgnoreCase));
            return match.Value ?? new List<string>();
        }        
        
        public static long? RateLimit(this HttpResponseHeaders headers)
        {
            var value = headers.HeaderValue("x-rate-limit");
            return FindMaxAsLong(value);
        }
        
        public static long? RateLimitRemaining(this HttpResponseHeaders headers)
        {
            var value = headers.HeaderValue("x-rate-limit-remaining");
            return FindMaxAsLong(value);
        }

        public static ApiLimits ReadLimits(this HttpResponseMessage message)
        {
            return new ApiLimits(message.Headers.RateLimit(),
                message.Headers.RateLimitRemaining(),
                message.Headers.RateLimitReset());
        }
        

        private static long? FindMaxAsLong(IEnumerable<string> value)
        {
            if (!value.Any())
            {
                return null;
            }
            var limit = value.Select(z => long.TryParse(z, out var parsedLimit) ? parsedLimit : 0).Where(k => k > 0)
                .OrderByDescending(a => a).FirstOrDefault();
            if (limit <= 0)
            {
                return null;
            }
            return limit;
        }
        
        public static DateTime? RateLimitReset(this HttpResponseHeaders headers)
        {
            var value = headers.HeaderValue("x-rate-limit-reset");
            if (!value.Any())
            {
                return null;
            }
            var ticks = FindMaxAsLong(value);
            if (!ticks.HasValue)
            {
                return null;
            }
            var wait = ticks.Value.FromUnixTime();
            return wait;
        }
    }    
    
    public static class Extensions
    {
        public static DateTime ConvertTime(this DateTime timeStamp, TimeZoneInfo current = null)
        {
            return TimeZoneInfo.ConvertTime(timeStamp, current ?? TimeZoneInfo.Utc);
        }
    }
}