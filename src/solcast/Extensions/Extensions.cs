using System.Collections.Generic;
using System.Linq;

namespace solcast
{
    public static class Extensions
    {
        public static Dictionary<string, object> ToUpperKeys(this IDictionary<string, object> current)
        {
            return (current ?? new Dictionary<string, object>()).ToDictionary(item => item.Key.ToUpperInvariant(), item => item.Value);
        }       
    }
}