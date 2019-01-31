using FinalTask.PageObjects;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Framework
{
    public static class Navigation
    {


        public static HomePage OpenHomePage(this IWebDriver driver)
        {
            driver.Navigate().GoToUrl(ConfigurationWeb.baseURL);
            return new HomePage(driver);
        }
    }
}
