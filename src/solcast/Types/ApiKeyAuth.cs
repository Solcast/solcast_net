using System.Runtime.Serialization;

namespace Solcast.ServiceModel
{
    [DataContract]
    public abstract class ApiKeyAuth
    {
        [DataMember(Name = "api_key")]
        public string ApiKey { get; set; }
    }
}