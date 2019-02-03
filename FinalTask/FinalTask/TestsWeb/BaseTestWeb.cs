using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTask.Framework;
using Serilog;
using System.IO;
using OpenQA.Selenium;
using NUnit.Framework.Interfaces;
using System.Collections;
using FinalTask.Framework.Web;

namespace FinalTask.TestsWeb
{
    public class BaseTestWeb
    {

        public IWebDriver driver;

        public static string baseURL = ConfigurationWeb.baseURL;

        [OneTimeSetUp]
        public void BaseOneTimeSetUp()
        {

            ConfigurationWeb.LoadConfiguration();
            ConfigurationWeb.currentRunScreenshotsFolder = ConfigurationWeb.CreateTemporatyScreenshotsFolder();
            Log.Logger = Logging.CreateLogger(Path.Combine(ConfigurationWeb.reportsFolder, "log" + DateTime.Now.ToString("yyyy-MM-dd HH-dd") + ".txt"));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            OneTimeSetUp();
        }

        public virtual void OneTimeSetUp()
        {

        }

        [SetUp]
        public void BaseSetUp()
        {

            Log.Information("Test case " + TestContext.CurrentContext.Test.MethodName + " is started");
            SetUp();
        }

        public virtual void SetUp()
        {

        }

        [TearDown]
        public void BaseTearDown()
        {

            Log.Information("Test case " + TestContext.CurrentContext.Test.MethodName + " is finished");
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Failed)
            {
                Log.Error("Test case " + TestContext.CurrentContext.Test.MethodName + " is failed with message " + TestContext.CurrentContext.Result.Message);
                Logging.SaveScreenshotToFolder(driver, ConfigurationWeb.currentRunScreenshotsFolder, TestContext.CurrentContext.Test.MethodName + " " + DateTime.Now.ToString("yyyy-MM-dd, hh-mm"));
            }
            TearDown();
        }

        public virtual void TearDown()
        {
            
        }

        [OneTimeTearDown]
        public void BaseOneTimeTearDown()
        {

            OneTimeTearDown();
        }

        public virtual void OneTimeTearDown()
        {

        }


    }
}
