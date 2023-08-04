using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class LoginPage
    {
        #region Selectors

        private readonly By _emailField = By.Id("email");
        private readonly By _passwordField = By.Id("pass");
        private readonly By _loginButton = By.Id("send2");
        private readonly By _welcomeText = By.CssSelector("p.hello strong");

        #endregion

        public void InsertCredentials()
        {
            Browser.GetDriver().FindElement(_emailField).SendKeys(Constants.email);
            Browser.GetDriver().FindElement(_passwordField).SendKeys(Constants.password);
        }
        public void SubmitLogin()
        {
            Browser.GetDriver().FindElement(_loginButton).Click();
        }

        public bool IsUserLoggedIn()
        {
            return Browser.GetDriver().FindElement(_welcomeText).Text == Constants.myWelcomeText;
        }
    }
}
