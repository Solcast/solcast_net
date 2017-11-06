using System.Runtime.Serialization;

namespace solcast.types
{
    [DataContract]
    public abstract class ApiKeyAuth
    {
        [DataMember(Name = "api_key")]
        public string ApiKey { get; set; }
    }
}