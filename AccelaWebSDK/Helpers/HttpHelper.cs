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

        public static string SendUploadRequest(AttachmentInfo attachmentInfo, string url, string token, string appId)
        {
            using (var client = new HttpClient())
            {
                using (var content = new MultipartFormDataContent())
                {
                    //FileInfo file = null;

                    //file = new FileInfo(documentPath);
                    //if (file != null)
                    //{
                    //    StreamContent fileContent = new StreamContent(file.OpenRead());
                    //    content.Add(fileContent, "\"file\"", "\"" + file.Name + "\"");
                    //    content.Add(new StringContent(GetFileInfo(documentPath, description)), "\"fileInfo\"");

                    //    client.DefaultRequestHeaders.Add(appIdHeader, appId);
                    //    client.DefaultRequestHeaders.Add("Accept", "application/json");
                    //    client.DefaultRequestHeaders.Add("Authorization", token);
                    //    var result = client.PostAsync(url, content).Result;
                    //    return (string)result.Content.ReadAsStringAsync().Result;
                    //}

                    if (attachmentInfo.FileContent != null)
                    {
                        string fileInfo = GetFileInfo(attachmentInfo);
                        content.Add(attachmentInfo.FileContent, "\"file\"", "\"" + attachmentInfo.FileName + "\"");
                        content.Add(new StringContent(fileInfo), "\"fileInfo\"");

                        client.DefaultRequestHeaders.Add(appIdHeader, appId);
                        client.DefaultRequestHeaders.Add("Accept", "application/json");
                        client.DefaultRequestHeaders.Add("Authorization", token);
                        var result = client.PostAsync(url, content).Result;
                        return (string)result.Content.ReadAsStringAsync().Result;
                    }
                }
            }
            return null;
        }

        public static RESTResponse SendPostRequest(string url, Object request, string token, string appId)
        {
            HttpWebRequest httpRequest = PrepareRequest(url, "POST", appId, token);
            string requestString = Newtonsoft.Json.JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

            // Send
            using (StreamWriter s = new StreamWriter(httpRequest.GetRequestStream()))
            {
                s.Write(requestString);
                s.Flush();
            }
            return ReceiveRESTResponse(httpRequest);
        }

        public static AttachmentInfo SendDownloadRequest(string url, AttachmentInfo attachmentInfo, string token, string appId)
        {
            //HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            //request.Method = "GET";
            //request.ContentType = contentType;
            //request.Accept = accept;
            //request.Headers.Add(appIdHeader, appId);
            //request.Headers.Add("Authorization", token);
            //var httpResponse = (HttpWebResponse)request.GetResponse();

            // Receive
            //using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            //{
            //    //attachmentInfo.FileContent = streamReader.BaseStream.;
            //    attachmentInfo.FileType = httpResponse.Headers["Content-Type"];
            //    if (httpResponse.Headers["Content-Disposition"] != null)
            //    {
            //        string[] tmp = httpResponse.Headers["Content-Disposition"].Split('"');
            //        if (tmp != null && tmp.Length > 2)
            //            attachmentInfo.FileName = tmp[1];
            //    }
            //}

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add(appIdHeader, appId);
                client.DefaultRequestHeaders.Add("Accept", "application/json");
                client.DefaultRequestHeaders.Add("Authorization", token);
                client.DefaultRequestHeaders.Add("ContentType", contentType);
                var result = client.GetAsync(url);
                //attachmentInfo.FileName
                //attachmentInfo.FileContent = result.Result.Content["file"];
            }
            return attachmentInfo;
        }

        public static RESTResponse SendPutRequest(string url, Object request, string token, string appId)
        {
            HttpWebRequest httpRequest = PrepareRequest(url, "PUT", appId, token);
            string requestString = Newtonsoft.Json.JsonConvert.SerializeObject(request, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore, DefaultValueHandling = DefaultValueHandling.Ignore });

            // Send
            using (StreamWriter s = new StreamWriter(httpRequest.GetRequestStream()))
            {
                s.Write(requestString);
                s.Flush();
            }
            return ReceiveRESTResponse(httpRequest);
        }

        public static RESTResponse SendDeleteRequest(string url, string token, string appId)
        {
            HttpWebRequest httpRequest = PrepareRequest(url, "DELETE", appId, token);
            return ReceiveRESTResponse(httpRequest);
        }

        public static RESTResponse SendGetRequest(string url, string token, string appId)
        {
            HttpWebRequest httpRequest = PrepareRequest(url, "GET", appId, token);
            return ReceiveRESTResponse(httpRequest);
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

        public static Object ConvertToSDKResponse(Object toReturn, RESTResponse response, ref PaginationInfo paginationInfo)
        {
            if (response != null && response.Result != null)
            {
                paginationInfo = response.Page;
                return ConvertToSDKResponse(toReturn, response);
            }
            return null;
        }

        public static Object ConvertToSDKResponse(Object toReturn, RESTResponse response)
        {
            if (response != null && response.Result != null && (response.Status == 200 || response.Status == 0))
            {
                return Newtonsoft.Json.JsonConvert.DeserializeObject(response.Result.ToString(), toReturn.GetType());
            }
            return null;
        }

        #region private methods
        private static string GetFileInfo(AttachmentInfo attachmentInfo)
        {
            if (string.IsNullOrEmpty(attachmentInfo.ServiceProviderCode) || string.IsNullOrEmpty(attachmentInfo.FileName) || string.IsNullOrEmpty(attachmentInfo.FileType))
                throw new Exception("Invalid attachment Info provided");

            StringBuilder str = new StringBuilder("[{ \"serviceProviderCode\": \"{service}\", \"fileName\": \"{fileName}\", \"type\": \"{fileType}\", \"description\": \"{description}\"}]");
            str.Replace("{service}", attachmentInfo.ServiceProviderCode);
            str.Replace("{fileName}", attachmentInfo.FileName);
            str.Replace("{fileType}", attachmentInfo.FileType);
            str.Replace("{description}", attachmentInfo.Description);
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

        private static RESTResponse ReceiveRESTResponse(HttpWebRequest httpRequest)
        {
            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                var resp = streamReader.ReadToEnd();
                RESTResponse response = new RESTResponse();
                response = (RESTResponse)Newtonsoft.Json.JsonConvert.DeserializeObject(resp, response.GetType());

                if (response != null)
                {
                    if (response.Status == 0)
                        return response;
                    if (response.Status != 200)
                    {
                        string message = string.Format("Request Failed with Code {0} and Error {1} ", response.Code, response.Message);
                        throw new Exception(message);
                    }
                    else if (response.Status == 200 && response.Result != null && response.Result.ToString().Contains("failedCount"))
                    {
                        Result result = new Result();
                        result = (Result)Newtonsoft.Json.JsonConvert.DeserializeObject(response.Result.ToString(), result.GetType());
                        if (result.failedCount > 0)
                            throw new Exception("Request Failed");
                    }
                }
                return response;
            }
        }
        #endregion
    }
}
