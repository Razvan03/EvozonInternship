using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Automation.Pages.CheckoutPage
{
    public class CheckoutOrderReviewPage
    {

        #region Selectors

        private readonly By _userInfo = By.CssSelector("#billing-progress-opcheckout address");
        private readonly By _productAttributes = By.CssSelector("td .item-options dd");
        private readonly By _placeOrderButton = By.CssSelector("[title=\"Place Order\"]");
        private readonly By _productName = By.CssSelector("tr .product-name");
        private readonly By _waitSpinner = By.Id("review-please-wait");

        #endregion

        public BillingInformation GetBillingInformation()
        {
            var fullAddressText = _userInfo.GetText();
            var billingInformationList = fullAddressText.Split(new[] { "\r\n" }, StringSplitOptions.None).ToList();

            var names = billingInformationList[0].Split(' ');
            var cityStatePostal = billingInformationList[2].Split(',');
            var city = cityStatePostal[0].Trim();
            var state = cityStatePostal[1].Trim();
            var postalCode = cityStatePostal[2].Trim(); 
            var telephone = billingInformationList[4].Substring(3).Trim();

            return new BillingInformation
            {
                FirstName = names[0],
                MiddleName = names[1],
                LastName = names[2],
                Address = billingInformationList[1],
                City = city,
                State = state,
                PostalCode = postalCode,
                Country = billingInformationList[3],
                Telephone = telephone
            };

        }

        public List<string> GetProductAttributes()
        {
            var attributesElements = _productAttributes.GetElements();
            var attributesList = new List<string>();

            foreach (var element in attributesElements)
            {
                attributesList.Add(element.Text.Trim());
            }

            return attributesList;
        }

        public string GetProductName()
        {
            return _productName.GetText();
        }

        

        public void PlaceOrder()
        {
            _placeOrderButton.ActionClick();
            _waitSpinner.WaitForSpinner();
        }
    }
}
