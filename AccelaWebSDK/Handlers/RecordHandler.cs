﻿using Accela.Web.SDK.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Accela.Web.SDK
{
    public class RecordHandler : BaseHandler, IRecord
    {
        public RecordHandler(string appId, string appSecret, ApplicationType appType, string language, IConfigurationProvider configManager)
            : base(appId, appSecret, appType, language, configManager)
        {
        }

        #region Related Records
        public List<RelatedRecord> GetRelatedRecords(string recordId, string token, string relationship = null, string fields = null)
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
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("GetRelatedRecords").Replace("{recordId}", recordId));
                if (this.language != null || relationship != null || fields != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language).Append("&");
                if (relationship != null)
                    url.Append("relationship=").Append(relationship).Append("&");
                if (fields != null)
                    url.Append("fields=").Append(fields).Append("&");
                url = url.Replace("&", "", url.Length-1, 1);

                RESTResponse response = HttpHelper.SendGetRequest(url.ToString(), token, this.appId);

                // create response
                List<RelatedRecord> records = new List<RelatedRecord>();
                records = (List<RelatedRecord>)HttpHelper.ConvertToSDKResponse(records, response);
                return records;
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
        public List<FeeSchedule> GetFeeScheduleForRecordType(string recordTypeId, string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrEmpty(recordTypeId))
                {
                    throw new Exception("Null Record Type Id provided");
                }

                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("GetRecordFeeSchedule").Replace("{id}", recordTypeId));
                RESTResponse response = HttpHelper.SendGetRequest(url.ToString(), token, this.appId);

                // create response
                List<FeeSchedule> feeSchedule = new List<FeeSchedule>();
                feeSchedule = (List<FeeSchedule>)HttpHelper.ConvertToSDKResponse(feeSchedule, response);
                return feeSchedule;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Fee Schedule :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Fee Schedule :"));
            }
        }

        public List<RecordFees> GetRecordFees(string recordId, string token, string fields = null, string status = null)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrEmpty(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }

                // get related record
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("GetRecordFees").Replace("{recordId}", recordId));
                if (this.language != null || fields != null || status != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language).Append("&");
                if (fields != null)
                    url.Append("fields=").Append(fields).Append("&");
                if (status != null)
                    url.Append("status=").Append(status).Append("&");
                url = url.Replace("&", "", url.Length-1, 1);

                RESTResponse response = HttpHelper.SendGetRequest(url.ToString(), token, this.appId);

                // create response
                List<RecordFees> recordFees = new List<RecordFees>();
                recordFees = (List<RecordFees>)HttpHelper.ConvertToSDKResponse(recordFees, response);
                return recordFees;
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
        public Record GetRecord(string recordId, string token, string expand = null)
        {
            try
            {
                // Validate
                //RequestValidator.ValidateToken(token);
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }

                // get record summary
                string url = apiUrl + ConfigurationReader.GetValue("GetRecord").Replace("{recordIds}", recordId);
                //if (this.language != null)
                //    url += "?lang=" + this.language;
                if (expand != null)
                    url += "?expand=" + expand;
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId, this.AgencyId, this.Environment);

                // create response
                List<Record> records = new List<Record>();
                records = (List<Record>)HttpHelper.ConvertToSDKResponse(records, response);
                if (records != null && records.Count > 0)
                    return records[0];
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

        public ResultDataPaged<Record> SearchRecords(string token, RecordFilter filter, string fields = null, int offset = -1, int limit = -1, string sortField = null, string sortOrder = null, string expand = null)
        {
            try
            {
                // validate
                //RequestValidator.ValidateToken(token);

                // create url
                StringBuilder url = new StringBuilder(apiUrl);
                url = url.Append(ConfigurationReader.GetValue("SearchRecords")).Replace("{limit}", limit.ToString()).Replace("{offset}", offset.ToString());
                if (fields != null)
                    url.Append("&fields=").Append(fields);
                if (this.language != null)
                    url.Append("&lang=").Append(this.language);
                if (sortField != null)
                    url.Append("&sort=").Append(sortField);
                if (sortOrder != null)
                    url.Append("&direction=").Append(sortOrder);
                if (expand != null)
                    url.Append("&expand=").Append(expand);

                RESTResponse response = HttpHelper.SendPostRequest(url.ToString(), filter, token, this.appId, this.AgencyId, this.Environment);
                PaginationInfo paginationInfo = null;

                // create response
                List<Record> records = new List<Record>();
                records = (List<Record>)HttpHelper.ConvertToSDKResponse(records, response, ref paginationInfo);
                ResultDataPaged<Record> results = new ResultDataPaged<Record> { Data = records, PageInfo = paginationInfo };
                return results;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Search Records :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Search Records :"));
            }
        }

        public ResultDataPaged<Record> GetRecords(string token, string filter, int offset = -1, int limit = -1)
        {
            try
            {
                // validate
                //RequestValidator.ValidateToken(token);

                // create url
                StringBuilder url = new StringBuilder(apiUrl);
                //if (this.appType == ApplicationType.Agency)
                //{
                    url = url.Append(ConfigurationReader.GetValue("GetRecords")).Replace("{limit}", limit.ToString()).Replace("{offset}", offset.ToString()); 
                //}
                //else if (this.appType == ApplicationType.Citizen)
                //{
                //    url = url.Append(ConfigurationReader.GetValue("GetMyRecords")).Replace("{limit}", limit.ToString()).Replace("{offset}", offset.ToString());
                //}
                if (!string.IsNullOrEmpty(filter))
                    url.Append("&").Append(filter);
                if (this.language != null)
                    url.Append("&lang=").Append(this.language);

                // get records
                RESTResponse response = HttpHelper.SendGetRequest(url.ToString(), token, this.appId, this.AgencyId, this.Environment);
                PaginationInfo paginationInfo = new PaginationInfo { hasmore = false, offset = offset, limit = limit };

                // create response
                //List<Record> records = new List<Record>();
                //records = (List<Record>)HttpHelper.ConvertToSDKResponse(records, response, ref paginationInfo);
                var records = HttpHelper.ConvertToSDKResponse<List<Record>>(response, ref paginationInfo);
                ResultDataPaged<Record> results = new ResultDataPaged<Record> { Data = records, PageInfo = paginationInfo };
                return results;
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

        public ResultDataPaged<Record> GetMyRecords(string token, string filter, int offset = -1, int limit = -1)
        {
            try
            {
                // validate
                RequestValidator.ValidateToken(token);

                // create url
                StringBuilder url = new StringBuilder(apiUrl);
                url = url.Append(ConfigurationReader.GetValue("GetMyRecords")).Replace("{limit}", limit.ToString()).Replace("{offset}", offset.ToString());
                
                if (!string.IsNullOrEmpty(filter))
                    url.Append("&").Append(filter);
                if (this.language != null)
                    url.Append("&lang=").Append(this.language);

                // get records
                RESTResponse response = HttpHelper.SendGetRequest(url.ToString(), token, this.appId, this.AgencyId, this.Environment);
                PaginationInfo paginationInfo = new PaginationInfo { hasmore = false, offset = offset, limit = limit };

                // create response
                //List<Record> records = new List<Record>();
                //records = (List<Record>)HttpHelper.ConvertToSDKResponse(records, response, ref paginationInfo);
                var records = HttpHelper.ConvertToSDKResponse<List<Record>>(response, ref paginationInfo);
                ResultDataPaged<Record> results = new ResultDataPaged<Record> { Data = records, PageInfo = paginationInfo };
                return results;
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

        public Record CreateRecordFinalize(Record record, string token)
        {
            return CreateRecordInternal(record, token, "final", null);
        }

        public Record CreateRecordInitialize(Record record, string token, string isFeeEstimate = null)
        {
            return CreateRecordInternal(record, token, "initial", isFeeEstimate);
        }

        public Record CreateRecord(Record record, string token)
        {
            return CreateRecordInternal(record, token, "", null);
        }

        public Record UpdateRecordDetail(Record record, string token) 
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (record == null)
                {
                    throw new Exception("Null request provided");
                }
                if (string.IsNullOrEmpty(record.id))
                    throw new Exception("Null record Id Provided");

                // Update 
                string url = apiUrl + ConfigurationReader.GetValue("UpdateRecord").Replace("{recordId}", record.id);
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendPutRequest(url, record, token, this.appId);
                return (Record)HttpHelper.ConvertToSDKResponse(record, response);
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

        public void DeleteRecord(string recordId, string token) { }

        #endregion

        #region Record Contacts
        public ResultDataPaged<Contact> GetRecordContacts(string recordId, string token, string fields = null, int offset = -1, int limit = -1)
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
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("GetRecordContacts").Replace("{recordIds}", recordId).Replace("{limit}", limit.ToString()).Replace("{offset}", offset.ToString()));
                if (this.language != null || fields != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language);
                if (this.language != null && fields != null)
                    url.Append("&");
                if (fields != null)
                    url.Append("fields=").Append(fields);

                RESTResponse response = HttpHelper.SendGetRequest(url.ToString(), token, this.appId);
                PaginationInfo paginationInfo = null;

                // create response
                List<Contact> contacts = new List<Contact>();
                contacts = (List<Contact>)HttpHelper.ConvertToSDKResponse(contacts, response);
                ResultDataPaged<Contact> results = new ResultDataPaged<Contact> { Data = contacts, PageInfo = paginationInfo };
                return results;
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

        public List<Result> CreateRecordContact(List<Contact> contacts, string recordId, string token, string fields = null)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                contacts = RequestValidator.ValidateContactsForCreate(contacts, recordId);
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }

                // Create 
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("CreateRecordContact").Replace("{recordId}", recordId));
                if (this.language != null || fields != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language);
                if (this.language != null && fields != null)
                    url.Append("&");
                if (fields != null)
                    url.Append("fields=").Append(fields);

                RESTResponse response = HttpHelper.SendPostRequest(url.ToString(), contacts, token, this.appId);

                // create response
                List<Result> result = new List<Result>();
                return (List<Result>)HttpHelper.ConvertToSDKResponse(result, response);

            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Create Record Contact :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Create Record Contact :"));
            }
        }

        public Contact UpdateRecordContact(Contact contact, string recordId, string token, string fields = null)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (contact == null)
                {
                    throw new Exception("Null contact provided");
                }
                if (string.IsNullOrEmpty(contact.id))
                    throw new Exception("Null contact Id provided");

                // Update 
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("UpdateRecordContact").Replace("{recordId}", recordId).Replace("{id}", contact.id));
                if (this.language != null || fields != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language);
                if (this.language != null && fields != null)
                    url.Append("&");
                if (fields != null)
                    url.Append("fields=").Append(fields);

                RESTResponse response = HttpHelper.SendPutRequest(url.ToString(), contact, token, this.appId);

                // create response
                return (Contact)HttpHelper.ConvertToSDKResponse(contact, response);
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Update Record Contact :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Update Record Contact :"));
            }
        }

        public void DeleteRecordContact(string contactId, string recordId, string token, string fields = null)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (String.IsNullOrWhiteSpace(contactId))
                {
                    throw new Exception("Null Contact Id provided");
                }

                // Update 
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("DeleteRecordContact").Replace("{recordId}", recordId).Replace("{ids}", contactId));
                if (this.language != null || fields != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language);
                if (this.language != null && fields != null)
                    url.Append("&");
                if (fields != null)
                    url.Append("fields=").Append(fields);

                RESTResponse response = HttpHelper.SendDeleteRequest(url.ToString(), token, appId);
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Delete Record Contact :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Delete Record Contact :"));
            }
        }
        #endregion

        #region Record Customfields
        public List<Dictionary<string, string>> GetRecordCustomFields(string recordId, string token)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                RequestValidator.ValidateToken(token);

                // get Custom Fields
                string url = apiUrl + ConfigurationReader.GetValue("GetRecordCustomFields").Replace("{recordIds}", recordId);
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId);

                // create response
                List<Dictionary<string, string>> customFieldList = new List<Dictionary<string, string>>();
                customFieldList = (List<Dictionary<string, string>>)HttpHelper.ConvertToSDKResponse(customFieldList, response);
                return customFieldList;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Custom Fields :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Custom Fields :"));
            }
        }

        public List<Dictionary<string, string>> UpdateRecordCustomFields(string recordId, List<Dictionary<string, string>> customFieldList, string token) // Doesn't work bug raised
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (customFieldList == null || customFieldList.Count == 0)
                {
                    throw new Exception("Null Custom Field List provided");
                }
                RequestValidator.ValidateToken(token);

                // update Custom Fields
                string url = apiUrl + ConfigurationReader.GetValue("UpdateRecordCustomFields").Replace("{recordId}", recordId);
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendPutRequest(url, customFieldList, token, this.appId, this.AgencyId, this.Environment);

                // create response
                customFieldList = (List<Dictionary<string, string>>)HttpHelper.ConvertToSDKResponse(customFieldList, response);
                return customFieldList;

            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Update Record Custom Fields :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Update Record Custom Fields :"));
            }
        }

        public List<CustomForm> GetRecordTypeCustomForms(string recordTypeId, string token)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordTypeId))
                {
                    throw new Exception("Null Record Id provided");
                }
                //RequestValidator.ValidateToken(token);

                // get Custom Fields
                string url = apiUrl + ConfigurationReader.GetValue("GetRecordTypeCustomForms").Replace("{id}", recordTypeId);
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId, this.AgencyId, this.Environment);

                // create response
                List<CustomForm> customFormsList = new List<CustomForm>();
                customFormsList = (List<CustomForm>)HttpHelper.ConvertToSDKResponse(customFormsList, response);
                return customFormsList;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Type Custom Forms :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Type Custom Forms :"));
            }
        }

        public List<FeeSchedule> GetRecordTypeFeeSchedules(string recordTypeId, string token)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordTypeId))
                {
                    throw new Exception("Null Record Id provided");
                }
                //RequestValidator.ValidateToken(token);

                // get Custom Fields
                string url = apiUrl + ConfigurationReader.GetValue("GetRecordTypeFeeSchedules").Replace("{id}", recordTypeId);
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId, this.AgencyId, this.Environment);

                // create response
                List<FeeSchedule> feeScheduleList = new List<FeeSchedule>();
                feeScheduleList = (List<FeeSchedule>)HttpHelper.ConvertToSDKResponse(feeScheduleList, response);
                return feeScheduleList;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Type Custom Forms :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Type Custom Forms :"));
            }
        }

        public List<RecordType> GetRecordTypes(string module, string token)
        {
            try
            {
                //RequestValidator.ValidateToken(token);

                // get Custom Fields
                string url = apiUrl + ConfigurationReader.GetValue("GetRecordTypes");
                if(module != null)
                    url += "?module=" + module;
                    
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId, this.AgencyId, this.Environment);

                // create response
                List<RecordType> recordTypes = new List<RecordType>();
                recordTypes = (List<RecordType>)HttpHelper.ConvertToSDKResponse(recordTypes, response);
                return recordTypes;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Types :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Types :"));
            }
        }

        public RecordTypeRequirements GetRecordTypeRequirements(string recordTypeId, string token)
        {
            try
            {
                //RequestValidator.ValidateToken(token);

                // get Custom Fields
                string url = apiUrl + ConfigurationReader.GetValue("DescribeRecordCreate");

                if (recordTypeId != null)
                    url += "?type=" + recordTypeId;
                
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId, this.AgencyId, this.Environment);

                // create response
                RecordTypeRequirements requirements = new RecordTypeRequirements();
                requirements = (RecordTypeRequirements)HttpHelper.ConvertToSDKResponse(requirements, response);
                return requirements;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Types :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Types :"));
            }
        }

        #endregion

        #region Record Documents
        public List<Document> GetRecordDocuments(string recordId, string token, string fields = null)
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
                string url = apiUrl + ConfigurationReader.GetValue("GetRecordDocuments").Replace("{recordId}", recordId);
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId);

                // create response
                List<Document> docList = new List<Document>();
                docList = (List<Document>)HttpHelper.ConvertToSDKResponse(docList, response);
                return docList;
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

        public string CreateRecordDocument(AttachmentInfo attachmentInfo, string recordId, string token, string group = null, string category = null, string password = null, string userId = null)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (attachmentInfo == null)
                {
                    throw new Exception("Please provide a valid attachment");
                }
                RequestValidator.ValidateToken(token);

                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("CreateRecordDocument").Replace("{recordId}", recordId));
                if (this.language != null || password != null || userId != null || group != null || category != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language).Append("&");
                if (userId != null)
                    url.Append("userId=").Append(userId).Append("&");
                if (password != null)
                    url.Append("password=").Append(password).Append("&");
                if (group != null)
                    url.Append("group=").Append(group).Append("&");
                if (category != null)
                    url.Append("category=").Append(category).Append("&");
                url = url.Replace("&", "", url.Length-1, 1);

                return HttpHelper.SendUploadRequest(attachmentInfo, url.ToString(), token, appId);
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

        public void DeleteRecordDocument(string documentId, string recordId, string token, string password = null, string userId = null)
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
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("DeleteRecordDocument").Replace("{recordId}", recordId).Replace("{documentIds}", documentId));
                if (this.language != null || password != null || userId != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language).Append("&");
                if (userId != null)
                    url.Append("userId=").Append(userId).Append("&");
                if (password != null)
                    url.Append("password=").Append(password).Append("&");
                url = url.Replace("&", "", url.Length-1, 1);

                RESTResponse response = HttpHelper.SendDeleteRequest(url.ToString(), token, this.appId);
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

        public List<DocumentType> GetRecordDocumentTypes(string recordId, string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }

                // get document types 
                string url = apiUrl + ConfigurationReader.GetValue("GetRecordDocumentTypes").Replace("{recordId}", recordId);
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId);

                // create response
                List<DocumentType> docTypes = new List<DocumentType>();
                docTypes = (List<DocumentType>)HttpHelper.ConvertToSDKResponse(docTypes, response);
                return docTypes;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Document Types :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Document Types :"));
            }
        }

        #endregion

        # region Record Workflows
        public List<WorkflowTask> GetWorkflowTasks(string recordId, string token, bool returnActiveOnly = false, string fields = null)
        {
            try
            {
                // validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                RequestValidator.ValidateToken(token);

                // get workflow tasks
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("GetWorkflowTasks").Replace("{recordId}", recordId));
                if (this.language != null || fields != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language);
                if (this.language != null && fields != null)
                    url.Append("&");
                if (fields != null)
                    url.Append("fields=").Append(fields);

                RESTResponse response = HttpHelper.SendGetRequest(url.ToString(), token, this.appId, this.AgencyId, this.Environment);

                // create response
                List<WorkflowTask> workflowTasks = new List<WorkflowTask>();
                workflowTasks = (List<WorkflowTask>)HttpHelper.ConvertToSDKResponse(workflowTasks, response);

                if (workflowTasks != null)
                {
                    if (returnActiveOnly)
                    {
                        var activeTask = workflowTasks.Where(w => w.isActive.Equals("true")).Select(w => w).SingleOrDefault();
                        if (activeTask == null)
                            return null;
                        return new List<WorkflowTask> { activeTask };
                    }
                    else
                        return workflowTasks;
                }
                return null;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Workflow tasks :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Workflow tasks :"));
            }
        }

        public WorkflowTask GetWorkflowTask(string recordId, string taskId, string token, string fields = null)
        {
            try
            {
                // validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (String.IsNullOrWhiteSpace(taskId))
                {
                    throw new Exception("Null task Id provided");
                }
                RequestValidator.ValidateToken(token);

                // get workflow tasks
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("GetWorkflowTask").Replace("{recordId}", recordId).Replace("{id}", taskId));
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
                WorkflowTask workflowTask = new WorkflowTask();
                workflowTask = (WorkflowTask)HttpHelper.ConvertToSDKResponse(workflowTask, response);
                return workflowTask;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Workflow tasks :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Workflow tasks :"));
            }
        }

        public WorkflowTask UpdateWorkflowTask(string recordId, string taskId, UpdateWorkflowTaskRequest workflowTask, string token, string fields = null)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (String.IsNullOrWhiteSpace(taskId))
                {
                    throw new Exception("Null Task Id provided");
                }
                if (workflowTask == null)
                {
                    throw new Exception("Null Workflow task provided");
                }
                RequestValidator.ValidateToken(token);

                // update workflow task
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("UpdateWorkflowTask").Replace("{recordId}", recordId).Replace("{id}", taskId));
                RESTResponse response = HttpHelper.SendPutRequest(url.ToString(), workflowTask, token, appId);

                // create response
                WorkflowTask updatedTask = new WorkflowTask();
                updatedTask = (WorkflowTask)HttpHelper.ConvertToSDKResponse(updatedTask, response);
                return updatedTask;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Update Workflow tasks :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Update Workflow tasks :"));
            }
        }
        #endregion

        #region Record Status
        public List<Status> GetRecordStatuses(string recordTypeId, string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrWhiteSpace(recordTypeId))
                {
                    throw new Exception("Null Record Type Id provided");
                }

                // get recrd status 
                string url = apiUrl + ConfigurationReader.GetValue("GetRecordStatuses").Replace("{id}", recordTypeId);
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId);

                // create response
                List<Status> statuses = new List<Status>();
                statuses = (List<Status>)HttpHelper.ConvertToSDKResponse(statuses, response);
                return statuses;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Status :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Status :"));
            }
        }
        #endregion

        #region Record CustomTables
        public List<CustomTables> GetRecordCustomTables(string recordId, string token)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                RequestValidator.ValidateToken(token);

                // get Custom Tables
                string url = apiUrl + ConfigurationReader.GetValue("GetRecordCustomTables").Replace("{recordId}", recordId);
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId);

                // create response
                List<CustomTables> customFieldList = new List<CustomTables>();
                customFieldList = (List<CustomTables>)HttpHelper.ConvertToSDKResponse(customFieldList, response);
                return customFieldList;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Custom Tables :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Custom Tables :"));
            }
        }

        public List<CustomTables> UpdateRecordCustomTables(string recordId, List<CustomTables> customTableList, string token) 
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (customTableList == null || customTableList.Count == 0)
                {
                    throw new Exception("Null Custom Table List provided");
                }
                RequestValidator.ValidateToken(token);

                // update Custom Tables
                string url = apiUrl + ConfigurationReader.GetValue("UpdateRecordCustomTables").Replace("{recordId}", recordId);
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendPutRequest(url, customTableList, token, this.appId);

                // create response
                customTableList = (List<CustomTables>)HttpHelper.ConvertToSDKResponse(customTableList, response);
                return customTableList;

            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Update Record Custom Tables :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Update Record Custom Tables :"));
            }
        }
        #endregion

        #region Record Address
        public List<Address> GetRecordAddresses(string recordId, string token, string isPrimary = null, string fields = null)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                RequestValidator.ValidateToken(token);

                // get addresses
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("GetRecordAddresses").Replace("{recordId}", recordId));
                if (this.language != null || isPrimary != null || fields != null)
                    url.Append("?");
                if (this.language != null)
                    url.Append("lang=").Append(this.language).Append("&");
                if (isPrimary != null)
                    url.Append("isPrimary=").Append(isPrimary).Append("&");
                if (fields != null)
                    url.Append("fields=").Append(fields).Append("&");
                url = url.Replace("&", "", url.Length - 1, 1);

                RESTResponse response = HttpHelper.SendGetRequest(url.ToString(), token, this.appId);

                // create response
                List<Address> addresses = new List<Address>();
                addresses = (List<Address>)HttpHelper.ConvertToSDKResponse(addresses, response);
                return addresses;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Record Addresses :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Record Addresses :"));
            }
        }

        public List<Result> CreateRecordAddresses(List<Address> addresses, string recordId, string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (addresses == null || addresses.Count == 0)
                {
                    throw new Exception("Null addresses provided");
                }

                // Create 
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("CreateRecordAddresses").Replace("{recordId}", recordId));
                if (this.language != null)
                    url.Append("?lang=").Append(this.language);

                RESTResponse response = HttpHelper.SendPostRequest(url.ToString(), addresses, token, this.appId);

                // create response
                List<Result> result = new List<Result>();
                return (List<Result>)HttpHelper.ConvertToSDKResponse(result, response);

            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Create Record Addresses :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Create Record Addresses :"));
            }
        }

        public Address UpdateRecordAddress(Address address, string recordId, string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (address == null)
                {
                    throw new Exception("Null address provided");
                }
                if (address.id == 0)
                    throw new Exception("Null address Id provided");

                // Update 
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("UpdateRecordAddress").Replace("{recordId}", recordId).Replace("{id}", address.id.ToString()));
                if (this.language != null)
                    url.Append("?lang=").Append(this.language);

                RESTResponse response = HttpHelper.SendPutRequest(url.ToString(), address, token, this.appId);

                // create response
                return (Address)HttpHelper.ConvertToSDKResponse(address, response);
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Update Record Address :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Update Record Address :"));
            }
        }

        public void DeleteRecordAddresses(string addressIds, string recordId, string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                if (String.IsNullOrWhiteSpace(recordId))
                {
                    throw new Exception("Null Record Id provided");
                }
                if (String.IsNullOrWhiteSpace(addressIds))
                {
                    throw new Exception("Null Contact Id provided");
                }

                // Update 
                StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("DeleteRecordAddresses").Replace("{recordId}", recordId).Replace("{ids}", addressIds));
                if (this.language != null)
                    url.Append("?lang=").Append(this.language);
                
                RESTResponse response = HttpHelper.SendDeleteRequest(url.ToString(), token, appId);
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Delete Record Addresses :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Delete Record Addresses :"));
            }
        }
        #endregion

        #region private methods
        private Record CreateRecordInternal(Record record, string token, string type, string isFeeEstimate)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);
                record.ValidateRecordForCreate();

                // Create
                StringBuilder url = new StringBuilder();
                switch (type)
                {
                    case "initial":
                        url.Append(apiUrl + ConfigurationReader.GetValue("CreatePartialRecord"));
                        if (this.language != null || isFeeEstimate != null)
                            url.Append("?");
                        if (this.language != null)
                            url.Append("lang=").Append(this.language);
                        if (this.language != null && isFeeEstimate != null)
                            url.Append("&");
                        if (isFeeEstimate != null)
                            url.Append("isFeeEstimate=").Append(isFeeEstimate);
                        break;
                    case "final":
                        url.Append(apiUrl + ConfigurationReader.GetValue("CreateFinalRecord").Replace("{recordId}", record.id));
                        if (this.language != null)
                            url.Append("?lang=").Append(this.language);
                        break;
                    case "":
                        url.Append(apiUrl + ConfigurationReader.GetValue("CreateRecord"));
                        if (this.language != null)
                            url.Append("?lang=").Append(this.language);
                        break;
                }


                RESTResponse response = null;
                if (type.Equals("final"))
                    response = HttpHelper.SendPostRequest(url.ToString(), new { type = record.type }, token, this.appId, this.AgencyId, this.Environment);
                else
                    response = HttpHelper.SendPostRequest(url.ToString(), record, token, this.appId, this.AgencyId, this.Environment);

                // Response
                Record responseRecord = new Record();
                responseRecord = (Record)HttpHelper.ConvertToSDKResponse(responseRecord, response);
                return responseRecord;
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
        #endregion
    }
}
