using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FinalTask.Framework
{
    class ConfigurationAPI
    {


        public static string browser;
        public static string environment;

        public static void LoadConfiguration()
        {

            string webConfigFilePath = Path.Combine(Folders.GetRootProjectFolder(), "webconfig.xml");
            if (!File.Exists(webConfigFilePath))
                try
                {
                    File.Copy(Path.Combine(Folders.GetRootProjectFolder(), "templates/webconfig.xml"), webConfigFilePath);
                }
                catch
                {
                    throw new Exception("Config file is not found and cannot be loaded from templates");
                };
            XmlDocument webConfig = new XmlDocument();
            webConfig.Load(webConfigFilePath);
            XmlNode settings = webConfig.DocumentElement.SelectSingleNode("/settings");
            browser = settings.SelectSingleNode("browser").InnerText;
            environment = settings.SelectSingleNode("environment").InnerText;
        }
    }
}
