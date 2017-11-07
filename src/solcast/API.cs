using System;

namespace Solcast
{
    public static class API
    {
        public static string Key(string apiKey = null)
        {
            apiKey = apiKey ?? User.Key;
            if (string.IsNullOrEmpty(apiKey))
            {
                throw new ArgumentException("Solcast Api Key not set");
            }
            return apiKey;
        }       
        
        private static TimeSpan _timeout;
        public const string Url = @"https://api.Solcast.com.au";

        public static TimeSpan Timeout
        {
            get
            {
                if (_timeout <= TimeSpan.Zero)
                {
                    _timeout = TimeSpan.FromMinutes(1);
                }
                return _timeout;
            }
            set
            {
                if (value <= TimeSpan.Zero)
                {
                    _timeout = TimeSpan.FromMinutes(1);
                    return;
                }
                _timeout = value;
            }
        }
    }
}