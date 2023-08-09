using Automation.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using OpenQA.Selenium.Support.UI;
using NsTestFrameworkUI.Pages;
using NsTestFrameworkUI.Helpers;

namespace Automation.Pages
{
    public class WishlistPage
    {

        #region Selectors

        private readonly By _wishlistProductNames = By.CssSelector("#wishlist-table tbody tr h3 a");
        private readonly By _wishlistRemoveButtons = By.CssSelector("#wishlist-table tbody tr td[class*=\"remove\"] a");
        private readonly By _confirmMessage = By.CssSelector("li.success-msg span");

        #endregion

        public string GetProductAddedToWishlistConfirmationMessage()
        {
            return _confirmMessage.GetText();
        }

        public bool IsProductInWishlist(string product)
        {
            var wishlistElementsName = _wishlistProductNames.GetElements();
            return wishlistElementsName.Any(i => i.Text.Equals(product.ToUpper()));

        }

        public void RemoveProductFromWishlist(string productName)
        {
            var wishlistElementsName = _wishlistProductNames.GetElements();
            var removeButtons = _wishlistRemoveButtons.GetElements();

            var elementToRemove = wishlistElementsName.First(i => i.Text.Equals(productName.ToUpper()));
            var index = wishlistElementsName.IndexOf(elementToRemove);

            removeButtons[index].Click();

            try
            {
                Browser.WebDriver.SwitchTo().Alert().Accept();
            }
            catch (NoAlertPresentException)
            {
                Console.WriteLine("No alert present at this time.");
            }

            WaitHelpers.WaitForDocumentReadyState();
        }

        public void RemoveAllProductsFromWishlist()
        {
            while (_wishlistRemoveButtons.GetElements().Count > 0)
            {
                _wishlistRemoveButtons.ActionClick();
                Browser.WebDriver.SwitchTo().Alert().Accept();
            }
        }
    }
}

