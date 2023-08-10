using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using NsTestFrameworkUI.Helpers;
using Automation.Helpers;

namespace Automation.Pages.CheckoutPage
{
    public class CheckoutBillingPage
    {

        #region Selectors

        private readonly By _continueToCheckoutButton = By.Id("onepage-guest-register-button");

        private readonly By _firstNameField = By.Id("billing:firstname");
        private readonly By _middleNameField = By.Id("billing:middlename");
        private readonly By _lastNameField = By.Id("billing:lastname");
        private readonly By _emailAddressField = By.Id("billing:VALID_EMAIL");
        private readonly By _addressField = By.Id("billing:street1");
        private readonly By _cityField = By.Id("billing:city");
        private readonly By _postalCodeField = By.Id("billing:postcode");
        private readonly By _countryField = By.Id("billing:country_id");
        private readonly By _telephoneField = By.Id("billing:telephone");
        private readonly By _stateField = By.Id("billing:region_id");
        private readonly By _shipToDifferentAddressCheckbox = By.Id("billing:use_for_shipping_no");

        private readonly By _continueToNextStepButton = By.CssSelector("#billing-buttons-container button");
        

        private readonly By _waitSpinner = By.CssSelector("#billing-please-wait[style=\"\"]");

        

        #endregion

        public void ContinueToCheckoutAsGuest()
        {
            _continueToCheckoutButton.ActionClick();
        }

        public void InsertBillingInformation(BillingInformation info)
        {
            _firstNameField.ActionSendKeys(info.FirstName);
            _middleNameField.ActionSendKeys(info.MiddleName);
            _lastNameField.ActionSendKeys(info.LastName);
            _emailAddressField.ActionSendKeys(info.Email);
            _addressField.ActionSendKeys(info.Address);
            _cityField.ActionSendKeys(info.City);
            _postalCodeField.ActionSendKeys(info.PostalCode);
            _telephoneField.ActionSendKeys(info.Telephone);
            _countryField.SelectFromDropdownByText(info.Country);
            _stateField.SelectFromDropdownByText(info.State);
            _shipToDifferentAddressCheckbox.ActionClick();

            _continueToNextStepButton.ActionClick();

            _waitSpinner.WaitForSpinner();
        }
    }
}
