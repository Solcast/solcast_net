using System;
using System.Net.Http;
using System.Threading.Tasks;
using ServiceStack;
using ServiceStack.Text;

namespace Solcast
{
    public class SolcastClient : JsonHttpClient
    {
        public readonly TimeZoneInfo CurrentTimeZone;
        public string Key { get; set; }        
        public PvSystem PowerOptions { get; set; }
        public SolcastClient()
        {
            Key = API.Key();
            CurrentTimeZone = TimeZoneInfo.Utc;
            SetupClient();
        }

        public Action<HttpResponseMessage> RateLimitExceededFn;

        public SolcastClient(string apiKey, TimeZoneInfo inputZone = null)
        {
            Key = API.Key(apiKey);
            CurrentTimeZone = inputZone ?? TimeZoneInfo.Utc;            
            SetupClient();
        }

        protected ApiLimits Limits;

        private void SetupClient()
        {
            JsConfig.PropertyConvention = PropertyConvention.Lenient;
            BaseUri = API.Url;
            RequestFilter = message =>
            {
                message.AddBearerToken(Key);
                Wait();
            };
            ResponseFilter = message =>
            {
                RateLimitExceededHandler(message);
                Limits = message.ReadLimits();
            };
            GetHttpClient().Timeout = API.Timeout;
            PowerOptions = new PvSystem {Capacity = 5000};
        }

        private void RateLimitExceededHandler(HttpResponseMessage message)
        {
            if (!message.RateLimitExceeded())
            {
                return;
            }
            RateLimitExceededFn?.Invoke(message);
        }

        private void Wait()
        {
            if (Limits?.Remaining.GetValueOrDefault() > 0)
            {
                return;
            }
            var nextValidTime = Limits?.WaitUntil;
            if (nextValidTime == null)
            {
                return;
            }
            var diff = nextValidTime.Value.Subtract(DateTime.UtcNow);
            if (diff <= TimeSpan.Zero)
            {
                return;
            }
            Task.Run(async () => await Task.Delay(diff)).Wait();
        }
    }

    public class ApiLimits
    {
        public ApiLimits(long? limit, long? remaining, DateTime? waitUntil)
        {
            Limit = limit;
            Remaining = remaining;
            WaitUntil = waitUntil;
        }
        
        public readonly long? Limit;
        public readonly long? Remaining;
        public readonly DateTime? WaitUntil;
    }    
}