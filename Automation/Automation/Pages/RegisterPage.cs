using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using OpenQA.Selenium;

namespace Automation.Pages
{
    internal class RegisterPage
    {
        #region

        private readonly By _firstNameField = By.Id("firstname");
        private readonly By _middleNameField = By.Id("middlename");
        private readonly By _lastNameField = By.Id("lastname");
        private readonly By _emailField = By.Id("email_address");
        private readonly By _passwordField = By.Id("password");
        private readonly By _confirmPasswordField = By.Id("confirmation");
        private readonly By _newsletterCheckbox = By.CssSelector("[for=\"is_subscribed\"]");
        private readonly By _registerButton = By.CssSelector("button[title=\"Register\"]");
        private readonly By _welcomeText = By.CssSelector("p.hello strong");

        #endregion


    }
}
