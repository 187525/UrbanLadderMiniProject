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
    internal class AddressPage
    {
        IWebDriver driver;
        public AddressPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }
        [FindsBy(How = How.Id, Using = "order_email")]
        [CacheLookup]
        private IWebElement Email { get; set; }

        [FindsBy(How = How.Id, Using = "order_ship_address_attributes_zipcode")]
        [CacheLookup]
        private IWebElement PinCode { get; set; }


        [FindsBy(How = How.Id, Using = "order_ship_address_attributes_address1")]
        [CacheLookup]
        private IWebElement Address { get; set; }

        [FindsBy(How = How.Id, Using = "order_ship_address_attributes_firstname")]
        [CacheLookup]
        private IWebElement FirstName { get; set; }

        [FindsBy(How = How.Id, Using = "order_ship_address_attributes_lastname")]
        [CacheLookup]
        private IWebElement LastName { get; set; }

        [FindsBy(How = How.Id, Using = "order_ship_address_attributes_phone")]
        [CacheLookup]
        private IWebElement PhoneNumber { get; set; }

        [FindsBy(How = How.Id, Using = "address-form-submit")]
        [CacheLookup]
        private IWebElement SaveAndContinueBtn { get; set; }

        public void ClickSaveAndContiue(string email, string pincode, string address,
            string firstname, string lastname, string mobilenumber)
        {

            Email?.SendKeys(email);
            PinCode?.SendKeys(pincode);
            Address?.SendKeys(address);
            FirstName?.SendKeys(firstname);
            LastName?.SendKeys(lastname);
            PhoneNumber.SendKeys(mobilenumber);
            Thread.Sleep(3000);
            CoreCodes.ScrollIntoView(driver, SaveAndContinueBtn);
            //Thread.Sleep(3000);
            //SaveAndContinueBtn?.Click();

        }





    }
}
