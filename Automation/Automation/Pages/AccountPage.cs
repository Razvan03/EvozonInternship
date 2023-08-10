using OpenQA.Selenium;
using NsTestFrameworkUI.Pages;
using Automation.Helpers;

namespace Automation.Pages
{
    public class AccountPage
    {
        #region Selectors

        private readonly By _welcomeText = By.CssSelector("p.hello strong");
        private readonly By _editBillingAddress = By.XPath("//*[@id=\"top\"]/body/div/div[1]/div[2]/div/div[2]/div[2]/div/div[5]/div[2]/div[1]/div/div[1]/a");
        private readonly By _firstNameField = By.Id("firstname"); 
        private readonly By _middleNameField = By.Id("middlename");
        private readonly By _lastNameField = By.Id("lastname");
        private readonly By _phoneField = By.CssSelector("[title=\"Telephone\"]");
        private readonly By _addressField = By.Id("street_1");
        private readonly By _cityField = By.CssSelector("[title=\"City\"]"); 
        private readonly By _stateField = By.Id("region_id");
        private readonly By _postalCodeField = By.Id("zip");
        private readonly By _countryField = By.Id("country");
        private readonly By _saveAddressButton = By.CssSelector("[title=\"Save Address\"]"); 
        #endregion

        public string IsUserLoggedIn()
        {
            return _welcomeText.GetText();
        }

        public void EditBillingAddress(BillingInformation info)
        {
            _editBillingAddress.ActionClick();

            _firstNameField.ActionSendKeys(info.FirstName);
            _middleNameField.ActionSendKeys(info.MiddleName);
            _lastNameField.ActionSendKeys(info.LastName);
            _addressField.ActionSendKeys(info.Address);
            _cityField.ActionSendKeys(info.City);
            _postalCodeField.ActionSendKeys(info.PostalCode);
            _phoneField.ActionSendKeys(info.Telephone);
            _countryField.SelectFromDropdownByText(info.Country);
            _stateField.SelectFromDropdownByText(info.State);

            _saveAddressButton.ActionClick();
        }
    }
}
