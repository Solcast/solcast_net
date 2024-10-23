
namespace Solcast.Utilities
{
    public class ApiResponse<T>(T data, string rawResponse)
    {
        public T Data { get; set; } = data;
        public string RawResponse { get; set; } = rawResponse;
    }
}
