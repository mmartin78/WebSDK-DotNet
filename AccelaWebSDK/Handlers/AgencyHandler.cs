using Accela.Web.SDK.Models;
using System;
using System.IO;
using System.Net;
using System.Collections.Generic;

namespace Accela.Web.SDK
{
    public class AgencyHandler : BaseHandler, IAgency
    {
        public AgencyHandler(string appId, string appSecret, ApplicationType appType, string language, IConfigurationProvider configManager)
            : base(appId, appSecret, appType, language, configManager)
        {
        }

        public List<Agency> GetAgencies(string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);

                // get agency
                string url = apiUrl + ConfigurationReader.GetValue("GetAgencies");
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId);

                // create response
                List<Agency> agency = new List<Agency>();
                agency = (List<Agency>)HttpHelper.ConvertToSDKResponse(agency, response);
                return agency;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Agency :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Agency :"));
            }
        }

        public Agency GetAgency(string token, string agencyName)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(agencyName))
                {
                    throw new Exception("Null Agency Name provided");
                }
                RequestValidator.ValidateToken(token);

                // get agency
                string url = apiUrl + ConfigurationReader.GetValue("GetAgency").Replace("{name}", agencyName);
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId);

                // create response
                Agency agency = new Agency();
                agency = (Agency)HttpHelper.ConvertToSDKResponse(agency, response);
                return agency;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Agency :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Agency :"));
            }
        }

        public Stream GetAgencyLogo(string token, string agencyName)
        {
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(agencyName))
                {
                    throw new Exception("Null Agency Name provided");
                }
                RequestValidator.ValidateToken(token);

                // get agency logo
                string url = apiUrl + ConfigurationReader.GetValue("GetAgencyLogo").Replace("{name}", agencyName);
                var stream = HttpHelper.SendDownloadRequest(url, token, this.appId);
                return stream.Result;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Agency Logo :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Agency Logo :"));
            }
        }

        //public Response GetRecordTypesForAgency(string module, string token, int limit = -1, int offset = -1)
        //{
        //    try
        //    {
        //        // Validate
        //        if (string.IsNullOrEmpty(module))
        //        {
        //            throw new Exception("Null module provided");
        //        }
        //        RequestValidator.ValidateToken(token);

        //        // get RecordTypes
        //        //ResponseDescribeRecordTypes responseDescribeRecordTypes = new ResponseDescribeRecordTypes();
        //        //string url = apiUrl + ConfigurationReader.GetValue("DescribeRecordTypes").Replace("{module}", module);
        //        //responseDescribeRecordTypes = (ResponseDescribeRecordTypes)HttpHelper.SendGetRequest(url, responseDescribeRecordTypes, token, appInfo);
        //        //return responseDescribeRecordTypes;
        //        return null;
        //    }
        //    catch (WebException webException)
        //    {
        //        throw new Exception(HttpHelper.HandleWebException(webException, "Error in Describe Record :"));
        //    }
        //    catch (Exception exception)
        //    {
        //        throw new Exception(HttpHelper.HandleException(exception, "Error in Describe Record :"));
        //    }
        //}
    }
}
