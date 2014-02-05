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
    public class AgencyHandler : BaseHandler, IAgency
    {
        public AgencyHandler(string appId, string appSecret, ApplicationType appType) : base(appId, appSecret, appType) { }

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

        public void GetAgencyLogo(string filePath, string token, string agencyName)
        {
            MemoryStream memoryStream = null;
            FileStream fileStream = null;
            try
            {
                // Validate
                if (String.IsNullOrWhiteSpace(filePath))
                {
                    throw new Exception("Null File Path provided");
                }
                if (String.IsNullOrWhiteSpace(agencyName))
                {
                    throw new Exception("Null Agency Name provided");
                }
                RequestValidator.ValidateToken(token);

                // get agency logo
                string url = apiUrl + ConfigurationReader.GetValue("GetAgencyLogo").Replace("{name}", agencyName);
                memoryStream = HttpHelper.SendDownloadRequest(url, memoryStream, token, this.appId);
                fileStream = new FileStream(filePath, FileMode.Create, FileAccess.Write);
                memoryStream.WriteTo(fileStream);
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Agency Logo :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Agency Logo :"));
            }
            finally
            {
                if (fileStream != null)
                    fileStream.Close();
                if (memoryStream != null)
                    memoryStream.Close();
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
