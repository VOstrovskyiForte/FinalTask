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
using System.IO;
using FinalTask.Framework.API;

namespace FinalTask.TestsAPI
{
    public class BaseTestAPI
    {

        public static string baseURL = ConfigurationAPI.baseURL;

        [OneTimeSetUp]
        public void BaseOneTimeSetUp()
        {

            ConfigurationAPI.LoadConfiguration();
            Log.Logger = Logging.CreateLogger(Path.Combine(ConfigurationAPI.reportsFolder, "log" + DateTime.Now.ToString("yyyy-MM-dd HH-dd") + ".txt"));
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
