
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanLadder.PageObjects;

namespace UrbanLadder.PageObjects
{
    internal class SearchProductListPage
    {
        IWebDriver driver;

        public SearchProductListPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.XPath, Using = "//*[@id=\"search-results\"]/div[3]/ul/li[1]/div/div[5]/a/div[1]/span")]
        public IWebElement SelectProduct { get; set; }

        public SearchProduct ClickSeclectedProduct()
        {
            SelectProduct.Click();
            return new SearchProduct(driver);
        }
    }
}
