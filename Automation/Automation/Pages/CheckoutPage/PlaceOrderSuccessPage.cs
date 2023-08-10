using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Automation.Pages.CheckoutPage
{
    public class PlaceOrderSuccessPage
    {
        #region Selectors
        private readonly By _successMessage = By.CssSelector(".page-title h1");
        private readonly By _orderIdMessage = By.CssSelector(".sub-title + p");
        
        #endregion

        public string GetSuccessMessage()
        {
            return _successMessage.GetText();
        }

        public string GetOrderId()
        {
            var orderText = _orderIdMessage.GetText();
            var orderId = Regex.Match(orderText, @"(\d+)");
            return Regex.Match(_orderIdMessage.GetText(), @"(\d+)").Value;  // Ia doar cifrele dintr-un string
        }
    }


}
