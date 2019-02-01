using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTask.Framework;
using Serilog;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace FinalTask.TestsAPI
{
    public class BaseTestWeb
    {

        public IWebDriver driver;

        public static string baseURL = "https://jsonplaceholder.typicode.com/";

        [OneTimeSetUp]
        public void BaseOneTimeSetUp()
        {
            

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
                Logging.SaveScreenshotToFolder(driver, ConfigurationWeb.reportsFolder, TestContext.CurrentContext.Test.MethodName + " " + DateTime.Now.ToString("yyyy-MM-dd, hh-mm"));
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
