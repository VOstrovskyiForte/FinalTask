using FinalTask.Framework;
using FinalTask.Framework.Web;
using FinalTask.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
        }

        [Test]
        public void SubscribingToAlreadyUsedEmail()
        {
            homePage = Navigation.OpenHomePage(driver);

            Assert.That(homePage.SubscribeEmailField.Text, Is.EqualTo(""));

            string tempEmail = Generator.GetRandomEmail();
            string subscribeMessage = homePage.SubscribeWithEmail(tempEmail);

            Assert.That(subscribeMessage, Is.EqualTo("GOT IT, YOU'VE BEEN ADDED TO OUR EMAIL LIST."));

            homePage.SubscribeWithEmail(tempEmail, 300);           

            Assert.That(subscribeMessage, Is.EqualTo("dMEMBER EXISTS"));
        }

        [Test]
        [TestCaseSource(typeof(Data.SubscriptionEmails), "IncorrectEmails")]
        public void SubscribeWithIncorrectEmail(string email)
        {
            homePage = Navigation.OpenHomePage(driver);
            string subcribeMessage = homePage.SubscribeWithEmail(email);
            Assert.That(subcribeMessage.ToUpper(), Is.EqualTo("EMAIL ADDRESS IS INVALID"));
        }

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
