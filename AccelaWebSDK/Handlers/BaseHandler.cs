using Accela.Web.SDK.Models;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;

namespace Accela.Web.SDK
{
    public class BaseHandler
    {
        protected string apiUrl;
        protected string appId;
        protected string appSecret;
        protected ApplicationType appType = ApplicationType.None;
        protected string language;

        public IConfigurationProvider ConfigProvider { get; protected set; }

        private BaseHandler(IConfigurationProvider configProvider)
        {
            ConfigurationReader.Initialize();

            this.ConfigProvider = configProvider;

            this.apiUrl = configProvider.GetValue("Accela.WebSDK.API.Url");

            ServicePointManager.ServerCertificateValidationCallback = delegate(object s, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors) { return true; }; // TODO remove this
        }

        public BaseHandler(string appId, string appSecret, ApplicationType appType, IConfigurationProvider configManager)
            : this(appId, appSecret, appType, string.Empty, configManager)
        {
        }

        public BaseHandler(string appId, string appSecret, ApplicationType appType, string lang, IConfigurationProvider configManager)
            : this(configManager)
        {
            this.appId = appId;
            this.appSecret = appSecret;
            this.appType = appType;
            if (!string.IsNullOrEmpty(lang))
                this.language = lang;
        }
    }
}
