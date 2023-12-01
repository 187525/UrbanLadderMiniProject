using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanLadder.PageObjects
{
    internal class ContactUsPage
    {
        IWebDriver driver;
        public ContactUsPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//a[@href=\"/help/refund-policy\"]")]
        public IWebElement? RefundOption { get; set; }

        public void ClickRefundOption()
        {
            RefundOption?.Click();
        }
    }
}
