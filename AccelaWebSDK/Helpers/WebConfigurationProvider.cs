using Accela.Web.SDK.Contracts;
using System.Web.Configuration;

namespace Accela.Web.SDK.Helpers
{
    public class WebConfigurationProvider : IConfigurationProvider
    {
        public string GetValue(string name)
        {
            return WebConfigurationManager.AppSettings[name];
        }
    }
}
