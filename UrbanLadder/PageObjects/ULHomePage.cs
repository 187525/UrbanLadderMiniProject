using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanLadder.Utilities;

namespace UrbanLadder.PageObjects
{
    internal class ULHomePage
    {
        IWebDriver driver;
        public ULHomePage(IWebDriver? driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "search")]
        [CacheLookup]
        private IWebElement? SearchElement { get; set; }

        [FindsBy(How = How.ClassName, Using = "header__topBar_logo")]
        [CacheLookup]
        private IWebElement? ULLogo { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Careers']")]
        [CacheLookup]
        private IWebElement? Careerlink { get; set; }

        

        public void SearchBoxClick()
        {
            SearchElement?.Click();
        }

        public void ULLogoClick()
        {
            ULLogo?.Click();
        }

        public string GetCurrentUrl()
        {
            return driver.Url;
        }

        public SearchProduct TypeSearchBox(string SearchText)
        {
            if (SearchElement == null)
            {
                throw new NoSuchElementException(nameof(SearchElement));
            }
            SearchElement.SendKeys(SearchText);
            SearchElement.SendKeys(Keys.Enter);
            return new SearchProduct(driver);

        }
        public void ClickCareerLink()
        {
            IWebElement element = driver.FindElement(By.XPath("//a[text()='Careers']"));
            CoreCodes.ScrollIntoView(driver, element);  
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()",element);
            Thread.Sleep(5000);
            
            
            //Careerlink.Click();
        }
        public void ClickContactUsPage()
        {
            IWebElement element = driver.FindElement(By.XPath("//a[text()='Contact Us']"));
            CoreCodes.ScrollIntoView(driver, element);
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].click()", element);
            Thread.Sleep(5000);
        }
    }
}
