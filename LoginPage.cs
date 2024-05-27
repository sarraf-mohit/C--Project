using System;
using OpenQA.Selenium;

namespace LoginProject
{
    class LoginPage
    {
        private IWebDriver driver;

        public LoginPage(IWebDriver browser)
        {
            driver = browser;
        }

        private IWebElement AccountLogin => driver.FindElement(By.XPath("//a[@id=\"nav-link-accountList\"]"));

        private IWebElement UserName => driver.FindElement(By.XPath("//input[@id=\"ap_email\"]")); 

        private IWebElement BtnContinue => driver.FindElement(By.XPath("//input[@id=\"continue\"]"));

        private IWebElement Password => driver.FindElement(By.XPath("//input[@id=\"ap_password\"]"));

        private IWebElement BtnSignIn => driver.FindElement(By.XPath("//input[@id=\"signInSubmit\"]"));

        public void GoToLogin()
        {
            AccountLogin.Click();
        }

        public void LoginApplication(string username, string password) 
        {
            UserName.SendKeys(username);
            BtnContinue.Click();
            Password.SendKeys(password);
            BtnSignIn.Click();
        }
    }
}