using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class CheckoutPage
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

        private readonly By _continueToNextStep = By.CssSelector("#billing-buttons-container button");

        private readonly By _shippingMethodCheckbox = By.CssSelector("s_method_freeshipping_freeshipping");
        
        #endregion

        public void ContinueToCheckout()
        {
            _continueToCheckoutButton.ActionClick();
        }

        public void InsertBillingInfo()
        {
            _firstNameField.ActionSendKeys(Faker.Name.First());
            _middleNameField.ActionSendKeys(Faker.Name.Middle());
            _lastNameField.ActionSendKeys(Faker.Name.Last());
            _emailAddressField.ActionSendKeys(Faker.Internet.Email());
            _addressField.ActionSendKeys(Faker.Address.StreetAddress());
            _cityField.ActionSendKeys(Faker.Address.City());
            _postalCodeField.ActionSendKeys(Faker.Address.ZipCode());
            _telephoneField.ActionSendKeys(Faker.Phone.Number());
            _countryField.SelectFromDropdownByText("Romania");
            _stateField.SelectFromDropdownByText("Suceava");

            _shipToDifferentAddressCheckbox.ActionClick();
        }

        public void ContinueToNextStep()
        {
            _continueToNextStep.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void SelectShippingMethod()
        {
            _shippingMethodCheckbox.ActionClick();
        }
    }
}
