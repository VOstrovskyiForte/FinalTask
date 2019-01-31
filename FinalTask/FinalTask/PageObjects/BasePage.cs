﻿using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.PageObjects
{
    public class BasePage
    {

        private IWebDriver driver;
        public BasePage(IWebDriver driver) => this.driver = driver;

        //Header

        public IWebElement MainLogoImage => driver.FindElement(By.XPath("//img[@class='brand']"));
        public IWebElement QuickNewsLeftButton => driver.FindElement(By.XPath("//a[@href='#quick-news' and @data-slide='prev']"));
        public IWebElement QuickNewsRightButton => driver.FindElement(By.XPath("//a[@href='#quick-news' and @data-slide='next']"));

        public IWebElement MainMenuPanel => driver.FindElement(By.Id("main-menu"));
        public IWebElement MainMenuDemoItem => MainMenuPanel.FindElement(By.LinkText("Demo"));
        public IWebElement MainMenuPricingItem => MainMenuPanel.FindElement(By.LinkText("Pricing"));
        public IWebElement MainMenuFeaturesItem => MainMenuPanel.FindElement(By.XPath("//span[text()='Features']"));
        public IWebElement MainMenuProductItem => MainMenuPanel.FindElement(By.XPath("//span[text()='Product']"));
        public IWebElement MainMenuHostingItem => MainMenuPanel.FindElement(By.XPath("//span[text()='Hosting']"));
        public IWebElement MainMenuServicesItem => MainMenuPanel.FindElement(By.XPath("//span[text()='Services']"));
        public IWebElement MainMenuCompanyItem => MainMenuPanel.FindElement(By.XPath("//span[text()='Company']"));
        public IWebElement MainMenuLoginItem => MainMenuPanel.FindElement(By.XPath("Login"));

        //...other elements will be added if necessary

        //Footer

        public IWebElement SubscribePanel => driver.FindElement(By.XPath("//nav[contains(@class,'foot-nav-holder')]"));
        public IWebElement JoinNewsLetterLabel => SubscribePanel.FindElement(By.XPath("//strong[contains(text(),'Newsletter')]"));
        public IWebElement SubscribeEmailField => SubscribePanel.FindElement(By.Id("address"));
        public IWebElement SubscribeButton => SubscribePanel.FindElement(By.XPath("//input[@type='submit']"));
        public IWebElement SubscribeMessge => SubscribePanel.FindElement(By.XPath("//span[@id='result']/div"));

        public IWebElement BottomPanel => driver.FindElement(By.ClassName("footer-top"));
        public IWebElement FooterFacebookLink => BottomPanel.FindElement(By.XPath("//i[contains(@class,'fa-facebook')]"));
        public IWebElement FooterGooglePlusLink => BottomPanel.FindElement(By.XPath("//i[contains(@class,'fa-google-plus')]"));
        public IWebElement FooterTwitterLink => BottomPanel.FindElement(By.XPath("//i[contains(@class,'fa-twitter')]"));
        public IWebElement FooterLinkedInLink => BottomPanel.FindElement(By.XPath("//i[contains(@class,'fa-linkedin')]"));
        public IWebElement FooterInstagramLink => BottomPanel.FindElement(By.XPath("//i[contains(@class,'fa-instagram')]"));

        //... other elements will be added if necessary

        public string SubscribeWithEmail(string email)
        {
            SubscribeEmailField.SendKeys(email);
            SubscribeButton.Click();
            return SubscribeMessge.Text;
        }

        //... other methods will be added if necessary
    }
}
