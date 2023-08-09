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
    public class CheckoutPaymentPage
    {
        private readonly By _continueToNextStepButton = By.CssSelector("#payment-buttons-container button");
        private readonly By _waitSpinner = By.CssSelector("#payment-please-wait[style=\"\"]");

        public void SelectPayment()
        {
            _continueToNextStepButton.ActionClick();
            _waitSpinner.WaitForSpinner();
        }
    }
}
