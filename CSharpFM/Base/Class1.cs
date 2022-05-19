using System;
using NUnit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;
using System.Configuration;
using OpenQA.Selenium.Support.UI;
using AventStack.ExtentReports.Reporter;
using System.IO;
using AventStack.ExtentReports;
using NUnit.Framework.Interfaces;

namespace CSharpFM.Base
{
    public class Class1
    {

        ExtentReports extent;
        ExtentTest test;
        public IWebDriver driver;

        [OneTimeSetUp]

        public void Setup()
        {
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            String reportPath = projectDirectory + "//index.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
            extent.AddSystemInfo("Host Name", "Local Host");
            extent.AddSystemInfo("Environment", "QA");
            extent.AddSystemInfo("Team Lead", "Peter");


        }

        [SetUp]
        public void OpenBrowser()
        {
            test = extent.CreateTest(TestContext.CurrentContext.Test.Name);
            //Confirguration
            String browserName = ConfigurationManager.AppSettings["browser"];

            InitBrowser(browserName);

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://responsivefight.herokuapp.com/";


        }

        public IWebDriver getDriver()
        {
            return driver;
        }

        public void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    new WebDriverManager.DriverManager().SetUpDriver(new FirefoxConfig());
                    driver = new FirefoxDriver();
                    break;

                case "Chrome":
                    new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
                    driver = new ChromeDriver();
                    break;

                case "Edge":
                    new WebDriverManager.DriverManager().SetUpDriver(new EdgeConfig());
                    driver = new EdgeDriver();
                    break;




            }

        }

        //public static JsonReader getDataParser()
        //{
        //    return new JsonReader();
        //}


        //[TearDown]

        public void CloseBrower()
        {
            var status = TestContext.CurrentContext.Result.Outcome.Status;
            DateTime time = DateTime.Now;
            String fileName = "Screenshot_" + time.ToString("h_mm_ss") + ".png";

            if (status == TestStatus.Failed)
            {
                test.Fail("Test Failed", captureScreenShot(fileName));
                
            }
            else if (status == TestStatus.Passed)
            {

            }
            extent.Flush();

            driver.Quit();
        }

        public MediaEntityModelProvider captureScreenShot(String screenshotName)
        {

            ITakesScreenshot ts = (ITakesScreenshot)driver;
            var screenshot = ts.GetScreenshot().AsBase64EncodedString;

           return MediaEntityBuilder.CreateScreenCaptureFromBase64String(screenshot, screenshotName).Build();
            


        }
    




    }
}
