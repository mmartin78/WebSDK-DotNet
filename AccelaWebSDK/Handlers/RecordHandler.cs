using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK;
using Accela.Web.SDK.Models;
using System.Net.Http;
using System.Net;
using System.Web;
using System.IO;

namespace Accela.Web.SDK
{
    public class RecordHandler : BaseHandler, IRecord
    {
        public RecordHandler(string appId, string appSecret, ApplicationType appType) : base(appId, appSecret, appType) { } 

        #region Related Records
        public Response GetRelatedRecords(string recordId, string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }

                // get related record
                Response response = new Response();
                string url = apiUrl + ConfigurationReader.GetValue("GetRelatedRecords").Replace("{recordId}", recordId);
                //response = (ResponseRelatedRecord)HttpHelper.SendGetRequest(url, response, token, appInfo);
                return response;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Related Record :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Related Record :"));
            }
        }
        #endregion

        #region Record Fees
        public Response GetRecordFees(string recordId, string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }

                // get related record
                Response response = new Response();
                string url = apiUrl + ConfigurationReader.GetValue("GetRecordFees").Replace("{recordId}", recordId);
                //response = (ResponseRecordFees)HttpHelper.SendGetRequest(url, response, token, appInfo);
                return response;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Fees :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Fees :"));
            }
        }
        #endregion

        #region Records
        public Record GetRecord(string recordId, string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }

                // get record summary
                List<Record> records = new List<Record>();
                string url = apiUrl + ConfigurationReader.GetValue("GetRecord").Replace("{recordIds}", recordId);
                records = (List<Record>)HttpHelper.SendGetRequest(url, token, this.appId, records);
                if (records != null && records.Count > 0)
                    return records[0];
                else
                    return null;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record :"));
            }
        }

        public Response GetRecords(string token, int offset = -1, int limit = -1, string filter = null)
        {
            try
            {
                RequestValidator.ValidateToken(token);

                Response responseGetRecords = new Response();
                string url = apiUrl;
                if (this.appType == ApplicationType.Agency)
                {
                    url += ConfigurationReader.GetValue("GetRecords"); 
                    if (!string.IsNullOrEmpty(filter))
                    {
                        url += "?" + filter;
                    }
                }
                else if (this.appType == ApplicationType.Citizen)
                {
                    url += ConfigurationReader.GetValue("GetMyRecords");
                }

                //responseGetRecords = (ResponseGetRecords)HttpHelper.SendGetRequest(url, responseGetRecords, token, appInfo);
                return responseGetRecords;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Records :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Records :"));
            }
        }

        public string CreateRecord(Record record, string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (record == null)
                {
                    throw new Exception("Null request provided");
                }

                // Build request
                //RequestCreateRecord requestCreateRecord = new RequestCreateRecord();
                //requestCreateRecord.createRecord = new CreateRecord
                //    {
                //        addresses = record.addresses,
                //        contacts = record.contacts,
                //        description = record.description,
                //        status = record.status,
                //        type = record.type,
                //        asis = record.asis
                //    };

                //string url = apiUrl + ConfigurationReader.GetValue("CreateRecord");
                //ResponseCreateRecord responseCreateRecord = new ResponseCreateRecord();
                //responseCreateRecord = (ResponseCreateRecord)HttpHelper.SendPostRequest(url, requestCreateRecord, responseCreateRecord, token, appInfo);
                //if (responseCreateRecord != null)
                //{
                //    return responseCreateRecord.recordId.id;
                //}
                //else
                return null;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Create Record :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Create Record :"));
            }
        }

        public void UpdateRecord(Record record, string token) // TODO Does Not work
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (record == null)
                {
                    throw new Exception("Null request provided");
                }

                // Buid request
                //RequestUpdateRecord requestCreateRecord = new RequestUpdateRecord();
                //requestCreateRecord.createRecord = new CreateRecord
                //{
                //    addresses = record.addresses,
                //    contacts = record.contacts,
                //    description = record.description,
                //    status = record.status,
                //    type = record.type,
                //    asis = record.asis,
                //};

                string url = apiUrl + ConfigurationReader.GetValue("UpdateRecord");
                // HttpHelper.SendPutRequest(url, requestCreateRecord, token, appInfo);
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Update Record :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Update Record :"));
            }
        }

        //public void DeleteRecord(Object recordObject, string recordId, string token) { }

        #endregion

        #region Record Contacts
        public Response SearchRecordContacts(string fullName, string contactTypeId, string token, int offset = -1, int limit = -1)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);

                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("SearchContact"));
                if (!String.IsNullOrWhiteSpace(contactTypeId))
                {
                    url.Append("?type=");
                    url.Append(contactTypeId);
                }
                if (!String.IsNullOrWhiteSpace(fullName))
                {
                    url.Append("&fullName=");
                    url.Append(fullName);
                }

                // get contacts
                Response responseGetRecordContacts = new Response();
                //responseGetRecordContacts = (ResponseSearchContacts)HttpHelper.SendGetRequest(url.ToString(), responseGetRecordContacts, token, appInfo);
                return responseGetRecordContacts;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Search Record Contacts :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Search Record Contacts :"));
            }
        }

        public Response GetContactTypes(string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);

                // get contacts
                Response responseGetContactTypes = new Response();
                string url = apiUrl + ConfigurationReader.GetValue("GetContactTypes");
                //responseGetContactTypes = (ResponseGetContactTypes)HttpHelper.SendGetRequest(url, responseGetContactTypes, token, appInfo);
                return responseGetContactTypes;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Contact Types :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Contact Types :"));
            }
        }

        public List<Contact> GetRecordContacts(string recordId, string token, int offset = -1, int limit = -1, string filter = null)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                RequestValidator.ValidateToken(token);

                // get contacts
                List<Contact> contacts = new List<Contact>();
                string url = apiUrl + ConfigurationReader.GetValue("GetRecordContacts").Replace("{recordIds}", recordId);
                return (List<Contact>)HttpHelper.SendGetRequest(url, token, this.appId, contacts);
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Contacts :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Contacts :"));
            }
        }
        #endregion

        #region Record Customfields
        public Response GetRecordCustomFields(string recordId, string token)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                RequestValidator.ValidateToken(token);

                // get ASIs
                Response responseGetRecordASIs = new Response();
                string url = apiUrl + ConfigurationReader.GetValue("GetRecordASIs").Replace("{recordIds}", recordId);
                //responseGetRecordASIs = (ResponseGetRecordASIs)HttpHelper.SendGetRequest(url, responseGetRecordASIs, token, appInfo);
                return responseGetRecordASIs;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record ASIs :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record ASIs :"));
            }
        }

        // Describe ASI
        public Response DescribeRecordCustomFields(string recordTypeId, string token)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordTypeId))
                {
                    throw new Exception("Null Record Type Id provided");
                }
                RequestValidator.ValidateToken(token);

                // get ASIs
                Response asis = new Response();
                string url = apiUrl + ConfigurationReader.GetValue("DescribeASI").Replace("{recordTypeId}", recordTypeId);
                //asis = (ResponseGetRecordASIs)HttpHelper.SendGetRequest(url, asis, token, appInfo);
                return asis;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Describe Record ASIs :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Describe Record ASIs :"));
            }
        }
        #endregion

        #region Record Documents
        public Response GetRecordDocuments(string recordId, string token)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                RequestValidator.ValidateToken(token);

                // get record documents
                //ResponseGetDocuments responseGetDocuments = new ResponseGetDocuments();
                //string url = apiUrl + ConfigurationReader.GetValue("GetRecordDocuments").Replace("{recordId}", recordId);
                //responseGetDocuments = (ResponseGetDocuments)HttpHelper.SendGetRequest(url, responseGetDocuments, token, appInfo);
                //return responseGetDocuments;
                return null;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Documents :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Documents :"));
            }
        }

        public Document GetRecordDocument(string documentId, string recordId, string token)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (String.IsNullOrWhiteSpace(documentId))
                {
                    throw new Exception("Null Document Id provided");
                }
                RequestValidator.ValidateToken(token);

                // get document
                //ResponseGetDocument responseGetDocument = new ResponseGetDocument();
                //string url = apiUrl + ConfigurationReader.GetValue("GetRecordDocument").Replace("{documentIds}", documentId);
                //responseGetDocument = (ResponseGetDocument)HttpHelper.SendGetRequest(url, responseGetDocument, token, appInfo);
                //if (responseGetDocument != null && responseGetDocument.result != null && responseGetDocument.result.Count > 0)
                //    return responseGetDocument.result[0];
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

        public Document CreateRecordDocument(string documentPath, string documentDescription, string recordId, string token) // TODO does not work
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (String.IsNullOrWhiteSpace(documentPath))
                {
                    throw new Exception("Please provide a valid path to upload your document");
                }
                RequestValidator.ValidateToken(token);

                //ResponseCreateRecordDocument responseCreateRecordDocument = new ResponseCreateRecordDocument();
                //string url = apiUrl + ConfigurationReader.GetValue("CreateRecordDocument").Replace("{recordId}", recordId);
                //responseCreateRecordDocument = (ResponseCreateRecordDocument)HttpHelper.SendUploadRequest(documentPath, documentDescription, url, responseCreateRecordDocument, token, appInfo);
                //return responseCreateRecordDocument;
                return null;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Create Record Documents :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Create Record Documents :"));
            }
        }

        public void DeleteRecordDocuments(string recordId, string token) // TODO test
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                RequestValidator.ValidateToken(token);

                // delete documents
                string url = apiUrl + ConfigurationReader.GetValue("DeleteRecordDocuments").Replace("{recordIds}", recordId);
                HttpHelper.SendDeleteRequest(url, token, this.appId);
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Delete Record Documents :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Delete Record Documents :"));
            }
        }

        public void DeleteRecordDocument(string documentId, string recordId, string token) // TODO test
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (String.IsNullOrWhiteSpace(documentId))
                {
                    throw new Exception("Null Document Id provided");
                }
                RequestValidator.ValidateToken(token);

                // delete document
                string url = apiUrl + ConfigurationReader.GetValue("DeleteRecordDocuments").Replace("{recordIds}", recordId).Replace("{documentId}", documentId);
                HttpHelper.SendDeleteRequest(url, token, this.appId);
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Delete Record Documents :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Delete Record Documents :"));
            }
        }

        public void DownloadRecordDocument(string filePath, string documentId, string recordId, string token)
        {
            MemoryStream memoryStream = null;
            FileStream fileStream = null;
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
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
                string url = apiUrl + ConfigurationReader.GetValue("DownloadRecordDocument").Replace("{documentId}", documentId);
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
        #endregion
    }
}
