using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UrbanLadder.PageObjects;
using UrbanLadder.Utilities;

namespace UrbanLadder.TestScripts
{
    
    internal class CareerTest : CoreCodes
    {
        [Test]
        [Order(1), Category("Regression Testing")]
        public void CareerJobTest()
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

            homepage.ClickCareerLink();
            TakeScreenShot();
            Thread.Sleep(2000);

            List<string> nextTab = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);
            TakeScreenShot();


            var jobopeningspage =new JobOpeningsPage(driver);
            jobopeningspage.clicklocationselect();
            TakeScreenShot();
            Thread.Sleep(2000);
            jobopeningspage.ClickSelectLocation();
            TakeScreenShot();
            Thread.Sleep(2000);
            jobopeningspage.ClickViewJobBtn();
            TakeScreenShot();

            Thread.Sleep(2000);

            List<string> nextTab1 = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);
            TakeScreenShot();

            try
            {
                
                Assert.That(driver.Url.Contains("jobs"));

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

            var applyjobpage=new ApplyJobPage(driver);

            applyjobpage.ClickApplyJobBtn();
            Log.Information("Clicked Applyjob Button");
            Thread.Sleep(6000);

            string currDir = Directory.GetParent(@"../../../").FullName;
            string? excelFilePath = currDir + "/TestData/InputData.xlsx";
            string? sheetName1 = "ApplyJobDetails";
            List<ExcelDataJob> excelDataList = ExcelUtilities.ReadExcelDataJob(excelFilePath, sheetName1);

            foreach (var excelData in excelDataList)
            {
                string? firstname = excelData?.Firstname;
                string? lastname = excelData?.Lastname;
                string? email = excelData?.Email;
                string? mobilenumber = excelData?.Mobilenumber;
                string? cuurentCTC = excelData?.CurrentCTC;
                string? expectedCTC = excelData?.ExpectedCTC;
                string? joining=excelData?.Joining;


                applyjobpage.ClickSubmitBtn(firstname,lastname,email,mobilenumber,cuurentCTC,expectedCTC, joining);
                Log.Information("Values Assigned");
                TakeScreenShot();
                Thread.Sleep(2000);
                //DefaultWait<IWebDriver> fluentwait = new DefaultWait<IWebDriver>(driver);
                //fluentwait.Timeout = TimeSpan.FromSeconds(5);
                //fluentwait.PollingInterval = TimeSpan.FromSeconds(5);
                //fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                //fluentwait.Message = "Element does not found";


                applyjobpage.ClickOpportunity();
                Log.Information("Opprotunity Clicked");
                TakeScreenShot();
                Thread.Sleep(3000);
                //DefaultWait<IWebDriver> fluentwait2 = new DefaultWait<IWebDriver>(driver);
                //fluentwait.Timeout = TimeSpan.FromSeconds(10);
                //fluentwait.PollingInterval = TimeSpan.FromSeconds(10);
                //fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                //fluentwait.Message = "Element does not found";

                applyjobpage.ClickOpportunitySelect();
                Log.Information("Opportunity selected");
                TakeScreenShot();
                Thread.Sleep(3000);
                //DefaultWait<IWebDriver> fluentwait3 = new DefaultWait<IWebDriver>(driver);
                //fluentwait.Timeout = TimeSpan.FromSeconds(10);
                //fluentwait.PollingInterval = TimeSpan.FromSeconds(10);
                //fluentwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
                //fluentwait.Message = "Element does not found";
            }





        }


    }
    }

