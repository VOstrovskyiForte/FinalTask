using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTask.Framework;
using Serilog;
using System.IO;

namespace FinalTask.TestsWeb
{
    public class BaseTestWeb
    {

        [OneTimeSetUp]
        public void BaseOneTimeSetUp()
        {

            Log.Logger = Logging.CreateLogger(Path.Combine(@"C:\Reports\", "log" + DateTime.Now.ToString("yyyy-MM-dd HH-dd")));
            ConfigurationWeb.LoadConfiguration();
            OneTimeSetUp();
        }

        public virtual void OneTimeSetUp()
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
