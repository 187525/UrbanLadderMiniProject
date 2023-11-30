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

            var jobopeningspage=new JobOpeningsPage(driver);
            jobopeningspage.Clicklocationselect();
            Thread.Sleep(2000);
            jobopeningspage.ClickSelectLocation();
            Thread.Sleep(2000);
            jobopeningspage.ClickViewJobBtn();
            Thread.Sleep(2000);
        }
        }
    }

