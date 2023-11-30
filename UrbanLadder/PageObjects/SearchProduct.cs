using UrbanLadder.Utilities;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanLadder.PageObjects
{
    internal class SearchProduct : CoreCodes
    {
        IWebDriver driver;

        public SearchProduct(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.LinkText, Using = "Close")]
        public IWebElement CloseBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"productvariants\"]/div[2]/ul/li[1]/level/span")]
        public IWebElement Size { get; set; }
        //[FindsBy(How = How.Name, Using = "levelicon icofont-5inches")]
        //public IWebElement Thickness { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@type='submit']")]
        public IWebElement AddToCartButton { get; set; }

        public void ClickCloseBtn()
        {
            CloseBtn.Click();
        }

        public void SizeSelect()
        {
            //CoreCodes.ScrollIntoView(driver, Size);
            Size.Click();

        }
        
        public void ClickBuyNow()
        {

            CoreCodes.ScrollIntoView(driver, AddToCartButton);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", AddToCartButton);
            //AddToCartButton.Click();
        }
        public string GetCurrentUrl()
        {
            return driver.Url;
        }

    }
}