using OpenQA.Selenium;
using NsTestFrameworkUI.Pages;

namespace Automation.Pages
{
    public class AccountPage
    {
        #region Selectors

        private readonly By _welcomeText = By.CssSelector("p.hello strong");

        #endregion

        public string IsUserLoggedIn()
        {
            return _welcomeText.GetText();
        }
    }
}
