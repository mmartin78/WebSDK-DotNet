using Accela.Web.SDK.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Accela.Web.SDK
{
    public class DocumentHandler : BaseHandler, IDocument
    {
        public DocumentHandler(string appId, string appSecret, ApplicationType appType, string language, IConfigurationProvider configManager)
            : base(appId, appSecret, appType, language, configManager)
        {
        } 

        public Document GetDocument(string documentId, string token, string fields = null) 
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(documentId))
                {
                    throw new Exception("Null Document Id provided");
                }
                RequestValidator.ValidateToken(token);

                // get document
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("GetDocument").Replace("{documentIds}", documentId));
                if (this.language != null || fields != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language);
                if (this.language != null && fields != null)
                    url.Append("&");
                if (fields != null)
                    url.Append("fields=").Append(fields);
                RESTResponse response = HttpHelper.SendGetRequest(url.ToString(), token, this.appId);

                // create response
                List<Document> doc = new List<Document>();
                doc = (List<Document>)HttpHelper.ConvertToSDKResponse(doc, response);
                if (doc != null && doc.Count > 0)
                    return doc[0];
                return null;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Document :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Document :"));
            }
        }

        public Stream DownloadDocument(string documentId, string token, string password = null, string userId = null) 
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(documentId))
                {
                    throw new Exception("Null Document Id provided");
                }
                RequestValidator.ValidateToken(token);

                // download document
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("DownloadDocument").Replace("{documentId}", documentId));
                if (this.language != null || password != null || userId != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language).Append("&");
                if (userId != null)
                    url.Append("userId=").Append(userId).Append("&");
                if (password != null)
                    url.Append("password=").Append(password).Append("&");
                url = url.Replace("&", "", url.Length-1, 1) ;

                var stream = HttpHelper.SendDownloadRequest(url.ToString(), token, this.appId);
                return stream.Result;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Download Record Document :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Download Record Document :"));
            }
        }


        public Task<Stream> DownloadDocumentAsync(string documentId, string token, string password = null, string userId = null)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(documentId))
                {
                    throw new Exception("Null Document Id provided");
                }
                RequestValidator.ValidateToken(token);

                // download document
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("DownloadDocument").Replace("{documentId}", documentId));
                if (this.language != null || password != null || userId != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language).Append("&");
                if (userId != null)
                    url.Append("userId=").Append(userId).Append("&");
                if (password != null)
                    url.Append("password=").Append(password).Append("&");
                url = url.Replace("&", "", url.Length - 1, 1);

                var stream = HttpHelper.SendDownloadRequest(url.ToString(), token, this.appId);
                return stream;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Download Record Document :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Download Record Document :"));
            }
        }
    }
}
