using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrbanLadder.PageObjects
{
    internal class CartPage
    {
        IWebDriver driver;

        public CartPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
            [FindsBy(How = How.XPath, Using = "//select[@id='select_0_quantity']")]
            [CacheLookup]
       
            private IWebElement QtyClick { get; set; }

            [FindsBy(How = How.XPath, Using = "//select[@id='select_0_quantity']/option[@value=2]")]
        [CacheLookup]

        private IWebElement QtySelect { get; set; }

        [FindsBy(How = How.XPath, Using = "(//button[@id='checkout-link'])[1]")]
        [CacheLookup]

        private IWebElement CheckOutBtn { get; set; }

        [FindsBy(How = How.ClassName, Using = "icofont-cross_thin")]
        [CacheLookup]

        private IWebElement RemoveFromCartBtn { get; set; }

        [FindsBy(How = How.XPath, Using = "//a[text()='Continue shopping']")]
        [CacheLookup]

        private IWebElement ContinueShoppingBtn { get; set; }

       public void ClickQtyBtn()
        {
            QtyClick.Click();
        }
        public void ClickQtySelect() 
        {
            QtySelect.Click();
        }

        public void ClickCheckoutBtn()
        {
            CheckOutBtn.Click();
        }
        public void ClickRemoveFromCartBtn()
        {
            RemoveFromCartBtn.Click();
        }

        public void ClickContinueShoppingBtn()
        {
            ContinueShoppingBtn.Click();
        }
    }
}
