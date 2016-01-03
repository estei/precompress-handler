using System.Web;

namespace PrecompressedAssets
{
    public static class RequestExtensions
    {
        public static bool AcceptsGzip(this HttpRequest request)
        {
            var acceptEncoding = request.Headers["Accept-Encoding"];
            return !string.IsNullOrWhiteSpace(acceptEncoding) && acceptEncoding.Contains("gzip");
        }
    }
}