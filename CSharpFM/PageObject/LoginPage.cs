using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpFM.PageObject
{
    public class LoginPage
    {
        //driver.FindElement(By.LinkText("Job Support")).Click();
        //By.LinkText("Job Support"))
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            PageFactory.InitElements(driver, this);
        }

        //Page object Factory

        [FindsBy(How = How.Id, Using = "rego")]
        private IWebElement Register;

        [FindsBy(How = How.XPath, Using = "//input[@id='uname']")]
        private IWebElement Username;

        [FindsBy(How = How.Id, Using = "pwd")]
        private IWebElement password;

        [FindsBy(How = How.Id, Using = "psw-repeat")]
        private IWebElement password1;

        [FindsBy(How = How.ClassName, Using = "signupbtn")]
        private IWebElement signup;

        //Login
        //[FindsBy(How = How.Id, Using = "worrior_username")]
        //private IWebElement Login1;

        //[FindsBy(How = How.Id, Using = "worrior_pwd")]
        //private IWebElement pass2;

        [FindsBy(How = How.XPath, Using = "//h1[normalize-space()='Login with your warrior name']")]
        private IWebElement RegisterSuccesss;

        public IWebElement registerPage()

        {
            return RegisterSuccesss;
        }

        [FindsBy(How = How.Id, Using = "popup")]
        private IWebElement message;


        public IWebElement errormessage()
        {
            return message;
        }


        public void validlogin(string name, string pass, string pass1)
        {
            Register.Click();
            Username.SendKeys(name);
            password.SendKeys(pass);
            password1.SendKeys(pass1);
            signup.Click();
         

        }

        
        //public IWebElement getlogin()
        //{
        //    return login;
        //}


    }

}
