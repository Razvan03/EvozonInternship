using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages.CheckoutPage
{
    public class CheckoutShippingPage
    {
        #region Selectors
        /*private readonly By _firstNameField = By.Id("shipping:firstname");
        private readonly By _middleNameField = By.Id("shipping:middlename");
        private readonly By _lastNameField = By.Id("shipping:lastname");
        private readonly By _addressField = By.Id("shipping:street1");
        private readonly By _cityField = By.Id("shipping:city");
        private readonly By _postalCodeField = By.Id("shipping:postcode");
        private readonly By _countryField = By.Id("shipping:country_id");
        private readonly By _telephoneField = By.Id("shipping:telephone");
        private readonly By _stateField = By.Id("shipping:region_id");*/
        private readonly By _waitSpinner = By.CssSelector("#shipping-please-wait[style=\"\"]");
        private readonly By _useBillingAddressCheckbox = By.CssSelector("[for=\"shipping:same_as_billing\"]");

        private readonly By _continueToNextStepButton = By.CssSelector("#shipping-buttons-container button");
        #endregion

        public void InsertShippingInformation()
        {
            /*_firstNameField.ActionSendKeys(Faker.Name.First());
            _middleNameField.ActionSendKeys(Faker.Name.Middle());
            _lastNameField.ActionSendKeys(Faker.Name.Last());
            _addressField.ActionSendKeys(Faker.Address.StreetAddress());
            _cityField.ActionSendKeys(Faker.Address.City());
            _postalCodeField.ActionSendKeys(Faker.Address.ZipCode());
            _telephoneField.ActionSendKeys(Faker.Phone.Number());
            _countryField.SelectFromDropdownByText("Romania");
            _stateField.SelectFromDropdownByText("Suceava");*/

            _useBillingAddressCheckbox.ActionClick();

            _continueToNextStepButton.ActionClick();

            _waitSpinner.WaitForSpinner();

        }
    }
}
