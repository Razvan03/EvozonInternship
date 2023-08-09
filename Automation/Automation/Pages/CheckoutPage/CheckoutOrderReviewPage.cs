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

        private readonly By _userName = By.CssSelector("#billing-progress-opcheckout address");
        private readonly By _userAddress = By.CssSelector("#billing-progress-opcheckout address :first-child");
        private readonly By _userCityStatePostal = By.CssSelector("#billing-progress-opcheckout address :nth-child(2)");
        private readonly By _userCountry = By.CssSelector("#billing-progress-opcheckout address :nth-child(3)");
        private readonly By _userPhoneNumber = By.CssSelector("#billing-progress-opcheckout address :nth-child(4)");
        private readonly By _productName = By.CssSelector("h3.product-name");
        private readonly By _productAttributes = By.CssSelector("td .item-options");
        private readonly By _productQty = By.CssSelector("[data-rwd-label=\"Qty\"]");

        #endregion

        public bool AreBillingDetailsTrue(BillingInformation info)
        {
            string[] cityStatePostal = _userCityStatePostal.GetAttribute("innerText").Split(',');

            if (_userName.GetText() != $"{info.FirstName} {info.MiddleName} {info.LastName}")
                return false;

            if(_userAddress.GetText() != info.Address)
                return false;

            if (cityStatePostal[0].Trim() != info.City)
                return false;

            if (cityStatePostal[1].Trim() != info.State)
                return false;

            if (cityStatePostal[2].Trim() != info.PostalCode)
                return false;
            if(_userCountry.GetText() != info.Country)
                return false;
            if (!(_userPhoneNumber.GetText().Contains(info.Telephone)))
                return false;
            return true;
        }

        public bool AreProductAttributesCorrect(string color,string size,string quantity)
        {
            var c = _productAttributes.GetElements().First(i => i.GetAttribute("innerText") == color);
            var s = _productAttributes.GetElements().First(i => i.GetAttribute("innerText") == size);
            var q = _productQty.GetText() == quantity;
            return _productAttributes.GetElements().Any(i => i.Text == color) &&
                _productAttributes.GetElements().Any(i => i.Text == size) &&
                _productQty.GetText()==quantity;
        }
    }
}
