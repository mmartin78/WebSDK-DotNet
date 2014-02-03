using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK.Models;
using System.Net.Http;
using System.Net;
using System.Web;
using System.IO;

namespace Accela.Web.SDK
{
    public class DocumentHandler : BaseHandler, IDocument
    {
        public DocumentHandler(string appId, string appSecret, ApplicationType appType) : base(appId, appSecret, appType) { }

        public Document GetDocument(string documentId, string token) // TODO
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
                string url = apiUrl + ConfigurationReader.GetValue("GetDocument").Replace("{documentIds}", documentId);
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId);

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

        public void DownloadDocument(string filePath, string documentId, string token) // TODO 
        {
            MemoryStream memoryStream = null;
            FileStream fileStream = null;
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(documentId))
                {
                    throw new Exception("Null Document Id provided");
                }
                if (String.IsNullOrWhiteSpace(filePath))
                {
                    throw new Exception("Null File Path provided");
                }
                RequestValidator.ValidateToken(token);

                // download document
                string url = apiUrl + ConfigurationReader.GetValue("DownloadDocument").Replace("{documentId}", documentId);
                memoryStream = HttpHelper.SendDownloadRequest(url, memoryStream, token, this.appId);
                fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                memoryStream.WriteTo(fileStream);
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Download Record Document :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Download Record Document :"));
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
                if (memoryStream != null)
                    memoryStream.Close();
            }
        }
    }
}
