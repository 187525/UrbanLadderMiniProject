using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanLadder.Utilities;

namespace UrbanLadder.PageObjects
{
    internal class JobOpeningsPage
    {
        IWebDriver driver;
        public JobOpeningsPage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//div[@class='chakra-select__wrapper css-18t8j5a']//select[@name='location']")]
        public IWebElement? ClickLocation { get; set; }
        
        [FindsBy(How = How.XPath, Using = "//option[@value='chennai']")]
        public IWebElement? SelectLocation { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id=\"__next\"]/div/div/div[1]/div/div[2]/div[2]/div[2]/div/div/a")]
        public IWebElement? ViewJobBtn { get; set; }

        public void Clicklocationselect()
        {
            //IWebElement element = driver.FindElement(By.XPath("//select[@class='chakra-select css-1rhc2ow']"));
            //CoreCodes.ScrollIntoView(driver, element);
            //((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            //Thread.Sleep(5000);
            ClickLocation?.Click();
        }


        public void  ClickSelectLocation()
        {
            SelectLocation?.Click();
        }
        public void ClickViewJobBtn()
        {
            ViewJobBtn?.Click();    
        }
    }
}
