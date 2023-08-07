using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class Homepage
    {
        #region Selectors

        private readonly By _homeLogoButton = By.CssSelector("a.logo");
        private readonly By _accountButton = By.CssSelector("a.skip-link.skip-account");
        private readonly By _toLoginButton = By.CssSelector("a[title=\"Log In\"]");
        private readonly By _toRegisterButton = By.CssSelector("a[title=\"Register\"]");
        private readonly By _privateSalesButton = By.CssSelector("img[alt =\"Shop Private Sales - Members Only\"]");

        #endregion

        public void GoToLoginPage()
        {
            _accountButton.ActionClick();
            _toLoginButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public void GoToRegisterPage()
        {
            _accountButton.ActionClick();
            _toRegisterButton.ActionClick();
        }

        public void GoToHomepage()
        {
            _homeLogoButton.ActionClick();
        }

        public void GoToPrivateSales()
        {
            _privateSalesButton.ActionClick();
        }

    }
}
