using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanLadder.Utilities;

namespace UrbanLadder.PageObjects
{
    internal class ApplyJobPage
    {
        IWebDriver driver;
        public ApplyJobPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "//div[@class='css-15mn9qb']//button[text()='Apply Now']")]
        [CacheLookup]
        private IWebElement? ApplyNowBtn { get; set; }

        [FindsBy(How = How.Id, Using = "firstName")]
        [CacheLookup]
        private IWebElement? Firstname { get; set; }

        [FindsBy(How = How.Id, Using = "field-2")]
        [CacheLookup]
        private IWebElement? Lastname { get; set; }

        [FindsBy(How = How.Id, Using = "field-3")]
        [CacheLookup]
        private IWebElement? Email { get; set; }

        [FindsBy(How = How.Id, Using = "field-4")]
        [CacheLookup]
        private IWebElement? MobileNumber { get; set; }

        [FindsBy(How = How.Id, Using = "field-5")]
        [CacheLookup]
        private IWebElement? CurrentCTC { get; set; }

        [FindsBy(How = How.Id, Using = "field-6")]
        [CacheLookup]
        private IWebElement? ExpectedCTC { get; set; }

        [FindsBy(How = How.Id, Using = "field-7")]
        [CacheLookup]
        private IWebElement? Joining { get; set; }

        [FindsBy(How = How.Id, Using = "field-8")]
        [CacheLookup]
        private IWebElement? OpportunityClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='custom_9436']//option[@value='Job Portal']")]
        [CacheLookup]
        private IWebElement? OpportunitySelect { get; set; }

        [FindsBy(How = How.ClassName, Using = "css-10c38q4")]
        [CacheLookup]
        private IWebElement? submitBtn { get; set; }



        public void ClickApplyJobBtn()
        {
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div/div[1]/div/div[4]/div/div[1]/button"));
            CoreCodes.ScrollIntoView(driver, element);
            
            Thread.Sleep(2000);//wait not working
            element.Click();
        }

        public void ClickSubmitBtn(string firstname, string lastname, string email, string mobilenumber, string currentCTC, string expectedCTC, string joining)
        {

            Firstname?.SendKeys(firstname);
            Lastname?.SendKeys(lastname);
            Email?.SendKeys(email);
            MobileNumber?.SendKeys(mobilenumber);
            CurrentCTC?.SendKeys(currentCTC);
            ExpectedCTC?.SendKeys(expectedCTC);
            Joining?.SendKeys(joining);

            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromSeconds(5);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element does not found";

            //Thread.Sleep(3000);

        }
        public void ClickOpportunity()
        {
            OpportunityClick?.Click();
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromSeconds(5);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element does not found";
        }
        public void ClickOpportunitySelect()
        {
            OpportunitySelect?.Click();
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromSeconds(5);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element does not found";
        }

     }
}
