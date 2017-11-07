using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using ServiceStack;

namespace solcast
{
    public static class Extensions
    {
        public static void DefaultSolcastClient(this JsonHttpClient client, string apiKey = null)
        {
            client.Headers.Add(HttpHeaders.Authorization, $"Bearer {API.Key(apiKey)}");
            client.GetHttpClient().Timeout = API.Timeout;
            client.ResponseFilter += message => { message.RateLimitReset(); };
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

        public static Dictionary<string, object> ToUpperKeys(this IDictionary<string, object> current)
        {
            return (current ?? new Dictionary<string, object>()).ToDictionary(item => item.Key.ToUpperInvariant(), item => item.Value);
        }       
    }
}