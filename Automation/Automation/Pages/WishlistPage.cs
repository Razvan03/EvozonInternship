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
        private readonly By _briefcaseProduct = By.CssSelector("#wishlist-table tbody tr h3 a[title=\"Broad St. Flapover Briefcase\"]");
        private readonly By _confirmMessage = By.CssSelector("li.success-msg span");
        #endregion

        #region WebElements

        #endregion

        public string GetConfirmMessage()
        {
            return _confirmMessage.GetText();
        }

        public bool IsConfirmMessageTrue(string productAdded)
        {
            return _confirmMessage.GetText().ToUpper().Contains(productAdded);
        }

        public bool IsProductInWishlist(string product)
        {
            var wishlistElementsName = _wishlistProductNames.GetElements();
            return wishlistElementsName.Any(i => i.Text.Equals(product));

        }

        public void RemoveProductFromWishlist(string productName) 
        {
            
            var wishlistElementsName = _wishlistProductNames.GetElements();

            var removeButtons = _wishlistRemoveButtons.GetElements();

            var elementToRemove = wishlistElementsName.First(i => i.Text == productName);
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
    }
}
