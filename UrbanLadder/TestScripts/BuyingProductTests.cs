
using UrbanLadder.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanLadder.PageObjects;
using Serilog;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;

namespace UrbanLadder.TestScripts
{
    internal class BuyingProduct : CoreCodes
    {
        [Test]
        [Order(1), Category("Regression Testing")]
        public void SearchProductTest()
        {
            var homepage = new ULHomePage(driver);
            Log.Information("HomePage object Created");
            if (!driver.Url.Contains("https://www.urbanladder.com/"))
            {
                driver.Navigate().GoToUrl("https://www.urbanladder.com/");
            }
            

            string? currdir = Directory.GetParent(@"../../../")?.FullName;
            string? logfilepath = currdir + "/Logs/log_" +
                DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration()
            .WriteTo.Console()
            .WriteTo.File(logfilepath, rollingInterval: RollingInterval.Day)
            .CreateLogger();

            string currDir = Directory.GetParent(@"../../../").FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string sheetName = "SearchProduct";
            List<ExcelData> productDataList = ExcelUtilities.ReadExcelData(excelFilePath, sheetName);
            foreach (var productData in productDataList)
            {
                string productName = productData.ProductName;
                Log.Information("Searching Started");
                
                homepage.TypeSearchBox(productName);
                Log.Information("Searching Test Passed");
                TakeScreenShot();
            }


            var selectproductlist = new SearchProductListPage(driver);
            Log.Information("Created object for SearchProductListpage");
            selectproductlist.ClickSeclectedProduct();
            Log.Information("Product Selected");
            Thread.Sleep(5000);
            TakeScreenShot();

            //FluentWait
            DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(10);
            fluentwait.PollingInterval = TimeSpan.FromSeconds(10);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element does not found";

            List<string> nextTab = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);
            TakeScreenShot();

            var buyProduct = new SearchProduct(driver);
            Log.Information("Created object for SearchProduct");

            buyProduct.ClickCloseBtn();
            Log.Information("Clicked the Close button on the modal");
            Thread.Sleep(1000);


            buyProduct.SizeSelect();
            Log.Information("Selected the Size of the mattresses");
            Thread.Sleep(2000);
            
            buyProduct.ClickBuyNow();
            Log.Information("Clicked the add to cart button");
            TakeScreenShot();
            Thread.Sleep(1000);
            
            //FluentWait
            
            DefaultWait<IWebDriver> fluentwait1 = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromSeconds(5);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element does not found";


            var cartpage=new CartPage(driver);
            Log.Information("Created object for CartPage");

            cartpage.ClickQtyBtn();
            Log.Information("Clicked on the Quantity dropdown");
            //Thread.Sleep(3000);
            cartpage.ClickQtySelect();
            Log.Information("Selected the Quantity");
            //Thread.Sleep(1000);
            cartpage.ClickCheckoutBtn();
            Log.Information("Clicked Checkout Button");
            //Fluent
            DefaultWait<IWebDriver> fluentwait2 = new DefaultWait<IWebDriver>(driver);
            fluentwait.Timeout = TimeSpan.FromSeconds(5);
            fluentwait.PollingInterval = TimeSpan.FromSeconds(5);
            fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fluentwait.Message = "Element does not found";

            try
            {
                //string url = driver.GetCurrenturl();
                Assert.That(driver.Url.Contains("checkout"));

                Log.Information("Redirection Test passed");

                test = extent.CreateTest("Redirection Test");
                test.Pass("Redirection Test Success");

            }
            catch (AssertionException ex)
            {
                Log.Error($"Test failed for Redirection Failed. \n Exception: {ex.Message}");

                test = extent.CreateTest("Redirection Test");
                test.Fail("Redirection Test failed");
            }


            var addresspage=new AddressPage(driver);
            Log.Information("Created object for AddressPage");


            string? sheetName1 = "AddressPage";

            List<ExcelDataDetailsPage> excelDataList = ExcelUtilities.ReadExcelDataDetails(excelFilePath, sheetName1);

            foreach (var excelData in excelDataList)
            {
                string? email = excelData?.Email;
                string? pincode = excelData?.Pincode;
                string? address = excelData?.Address;
                string? firstname = excelData?.Firstname;
                string? lastname = excelData?.Lastname;
                string? mbno = excelData?.Mobilenumber;

                //  Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");
               addresspage.ClickSaveAndContiue(email, pincode, address, firstname, lastname, mbno);
                Log.Information("Values Assigned");
                //Thread.Sleep(2000);
            }





        }
    }
}
