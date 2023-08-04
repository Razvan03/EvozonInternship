using Automation.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using OpenQA.Selenium.Support.UI;

namespace Automation.Pages
{
    public class WishlistPage
    {

        #region Selectors
        private readonly By _wishlistProductNames = By.CssSelector("#wishlist-table tbody tr h3 a");
        private readonly By _wishlistRemoveButtons = By.CssSelector("#wishlist-table tbody tr td[class*=\"remove\"] a");
        private readonly By _briefcaseProduct = By.CssSelector("#wishlist-table tbody tr h3 a[title=\"Broad St. Flapover Briefcase\"]");
        #endregion

        WebDriverWait wait = new WebDriverWait(Browser.GetDriver(), TimeSpan.FromSeconds(10));

        public void removeBriefcaseFromWishlist(string product) //TO DO (NOT COMPLETED)
        {
            var wishlistElementsName = Browser.GetDriver().FindElements(_wishlistProductNames);
            var removeButtons = Browser.GetDriver().FindElements(_wishlistRemoveButtons);
            var element = wishlistElementsName.First(i => i.Text == product);
            var index = wishlistElementsName.IndexOf(element);
            removeButtons[index].Click();
            //wait.Until(Browser.GetDriver () => !Browser.GetDriver().FindElements(_briefcaseProduct)).Any();
            Browser.GetDriver().Quit(); 
        }
    }
}
