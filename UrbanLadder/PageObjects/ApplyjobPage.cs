using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanLadder.PageObjects
{
    internal class ApplyJobPage
    {
        IWebDriver driver;
        public  ApplyJobPage(IWebDriver? driver)
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
        public IWebElement? ExpectedCTC{ get; set; }

        [FindsBy(How = How.Id, Using = "field-7")]
        public IWebElement? Joining { get; set; }

        [FindsBy(How = How.Id, Using = "field-8")]
        public IWebElement? OpportunityClick { get; set; }

        [FindsBy(How = How.XPath, Using = "//select[@name='custom_9436']//option[@value='Job Portal']")]
        public IWebElement? OpportunitySelect { get; set; }

        public void ClickApplyJobBtn()
        {
            ApplyNowBtn.Click();
        }







        public void SearchBoxClick()
        {
            SearchElement?.Click();
        }

        public void ULLogoClick()
        {
        }
}
