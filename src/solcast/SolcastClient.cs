using System;
using ServiceStack;

namespace Solcast
{
    public class SolcastClient : JsonHttpClient
    {
        public readonly TimeZoneInfo CurrentTimeZone;
        public string Key { get; set; }        
        public Options System { get; set; }
        
        public SolcastClient()
        {
            Key = API.Key();
            CurrentTimeZone = TimeZoneInfo.Utc;
            SetupClient();
        }

        public SolcastClient(string apiKey, TimeZoneInfo inputZone = null)
        {
            Key = API.Key(apiKey);
            CurrentTimeZone = inputZone ?? TimeZoneInfo.Utc;            
            SetupClient();
        }

        private void SetupClient()
        {
            BaseUri = API.Url;
            RequestFilter = message => message.AddBearerToken(Key);
            GetHttpClient().Timeout = API.Timeout;
            System = new Options
            {
                PowerOptions = new PvSystem { Capacity = 5000 },
                RadiationOptions = new RadiationSystem()
            };
        }
    }
}