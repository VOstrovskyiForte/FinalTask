using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FinalTask.Framework.API
{
    class ConfigurationAPI
    {


        public static string baseURL;
        public static string environment;
        public static string reportsFolder;

        public static string testDataPath;

        public static void LoadConfiguration()
        {

            string webConfigFilePath = Path.Combine(Folders.GetRootProjectFolder(), "apiconfig.xml");
            if (!File.Exists(webConfigFilePath))
                try
                {
                    File.Copy(Path.Combine(Folders.GetRootProjectFolder(), "templates/apiconfig.xml"), webConfigFilePath);
                }
                catch
                {
                    throw new Exception("Config file is not found and cannot be loaded from templates");
                };
            XmlDocument webConfig = new XmlDocument();
            webConfig.Load(webConfigFilePath);
            XmlNode settings = webConfig.DocumentElement.SelectSingleNode("/settings");
            baseURL = settings.SelectSingleNode("baseurl").InnerText;
            environment = settings.SelectSingleNode("environment").InnerText;
            reportsFolder = settings.SelectSingleNode("reportsfolder").InnerText;

            testDataPath = Path.Combine(Folders.GetRootProjectFolder(), "testdata/api");
        }
    }
}
