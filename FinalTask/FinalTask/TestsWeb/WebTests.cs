﻿using FinalTask.Framework;
using FinalTask.Framework.Web;
using FinalTask.PageObjects;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinalTask.TestsWeb
{
    [AllureNUnit]
    [TestFixture]
    public class WebTests : BaseTestWeb
    {

        public HomePage homePage;       

        public override void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = Drivers.CreateDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);

            homePage = Navigation.OpenHomePage(driver);
            homePage.DisableMCPopup();
            homePage.CloseTopPopup();
        }

        [Category("WebUITests")]
        [Test]
        public void SubscribingToAlreadyUsedEmail()
        {           
            Assert.That(homePage.SubscribeEmailField.Text, Is.EqualTo(""));

            string tempEmail = Generator.GetRandomEmail();
            string subscribeMessage = homePage.SubscribeWithEmail(tempEmail);

            Assert.That(subscribeMessage, Is.EqualTo("GOT IT, YOU'VE BEEN ADDED TO OUR EMAIL LIST."));

            homePage.SubscribeWithEmail(tempEmail, 500);
            WebDriverWait subscribeMessageWait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            subscribeMessageWait.Until(p => homePage.SubscribeMessageLabel.Text != "GOT IT, YOU'VE BEEN ADDED TO OUR EMAIL LIST.");

            subscribeMessage = homePage.SubscribeMessageLabel.Text;

            Assert.That(subscribeMessage, Is.EqualTo("MEMBER EXISTS"));
        }

        [Category("WebUITests")]
        [Test]
        [TestCaseSource(typeof(Data.SubscriptionEmails), "IncorrectEmails")]
        public void SubscribeWithIncorrectEmail(string email)
        {
            homePage = Navigation.OpenHomePage(driver);
            string subcribeMessage = homePage.SubscribeWithEmail(email);
            Assert.That(subcribeMessage.ToUpper(), Is.EqualTo("EMAIL ADDRESS IS INVALID"));
        }

        [Category("WebUITests")]
        [TestCase("Shared Hosting", "Shared Hosting Plans", @"https://phptravels.com/shared-hosting/")]
        [TestCase("VPS Hosting", "Managed VPS Hosting", @"https://phptravels.com/vps-hosting/")]
        [TestCase("Dedicated Servers", "Managed Dedicated Servers", @"https://phptravels.com/dedicated-servers/")]
        public void TestHostingMenuLinks(string itemName, string title, string linkUrl)
        {
            homePage = Navigation.OpenHomePage(driver);
            homePage.MainMenuHostingItem.Click();
            homePage.MainMenuPanel.FindElement(By.LinkText(itemName)).Click();
            Assert.That(driver.Url, Is.EqualTo(linkUrl));
            Assert.That(driver.Title, Does.Contain(title));
        }

        public override void TearDown()
        {
            driver.Dispose();
        }

    }
}
