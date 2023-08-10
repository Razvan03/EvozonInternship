using NsTestFrameworkUI.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;

namespace Automation.Pages.CheckoutPage
{
    public class CheckoutShippingMethodPage
    {

        #region Selectors

        private readonly By _freeShippingMethodCheckbox = By.CssSelector("[for=\"s_method_freeshipping_freeshipping\"]");
        private readonly By _shippingMethodCheckboxList = By.CssSelector(".sp-methods label");
        private readonly By _continueFromShippingButton = By.CssSelector("#shipping-method-buttons-container button");
        private readonly By _waitSpinner = By.CssSelector("#shipping-method-please-wait[style=\"\"]");

        #endregion

        public void SelectShippingMethod()
        {   
            _shippingMethodCheckboxList.GetElements().First().Click();

            _continueFromShippingButton.ActionClick();

            _waitSpinner.WaitForSpinner();
        }
    }
}

