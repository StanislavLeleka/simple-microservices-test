using Newtonsoft.Json;
using NotificationService.Models;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace Message.API.Services
{
    public class HttpComunicationHelper
    {
        private const string NOTIFICATION_SERVICE_HOST = "http://localhost:32768";
        private readonly HttpWebRequest _webRequest;

        public HttpComunicationHelper()
        {
            _webRequest = (HttpWebRequest)WebRequest.Create($"{NOTIFICATION_SERVICE_HOST}/api/notification/receive-message");
            _webRequest.ContentType = "application/json";
            _webRequest.Method = "POST";
        }

        public async Task PostJson(string json)
        {
            using (var streamWriter = new StreamWriter(_webRequest.GetRequestStream()))
            {
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            await _webRequest.GetResponseAsync();
        }
    }
}
