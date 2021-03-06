﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinalTask.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace FinalTask.Framework.Web
{
    public class Drivers
    {

        public static IWebDriver CreateDriver(ChromeOptions chromeOptions = null, FirefoxOptions firefoxOptions = null)
        {
              if (ConfigurationWeb.browser == "chrome")
                    {
                        if (chromeOptions == null)
                            return new ChromeDriver();                        
                        else
                            return new ChromeDriver(chromeOptions);                        
                    } else
              if (ConfigurationWeb.browser == "firefox")
                    {
                        if (firefoxOptions == null)
                            return new FirefoxDriver();
                        else
                            return new FirefoxDriver(firefoxOptions);
                    } else                 
                    {
                        if (chromeOptions == null)
                            return new ChromeDriver();
                        else
                            return new ChromeDriver(chromeOptions);
                    }          
        }


    }
}
