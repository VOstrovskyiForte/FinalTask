using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.PageObjects
{
    

    public class HomePage : BasePage
    {


        public IWebDriver driver;
        public HomePage(IWebDriver driver): base(driver) => this.driver = driver;


    }



}
