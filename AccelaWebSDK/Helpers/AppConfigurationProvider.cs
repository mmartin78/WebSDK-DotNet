using Accela.Web.SDK.Contracts;
using System.Configuration;

namespace Accela.Web.SDK
{
    public class AppConfigurationProvider : IConfigurationProvider
    {
        public string GetValue(string name)
        {
            return ConfigurationManager.AppSettings[name];
        }
    }
}
