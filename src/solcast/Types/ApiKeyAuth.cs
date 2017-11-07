using System.Runtime.Serialization;

namespace Solcast.Types
{
    [DataContract]
    public abstract class ApiKeyAuth
    {
        [DataMember(Name = "api_key")]
        public string ApiKey { get; set; }
    }
}