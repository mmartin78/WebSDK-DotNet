using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK;
using Accela.Web.SDK.Models;
using System.Net;

namespace Accela.Web.SDK
{
    public class AddressHandler : BaseHandler, IAddress
    {
        public AddressHandler(string appId, string appSecret, ApplicationType appType) : base(appId, appSecret, appType) { }

        public AddressHandler(string appId, string appSecret, ApplicationType appType, string language) : base(appId, appSecret, appType, language) { } 

        public List<Country> GetCountries(string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);

                // get country 
                string url = apiUrl + ConfigurationReader.GetValue("GetCountries");
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId);

                // create response
                List<Country> countries = new List<Country>();
                countries = (List<Country>)HttpHelper.ConvertToSDKResponse(countries, response);
                return countries;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get Countries :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get Countries :"));
            }
        }

        public List<State> GetStates(string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);

                // get country 
                string url = apiUrl + ConfigurationReader.GetValue("GetStates");
                if (this.language != null)
                    url += "?lang=" + this.language;
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId);

                // create response
                List<State> states = new List<State>();
                states = (List<State>)HttpHelper.ConvertToSDKResponse(states, response);
                return states;
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get States :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get States :"));
            }
        }
    }
}
