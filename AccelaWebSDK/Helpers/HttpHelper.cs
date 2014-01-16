using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Web;
using Newtonsoft.Json;
using System.Configuration;
using System.Resources;
using System.Net.Http;
using Accela.Web.SDK.Models;

namespace Accela.Web.SDK
{
    public static class HttpHelper
    {
        static string errorResponseHeader = null;
        static string traceIdHeader = null;
        static string appIdHeader = null;
        static string appSecretHeader = null;
        static string agencyHeader = null;
        static string envHeader = null;
        static string contentType = null;
        static string accept = null;

        static HttpHelper()
        {
            errorResponseHeader = ConfigurationReader.GetValue("HResponseError");
            traceIdHeader = ConfigurationReader.GetValue("HTraceId");
            appIdHeader = ConfigurationReader.GetValue("HAppId");
            appSecretHeader = ConfigurationReader.GetValue("HAppSecret");
            agencyHeader = ConfigurationReader.GetValue("HAgency");
            envHeader = ConfigurationReader.GetValue("HEnv");
            contentType = ConfigurationReader.GetValue("ContentType");
            accept = ConfigurationReader.GetValue("Accept");
        }

        public static Object SendPostRequest(HttpWebRequest httpRequest, string requestString, Object response)
        {
            // Prepare Header
            httpRequest.Method = "POST";

            // Send
            using (StreamWriter s = new StreamWriter(httpRequest.GetRequestStream()))
            {
                s.Write(requestString);
                s.Flush();
            }

            // Receive
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                response = Newtonsoft.Json.JsonConvert.DeserializeObject(result, response.GetType());
            }
            return response;
        }

        public static Object SendUploadRequest(string documentPath, string description, string url, Object response, string token, string appId)
        {
            // Prepare Request
            HttpWebRequest httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "POST";
            httpRequest.ContentType = "multipart/form-data";
            httpRequest.Accept = accept;
            httpRequest.Headers.Add(appIdHeader, appId);
            httpRequest.Headers.Add("Authorization", token);

            //using (FileStream fileStream = new FileStream(documentPath, FileMode.Open))
            //{
            //    webRequest.ContentLength = fileStream.Length;
            //    byte[] data = new byte[fileStream.Length];
            //    int bytesRead = fileStream.Read(data, 0, (int)fileStream.Length);
            //    Stream requestStream = webRequest.GetRequestStream();
            //    requestStream.Write(data, 0, (int)fileStream.Length);
            //}

            // Send
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    var fileContent = new ByteArrayContent(System.IO.File.ReadAllBytes(documentPath));
                    content.Add(new StringContent(GetFileInfo(documentPath, description)), "fileInfo");
                    content.Add(fileContent, "uploadedFile");

                    using (StreamWriter s = new StreamWriter(httpRequest.GetRequestStream()))
                    {
                        s.Write(content);
                        s.Flush();
                    }
                }
            }

            // Receive
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                response = Newtonsoft.Json.JsonConvert.DeserializeObject(result, response.GetType());
            }
            return response;
        }

        public static KeyValuePair<string, object> SendPostRequest(string url, Object request, string token, string appId)
        {
            HttpWebRequest httpRequest = PrepareRequest(url, "POST", appId, token);
            string requestString = Newtonsoft.Json.JsonConvert.SerializeObject(request);

            // Send
            using (StreamWriter s = new StreamWriter(httpRequest.GetRequestStream()))
            {
                s.Write(requestString);
                s.Flush();
            }

            // Receive
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            KeyValuePair<string, object> response;
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                response = Newtonsoft.Json.JsonConvert.DeserializeObject<KeyValuePair<string, object>>(result);
            }
            return response;
        }

        public static MemoryStream SendDownloadRequest(string url, MemoryStream response, string token, string appId)
        {
            HttpWebRequest httpRequest = PrepareRequest(url, "GET", appId, token);
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            // Receive
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                string s = streamReader.ReadToEnd();
                if (!string.IsNullOrEmpty(s))
                {
                    response = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(s));
                }
            }
            return response;
        }

        public static void SendPutRequest(string url, Object request, string token, string appId)
        {
            HttpWebRequest httpRequest = PrepareRequest(url, "PUT", appId, token);
            string requestString = Newtonsoft.Json.JsonConvert.SerializeObject(request);

            // Send
            using (StreamWriter s = new StreamWriter(httpRequest.GetRequestStream()))
            {
                s.Write(requestString);
                s.Flush();
            }

            // Receive
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public static void SendDeleteRequest(string url, string token, string appId)
        {
            HttpWebRequest httpRequest = PrepareRequest(url, "DELETE", appId, token);
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            // Send
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
        }

        public static Object SendGetRequest(string url, string token, string appId, object response)
        {
            HttpWebRequest httpRequest = PrepareRequest(url, "GET", appId, token);
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

            // Send
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                return ProcessRESTResponse(response, result);
            }
        }

        public static string HandleWebException(WebException webException, string message)
        {
            message += " " + webException.Response.Headers[errorResponseHeader] + " Trace Id : " + webException.Response.Headers[traceIdHeader];
            return message;
        }

        public static string HandleException(Exception exception, string message)
        {
            message += exception.Message;
            return message;
        }

        public static string GetErrorMessage(string message)
        {
            return message;
        }

        #region private methods
        private static Object ProcessRESTResponse(Object toReturn, string result)
        {
            RESTResponse response = new RESTResponse();
            response = (RESTResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(result, response.GetType());
            if (response != null && response.Result != null && response.Status == 200)
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject(response.Result.ToString(), toReturn.GetType());
            }
            return null;
        }

        private static string GetFileInfo(string documentPath, string description)
        {
            StringBuilder str = new StringBuilder("[{ \"serviceProviderCode\": \"BPTMSTR\", \"fileName\": \"{fileName}\", \"type\": \"{fileType}\", \"description\": \"{description}\"}]");
            FileInfo fileInfo = new FileInfo(documentPath);
            if (fileInfo != null)
            {
                str.Replace("{fileName}", fileInfo.Name);
                str.Replace("{fileType}", fileInfo.Extension.Replace('.', ' '));
                str.Replace("{description}", description);
            }
            return str.ToString();
        }

        private static HttpWebRequest PrepareRequest(string url, string method, string appId, string token)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.ContentType = contentType;
            request.Accept = accept;
            request.Headers.Add(appIdHeader, appId);
            request.Headers.Add("Authorization", token);
            return request;
        }
        #endregion
    }
}
