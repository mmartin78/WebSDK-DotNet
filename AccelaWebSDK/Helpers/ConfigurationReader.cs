using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Resources;
using System.Reflection;

namespace Accela.Web.SDK
{
    public static class ConfigurationReader
    {
        static XmlDocument doc = new XmlDocument();
        static volatile bool isInitialized = false;

        public static void Initialize()
        {
            if (!isInitialized)
            {
                ResourceManager resourceManager = new ResourceManager("Accela.Web.SDK.Properties.Resources", typeof(Accela.Web.SDK.Properties.Resources).Assembly);
                doc.LoadXml(resourceManager.GetString("Accela"));
                isInitialized = true;
            }
        }

        public static string GetValue(string key)
        {
            XmlNodeList nodes = doc.GetElementsByTagName(key);
            if (nodes != null && nodes.Count > 0)
                return nodes[0].InnerText;
            else
                return null;
        }
    }
}
