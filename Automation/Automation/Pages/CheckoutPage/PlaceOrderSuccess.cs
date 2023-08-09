using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Pages.CheckoutPage
{
    public class PlaceOrderSuccess
    {
        #region Selectors
        private readonly By _successMessage = By.CssSelector(".page-title h1");
        #endregion

        public string GetSuccessMessage()
        {
            return _successMessage.GetText();
        }
    }


}
