using CSharpFM.Base;
using NUnit.Framework;
using System;
using NUnit;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Chrome;
using CSharpFM.PageObject;
using System.Threading;

namespace CSharpFM
{
    public class Tests : Class1
    {
        [Test,TestCaseSource("AddTestDataConfig")]
        //[TestCase("Sundar", "Password", "Password")]
        //[TestCase("Singh", "Password", "Password")]
        
        public void Test1(String username, string pass, string pass1)
        {
            LoginPage loginPage = new LoginPage(driver);
            //creating user account
            loginPage.validlogin(username,pass,pass1);
            Thread.Sleep(2000);
            TestContext.Progress.WriteLine(loginPage.errormessage().Text);
            TestContext.Progress.WriteLine(loginPage.registerPage().Text);




        }

        public static IEnumerable<TestCaseData> AddTestDataConfig()
        {

            // yield return new TestCaseData(getDataParser().extractData("username"), getDataParser().extractData("pass"), getDataParser().extractData("pass1"));
            yield return new TestCaseData("SundarP", "asdf1234", "asdf1234");
        }




    }
}