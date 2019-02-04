using FinalTask.PageObjects;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Framework.Web
{
    public class Data
    {

        public class SubscriptionEmails
        {
            public static IEnumerable IncorrectEmails
            {
                get
                {
                    if (ConfigurationWeb.testDataPath == null)
                        ConfigurationWeb.LoadConfiguration();
                    List<string> incorrectEmails = Data.ReadFromTextFileToList(Path.Combine(ConfigurationWeb.testDataPath, "IncorrectEmails.txt"));
                    foreach (string email in incorrectEmails)
                    {
                        yield return new TestCaseData(email);
                    }
                }
            }
        }

        public static List<string> ReadFromTextFileToList(string fileName)
        {
            List<string> result = new List<string>();
            var reader = new StreamReader(fileName);
            while (!reader.EndOfStream)
            {
                result.Add(reader.ReadLine());
            }
            return result;
        }

        
    }
}
