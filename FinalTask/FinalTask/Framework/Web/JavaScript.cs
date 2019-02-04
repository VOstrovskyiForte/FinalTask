using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Framework.Web
{
    public class JavaScript
    {


        public static void Click(IWebDriver driver, IWebElement webElement)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
            executor.ExecuteScript("arguments[0].click();", webElement);
        }
    }
}
