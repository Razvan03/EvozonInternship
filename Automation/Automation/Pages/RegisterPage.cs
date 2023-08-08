using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class RegisterPage
    {
        #region Selectors

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

        public static string firstName = Faker.Name.First();
        public static string middleName = Faker.Name.Middle();
        public static string lastName = Faker.Name.Last();
        public static string emailAddress = Faker.Internet.Email();
        public static string helloText = "Hello, " + firstName + " " + middleName + " " + lastName + "!";

        public void InsertCredentials()
        {
            _firstNameField.ActionSendKeys(firstName);
            _middleNameField.ActionSendKeys(middleName);
            _lastNameField.ActionSendKeys(lastName);
            _emailField.ActionSendKeys(emailAddress);
            _passwordField.ActionSendKeys(Constants.RANDOM_PASSWORD);
            _confirmPasswordField.ActionSendKeys(Constants.RANDOM_PASSWORD);
            _newsletterCheckbox.ActionClick();
        }

        public void SubmitRegister()
        {
            _registerButton.ActionClick();
        }

        public bool IsUserRegistered()
        {
            return _welcomeText.GetText() == helloText;
        }
    }
}
