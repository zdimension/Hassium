using System.Net;
using System.Text;

namespace Hassium.Functions
{
    public class NetworkingFunctions : ILibrary
    {
        private static WebClient client = new WebClient();

        [IntFunc("downstr", "dowstr")]
        public static object DownStr(object[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            return client.DownloadString(args[0].ToString());
        }

        [IntFunc("downfile", "dowfile")]
        public static object DownFile(object[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            client.DownloadFile(args[0].ToString(), args[1].ToString());
            return null;
        }

        [IntFunc("upfile")]
        public static object UpFile(object[] args)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            client.Headers.Add("Content-Type", "binary/octet-stream");
            return Encoding.ASCII.GetString(client.UploadFile(args[0].ToString(), "POST", args[1].ToString()));
        }
    }
}
