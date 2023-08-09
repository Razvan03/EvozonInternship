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
        private readonly By _errorMessage = By.CssSelector(".error-msg");
        private readonly By _validationAdviceMessage = By.CssSelector(".validation-advice");

        #endregion

        public void InsertCredentialsAndLogin(string userEmail, string password)
        {
            _emailField.ActionSendKeys(userEmail);
            _passwordField.ActionSendKeys(password);
            _loginButton.ActionClick();
        }

        public bool IsErrorMessageDisplayed()
        {
            return _errorMessage.IsElementPresent();
        }

        public bool IsValidationAdviceDisplayed()
        {
            return _validationAdviceMessage.IsElementPresent();
        }
    }
}
