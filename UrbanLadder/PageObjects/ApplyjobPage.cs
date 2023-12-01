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
        public IWebElement? ApplyNowBtn { get; set; }

        [FindsBy(How = How.Id, Using = "firstName")]
        public IWebElement? Firstname { get; set; }

        [FindsBy(How = How.Id, Using = "field-2")]
        public IWebElement? Lastname { get; set; }

        [FindsBy(How = How.Id, Using = "field-3")]
        public IWebElement? Email { get; set; }

        [FindsBy(How = How.Id, Using = "field-4")]
        public IWebElement? MobileNumber { get; set; }

        [FindsBy(How = How.Id, Using = "field-5")]
        public IWebElement? CurrentCTC { get; set; }

        [FindsBy(How = How.Id, Using = "field-6")]
        public IWebElement? ExpectedCTC { get; set; }

        [FindsBy(How = How.Id, Using = "field-7")]
        public IWebElement? Joining { get; set; }

        [FindsBy(How = How.Id, Using = "field-8")]
        public IWebElement? OpportunityClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='custom_9436']//option[@value='Job Portal']")]
        public IWebElement? OpportunitySelect { get; set; }

        [FindsBy(How = How.ClassName, Using = "css-10c38q4")]
        public IWebElement? submitBtn { get; set; }



        public void ClickApplyJobBtn()
        {
            IWebElement element = driver.FindElement(By.XPath("//*[@id=\"__next\"]/div/div/div[1]/div/div[4]/div/div[1]/button"));
            CoreCodes.ScrollIntoView(driver, element);
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromSeconds(5);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element does not found";
            //Thread.Sleep(2000);
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
