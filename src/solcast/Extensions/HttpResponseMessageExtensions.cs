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

        public static bool RateLimitExceeded(this HttpResponseMessage message)
        {
            if (int.TryParse(message.StatusCode.ToString(), out var code))
            {
                return code == 429;
            }
            return false;
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
            var headers = message.Headers;
            return new ApiLimits(headers.RateLimit(),
                headers.RateLimitRemaining(),
                headers.RateLimitReset());
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
            var wait = ticks?.FromUnixTime();
            return wait;
        }
    }
}