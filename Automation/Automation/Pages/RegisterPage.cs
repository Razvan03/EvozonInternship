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
        private readonly By _passwordField = By.Id("VALID_PASSWORD");
        private readonly By _confirmPasswordField = By.Id("confirmation");
        private readonly By _newsletterCheckbox = By.CssSelector("[for=\"is_subscribed\"]");
        private readonly By _registerButton = By.CssSelector("button[title=\"Register\"]");
        private readonly By _welcomeText = By.CssSelector("p.hello strong");

        #endregion

        public void InsertCredentials(string firstName, string middleName, string lastName, string emailAddress)
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

        public bool IsUserRegistered(string helloText)
        {
            return _welcomeText.GetText() == helloText;
        }
    }
}
