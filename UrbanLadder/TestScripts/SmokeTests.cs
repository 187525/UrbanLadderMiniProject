using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanLadder.PageObjects;
using UrbanLadder.Utilities;

namespace UrbanLadder.TestScripts
{
    internal class SmokeTests:CoreCodes
    {
        
        [Test]
        [Order(1),Category("Smoke test")]
        public void LogoCheck()
        {
            var homepage=new ULHomePage(driver);
            homepage.ULLogoClick();

            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromSeconds(5);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element does not found";
            try
            {
                Assert.That(driver.Url.Equals("https://www.urbanladder.com/"));
                Log.Information("Logo Test passed");

                test = extent.CreateTest("Logo Test");
                test.Pass("Logo Test Success");
            }
            catch (AssertionException ex) 
            {
                Log.Error($"Test failed for Logo test. \n Exception: {ex.Message}");

                test = extent.CreateTest("logo Test");
                test.Fail("Logo Test failed");
            }
        }

        [Test]
        [Order(2),Category("SmokeTest")]
        public void FindAStoreLinkTest()
        {
            IWebElement? element = driver.FindElement(By.XPath("//a[text()=' Find a Store ']"));
            element.Click();
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(10);
            fluentwait.PollingInterval = TimeSpan.FromSeconds(10);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element does not found";
            try
            {
                Assert.That(driver.Url.Contains("store"));
                Log.Information(" Test passed");

                test = extent.CreateTest("Find a store link Test");
                test.Pass("Find a store link Test Success");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Find a store link test. \n Exception: {ex.Message}");

                test = extent.CreateTest("Find a store link Test");
                test.Fail("Find a store link Test failed");
            }
        }

        [Test]
        [Order(3),Category("smoke test")]
        public void ClickContactUs()
        {
            driver.Navigate().GoToUrl("https://www.urbanladder.com/");
            var homepage=new ULHomePage(driver);    
            homepage.ClickContactUsPage();
            var contact = new ContactUsPage(driver);
            contact.ClickRefundOption();
            Thread.Sleep(3000);
            try
            {
                Assert.That(driver.Url.Contains("refund-policy"));
                Log.Information(" Test passed");

                test = extent.CreateTest("Checking the refund policy Test");
                test.Pass("Checking the refund policy Success");
            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Checking the refund policy test. \n Exception: {ex.Message}");

                test = extent.CreateTest("Checking the refund policy Test");
                test.Fail("Checking the refund policy Test failed");
            }
        }

    }
}
