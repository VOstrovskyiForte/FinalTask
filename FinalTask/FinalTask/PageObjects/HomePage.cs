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


        //private IWebDriver driver;
        public HomePage(IWebDriver driver): base(driver) => this.driver = driver;

        public List<IWebElement> LandingPageSections => driver.FindElements(By.XPath("//section")).ToList();
        public IWebElement AnimationSection => LandingPageSections[0];
        public IWebElement SoftwareSection => LandingPageSections[1];
        public IWebElement ModulesSection => LandingPageSections[2];
        public IWebElement OfferSection => LandingPageSections[3];
        public IWebElement BlogSection => LandingPageSections[4];
        public IWebElement ScriptSection => LandingPageSections[5];
        public IWebElement ServicesSection => LandingPageSections[6];

        public IWebElement SupportBlock => SoftwareSection.FindElement(By.XPath("//span[text()='SUPPORT']//parent::div"));
        public IWebElement OpenSourceBlock => SoftwareSection.FindElement(By.XPath("//span[text()='OPENSOURCE']//parent::div"));
        public IWebElement ResponsiveBlock => SoftwareSection.FindElement(By.XPath("//span[text()='RESPONSIVE']//parent::div"));

        //other elements to be added in necessary

    }



}
