using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class ListOfProductsByCategoryPage
    {

        #region Selectors

        #region Shop Private Sales

        private readonly By _briefcaseProductName = By.CssSelector("h2.product-name a[title=\"Broad St. Flapover Briefcase\"]");
        private readonly By _briefcaseToWishlistButton = By.CssSelector("a[title =\"Broad St. Flapover Briefcase\"] + div a.link-wishlist");
        private readonly By _briefcaseDetailPage = By.CssSelector("a[title=\"Broad St. Flapover Briefcase\"][class]");

        #endregion

        #region Home and Decor

        private readonly By _digitalProduct = By.CssSelector("a[title=\"A Tale of Two Cities\"][class]");


        #endregion
        
        #endregion


        public void AddProductToWishlist()
        {
            _briefcaseToWishlistButton.ActionClick();
        }

        public string GetProductName()
        {
            return _briefcaseProductName.GetText();
        }

        public void GoToSimpleProductDetailPage()
        {
            _briefcaseDetailPage.ActionClick();
        }

        public void GoToDigitalProductDetailPage()
        {
            _digitalProduct.ActionClick();
        }
    }
}
