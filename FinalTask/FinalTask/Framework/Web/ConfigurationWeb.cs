using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FinalTask.Framework.Web
{
    public class ConfigurationWeb
    {

        public static string baseURL;
        public static string reportsFolder;
        public static string browser;
        public static string environment;
        public static string screenshotsFolder;

        public static string currentRunScreenshotsFolder;
        public static string testDataPath;


        public static void LoadConfiguration()
        {

            string webConfigFilePath = Path.Combine(Folders.GetRootProjectFolder(), "webconfig.xml");
            if (!File.Exists(webConfigFilePath))
                try
                    {
                    File.Copy(Path.Combine(Folders.GetRootProjectFolder(), "templates", "webconfig.xml"), webConfigFilePath);
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
            baseURL = settings.SelectSingleNode("baseurl").InnerText;
            reportsFolder = settings.SelectSingleNode("reportsfolder").InnerText;
            screenshotsFolder = settings.SelectSingleNode("screenshotsfolder").InnerText;

            testDataPath = Path.Combine(Folders.GetRootProjectFolder(), "testdata/web");
        }

        
        public static string CreateTemporatyScreenshotsFolder()
        {
            string screenshotsFolderName = "Screenshots-" + DateTime.Now.ToString("yyyy-MM-dd,hh-mm");
            string fullPathToScreenshotsFolder = Path.Combine(ConfigurationWeb.screenshotsFolder, screenshotsFolderName);
            Directory.CreateDirectory(fullPathToScreenshotsFolder);
            return fullPathToScreenshotsFolder;
        }

    }
}
