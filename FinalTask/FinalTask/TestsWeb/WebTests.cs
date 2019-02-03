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
using System.Threading.Tasks;

namespace FinalTask.TestsWeb
{
    [TestFixture]
    public class WebTests : BaseTestWeb
    {

        public HomePage homePage;       

        [SetUp]
        public override void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = Drivers.CreateDriver(options);
        }

        [Test]
        public void VerifyMessageWhenSubscribingToAlreadyUsedEmail()
        {
            homePage = Navigation.OpenHomePage(driver);

            Assert.That(homePage.SubscribeEmailField, Is.Empty);

            string tempEmail = Generator.GetRandomEmail();
            string subscribeMessage = homePage.SubscribeWithEmail(tempEmail);

            Assert.That(subscribeMessage, Is.EqualTo("Got it, you've been added to our email list."));

            subscribeMessage = homePage.SubscribeWithEmail(tempEmail);

            Assert.That(subscribeMessage, Is.EqualTo("Member Exists"));
        }

        [Test]
        [TestCaseSource(typeof(Data.SubscriptionEmails), "IncorrectEmails")]
        public void SubscribeWithIncorrectEmail(string email)
        {
            homePage = Navigation.OpenHomePage(driver);
            string subcribeMessage = homePage.SubscribeWithEmail(email);
            Assert.That(subcribeMessage, Is.EqualTo("Email Address is Invalid"));
            homePage = (HomePage)homePage.RefreshPage();
        }

        [TestCase("Shared Hosting", "Shared Hosting Plans", @"https://phptravels.com/shared-hosting/")]
        [TestCase("VPS Hosting", "Managed VPS Hosting", @"https://phptravels.com/vps-hosting/")]
        [TestCase("Dedicated Servers", "Managed Dedicated Servers", @"https://phptravels.com/dedicated-servers/")]
        public void TestHostingMenuLinks(string itemName, string title, string linkUrl)
        {
            homePage = Navigation.OpenHomePage(driver);
            homePage.MainMenuPanel.FindElement(By.LinkText(itemName)).Click();
            Assert.That(driver.Url, Is.EqualTo(linkUrl));
            Assert.That(driver.Title, Does.Contain(title));
        }

        [TearDown]
        public override void TearDown()
        {
            driver.Dispose();
        }

    }
}
