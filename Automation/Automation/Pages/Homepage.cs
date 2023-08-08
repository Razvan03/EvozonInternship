using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

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
        private readonly By _homeDecor = By.CssSelector("li.level0.nav-4.parent a.level0.has-children");
        private readonly By _booksAndMusic = By.CssSelector("li.level0.nav-4.parent li.level1.nav-4-1.first a.level1");
        private readonly By _newProductsItems = By.CssSelector("a[class=\"product-image\"]");

        private readonly By _searchField = By.Id("search");
        private readonly By _searchButton = By.CssSelector(".search-button");

        #endregion

        public void SelectItemFromNewProducts(string productName)
        {
            var newProductsList = _newProductsItems.GetElements();
            var SelectedItem = newProductsList.First(i => i.GetAttribute("title") == productName);
            SelectedItem.Click();
        }

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

        public void GoToBooksAndMusic()
        {
            Browser.WebDriver.FindElement(_homeDecor).Hover();

            _booksAndMusic.ActionClick();

        }

        public void PerformSearchForKeyword(string keyword)
        {
            _searchField.ActionSendKeys(keyword);
            _searchButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }
    }
}
