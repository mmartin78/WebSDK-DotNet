using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Accela.Web.SDK.Models;
using Accela.Web.SDK;
using System.Net.Http;
using System.Net;
using System.Web;

namespace Accela.Web.SDK
{
    public class AuthHandler : BaseHandler, IAuth
    {
        public AuthHandler(string appId, string appSecret, ApplicationType appType) : base(appId, appSecret, appType) { }

        public Token GetToken(string redirectUrl, string code)
        {
            // Validate
            if (string.IsNullOrEmpty(redirectUrl))
                throw new Exception("Please provide a valid url to redirect on authentication");
            if (string.IsNullOrEmpty(code))
                throw new Exception("Please provide a valid code for authentication");

            // Build Request
            Token token = new Token();
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(ConfigurationReader.GetValue("TokenExchangeURL"));
            request.ContentType = "application/x-www-form-urlencoded";
            request.Headers.Add(ConfigurationReader.GetValue("HAppId"), this.appId);

            StringBuilder json = new StringBuilder(ConfigurationReader.GetValue("CodeExchangeRequest"));
            json = json.Replace("{appId}", this.appId);
            json = json.Replace("{appSecret}", this.appSecret);
            json = json.Replace("{redirectURI}", redirectUrl);
            json = json.Replace("{code}", code);

            // Get Token
            token = (Token)HttpHelper.SendPostRequest(request, json.ToString(), token);
            return token;
        }

        public UserProfile GetUserProfile(string token)
        {
            try
            {
                // Validate
                RequestValidator.ValidateToken(token);

                // get user profile
                string url = apiUrl + ConfigurationReader.GetValue("GetUserProfile");
                RESTResponse response = HttpHelper.SendGetRequest(url, token, this.appId);

                // create response
                UserProfile userProfile = new UserProfile();
                return (UserProfile)HttpHelper.ConvertToSDKResponse(userProfile, response);
            }
            catch (WebException webException)
            {
                throw new Exception(HttpHelper.HandleWebException(webException, "Error in Get User Profile :"));
            }
            catch (Exception exception)
            {
                throw new Exception(HttpHelper.HandleException(exception, "Error in Get User Profile :"));
            }
        }

        public void Login(string redirectUrl, string scope, string agencyName, string agencyEnvironment)
        {
            HttpContext.Current.Response.Redirect(GetAuthUrlForRedirect(agencyName, agencyEnvironment, redirectUrl, scope));
        }

        public CurrentUserProfile GetCurrentUserProfile(string redirectUrl)
        {
            // Validate
            if (string.IsNullOrEmpty(redirectUrl))
                throw new Exception("Please provide a valid url to redirect");

            string url = HttpContext.Current.Request.Url.ToString();
            const string codeString = "code=";

            if (url.Contains(codeString))
            {
                // exchange for token
                int codePosition = url.IndexOf(codeString);
                string[] info = url.Substring(codePosition + codeString.Length).Split('&');
                Token token = GetToken(redirectUrl, info[0]);

                // get user profile
                UserProfile userProfile = GetUserProfile(token.access_token);
                CurrentUserProfile currentUserProfile = new CurrentUserProfile
                {
                    UserProfile = userProfile,
                    AgencyName = info[1].Split('=')[1],
                    AgencyEnvironment = info[2].Split('=')[1],
                    Token = token
                };
                return currentUserProfile;
            }
            return null;
        }

        #region private methods
        private string GetAuthUrlForRedirect(string agencyName, string agencyEnvironment, string redirectUrl, string scope)
        {
            // Validate
            if (string.IsNullOrEmpty(redirectUrl))
                throw new Exception("Please provide a valid url to redirect on authentication");
            if (string.IsNullOrEmpty(scope))
                throw new Exception("Please provide a valid scope for authentication");

            // Build Auth Request
            StringBuilder requestString = new StringBuilder(ConfigurationReader.GetValue("AuthenticationRequest"));
            requestString = requestString.Replace("{authUrl}", ConfigurationReader.GetValue("AuthenticationURL"));
            requestString = requestString.Replace("{appId}", this.appId);
            requestString = requestString.Replace("{agency}", agencyName);
            requestString = requestString.Replace("{agencyEnvironment}", agencyEnvironment);
            requestString = requestString.Replace("{redirectURI}", redirectUrl);
            requestString = requestString.Replace("{scope}", scope);

            if (!string.IsNullOrEmpty(agencyName))
            {
                requestString = requestString.Append("&agency_name=" + agencyName);
            }
            if (!string.IsNullOrEmpty(agencyEnvironment))
            {
                requestString = requestString.Append("&environment=" + agencyEnvironment);
            }
            return requestString.ToString();
        }
        #endregion
    }
}
