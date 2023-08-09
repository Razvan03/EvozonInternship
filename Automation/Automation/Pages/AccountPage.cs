using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using NsTestFrameworkUI.Pages;

namespace Automation.Pages
{
    public class AccountPage
    {
        #region Selectors

        private readonly By _welcomeText = By.CssSelector("p.hello strong");

        #endregion

        public bool IsUserLoggedIn()
        {
            return _welcomeText.GetText().Equals(Constants.LOGIN_HELLO_MESSAGE);
        }
    }
}
