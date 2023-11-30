using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public IWebElement? SearchElement { get; set; }

        [FindsBy(How = How.Id, Using = "logo-with-gradient")]
        public IWebElement? ULLogo { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Careers']")]
        public IWebElement? Careerlink { get; set; }

        

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
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);",
                driver.FindElement(By.XPath("//a[text()='Careers")));
            
            Thread.Sleep(5000);
            
            
            //Careerlink.Click();
        }
    }
}
