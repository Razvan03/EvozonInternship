using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using NsTestFrameworkUI.Helpers;

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

        public void InsertCredentialsAndLogin()
        {
            _emailField.ActionSendKeys(Constants.email);
            _passwordField.ActionSendKeys(Constants.password);
            _loginButton.ActionClick();
        }
        public bool IsUserLoggedIn()
        {
            return _welcomeText.GetText() == Constants.myWelcomeText;
        }
    }
}
