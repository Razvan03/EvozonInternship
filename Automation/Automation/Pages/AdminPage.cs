using System.Net.WebSockets;
using Automation.Helpers;
using MsTests.Helpers;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace MsTests.Pages
{
    public class AdminPage
    {
        #region Selectors

        private readonly By _username = By.Id("username");
        private readonly By _password = By.Id("login");
        private readonly By _loginButton = By.CssSelector(".form-button");

        private readonly By _messagePopup = By.CssSelector(".message-popup-head a");
        private readonly By _customersCategory =  By.CssSelector("li:nth-child(4) a");
        private readonly By _manageCustomersSubCategory = By.CssSelector("li:nth-child(4) ul .level1 a");
        private readonly By _firstCustomerFromGrid = By.CssSelector(".grid tbody tr:nth-child(1)");
        private readonly By _deleteButton = By.CssSelector(".main-col-inner .content-header p button:nth-child(4) span span span");

        private readonly By _successMessage = By.CssSelector(".messages span");

        #endregion

        public void PerformAdminLogin()
        {
            Browser.GoTo("http://qa2magento.dev.evozon.com/admin");
            _username.ActionSendKeys(Constants.ADMIN_USERNAME);
            _password.ActionSendKeys(Constants.ADMIN_PASSWORD);
            _loginButton.ActionClick();
        }

        public void DeleteLastRegisteredCustomer()
        {
            _messagePopup.ActionClick();

            var action = new Actions(Browser.WebDriver);
            var accessoriesElement = _customersCategory.GetElements()[3];
            action.MoveToElement(accessoriesElement).Perform();

            _manageCustomersSubCategory.GetElements()[0].Click();
            _firstCustomerFromGrid.ActionClick();
            _deleteButton.GetElements()[0].Click();
        }

        public bool IsMessageDisplayed()
        {
            return _successMessage.IsElementPresent();
        }
    }
}
