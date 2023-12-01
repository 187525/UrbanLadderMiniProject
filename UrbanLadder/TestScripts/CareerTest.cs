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
            Thread.Sleep(2000);

            List<string> nextTab = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);
            TakeScreenShot();


            var jobopeningspage =new JobOpeningsPage(driver);
            jobopeningspage.clicklocationselect();
            Thread.Sleep(2000);
            jobopeningspage.ClickSelectLocation();
            Thread.Sleep(2000);
            jobopeningspage.ClickViewJobBtn();
         
            Thread.Sleep(2000);

            List<string> nextTab1 = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);
            TakeScreenShot();

            var applyjobpage=new ApplyJobPage(driver);

            applyjobpage.ClickApplyJobBtn();
            Thread.Sleep(4000);

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

               
                applyjobpage.SubmitBtn(firstname,lastname,email,mobilenumber,cuurentCTC, expectedCTC,joining);
                Log.Information("Values Assigned");
                Thread.Sleep(2000);
            }





        }


    }
    }

