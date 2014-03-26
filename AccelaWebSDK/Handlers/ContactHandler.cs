using Accela.Web.SDK.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Accela.Web.SDK
{
    public class ContactHandler : BaseHandler, IContact
    {
        public ContactHandler(string appId, string appSecret, ApplicationType appType, string language, IConfigurationProvider configManager)
            : base(appId, appSecret, appType, language, configManager)
        {
        }

         public ResultDataPaged<Contact> SearchContacts(string token, ContactFilter filter, int offset = -1, int limit = -1)
         {
             try
             {
                 // Validate
                 RequestValidator.ValidateToken(token);

                 StringBuilder url = new StringBuilder(apiUrl).Append(ConfigurationReader.GetValue("SearchContact")).Replace("{limit}", limit.ToString()).Replace("{offset}", offset.ToString()); ;
                 if (this.language != null)
                     url.Append("&lang=").Append(this.language);

                 RESTResponse response = HttpHelper.SendPostRequest(url.ToString(), filter, token, this.appId);
                 PaginationInfo paginationInfo = null;

                 // create response
                 List<Contact> contacts = new List<Contact>();
                 contacts = (List<Contact>)HttpHelper.ConvertToSDKResponse(contacts, response, ref paginationInfo);
                 ResultDataPaged<Contact> results = new ResultDataPaged<Contact> { Data = contacts, PageInfo = paginationInfo };
                 return results;
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

         public List<ContactType> GetContactTypes(string token, string module)
         {
             try
             {
                 // Validate
                 RequestValidator.ValidateToken(token);

                 // get contacts
                 List<ContactType> contactTypes = new List<ContactType>();
                 StringBuilder url = new StringBuilder(apiUrl + ConfigurationReader.GetValue("GetContactTypes"));
                 if (this.language != null || !string.IsNullOrEmpty(module))
                     url.Append("?");
                 if (this.language != null)
                     url.Append("lang=").Append(this.language);
                 if (this.language != null && module != null)
                     url.Append("&");
                 if (!string.IsNullOrEmpty(module))
                     url.Append("modulename=").Append(module);

                 RESTResponse response = HttpHelper.SendGetRequest(url.ToString(), token, this.appId);

                 // create response
                 contactTypes = (List<ContactType>)HttpHelper.ConvertToSDKResponse(contactTypes, response);
                 return contactTypes;
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
    }
}
