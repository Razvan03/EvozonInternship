using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
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
            Browser.GetDriver().FindElement(_accountButton).Click();
            Browser.GetDriver().FindElement(_toLoginButton).Click();
            //WaitHelpers.ExplicitWait();
        }

        public void GoToRegisterPage()
        {
            Browser.GetDriver().FindElement(_accountButton).Click();
            Browser.GetDriver().FindElement(_toRegisterButton).Click();
        }

        public void GoToHomepage()
        {
            Browser.GetDriver().FindElement(_homeLogoButton).Click();
        }

        public void GoToPrivateSales()
        {
            Browser.GetDriver().FindElement(_privateSalesButton).Click();
        }

    }
}
