using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using System.Net;
using Accela.Web.SDK.Models;

namespace Accela.Web.SDK
{
    public class BaseHandler
    {
        protected static string apiUrl;
        protected string appId;
        protected string appSecret;
        protected ApplicationType appType = ApplicationType.None;
        protected string language;

        static BaseHandler()
        {
            ConfigurationReader.Initialize();
            apiUrl = ConfigurationReader.GetValue("APIUrl");

            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; }; // TODO remove this
        }

        public BaseHandler(string appId, string appSecret, ApplicationType appType)
        {
            this.appId = appId;
            this.appSecret = appSecret;
            this.appType = appType;
        }

        public BaseHandler(string appId, string appSecret, ApplicationType appType, string lang)
        {
            this.appId = appId;
            this.appSecret = appSecret;
            this.appType = appType;
            this.language = lang;
        }
    }
}
