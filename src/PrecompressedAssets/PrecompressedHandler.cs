using System.IO;
using System.Web;

namespace PrecompressedAssets
{
    public class PrecompressedHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            var uncompressedfile = context.Request.PhysicalPath;
            var compressedFile = uncompressedfile + ".gz";
            //Does the client support gzip?
            if (context.Request.AcceptsGzip())
            {
                if (File.Exists(compressedFile))
                {
                    context.Response.WriteFile(compressedFile);
                    context.Response.Headers.Add("Content-Encoding", "gzip");
                    //contenttype
                    //conditional headers?
                    //Cache client?
                    //cache server?
                    return;
                }
            }
            if (File.Exists(uncompressedfile))
            {
                context.Response.WriteFile(uncompressedfile);
                //contenttype
                //conditional headers?
                //Cache client?
                //cache server?
            }
            else
            {
                context.Response.StatusCode = 404;
            }
        }

        public bool IsReusable => false;
    }
}