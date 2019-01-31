using FinalTask.Framework;
using FinalTask.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.TestsWeb
{
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

            string tempEmail = Data.GetRandomEmail();
            string subscribeMessage = homePage.SubscribeWithEmail(tempEmail);

            Assert.That(subscribeMessage, Is.EqualTo("Got it, you've been added to our email list."));

            subscribeMessage = homePage.SubscribeWithEmail(tempEmail);

            Assert.That(subscribeMessage, Is.EqualTo("Member Exists"));
        }



        

    }
}
