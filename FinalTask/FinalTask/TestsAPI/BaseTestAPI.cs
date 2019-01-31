using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTask.Framework;

namespace FinalTask.TestsAPI
{
    public class BaseTestWeb
    {

        public static string baseURL = "https://jsonplaceholder.typicode.com/";

        [OneTimeSetUp]
        public void BaseOneTimeSetUp()
        {
            

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
