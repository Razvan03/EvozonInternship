using OpenQA.Selenium;
using MsTests.Helpers;
using NsTestFrameworkUI.Pages;

namespace Automation.Pages
{
    public class ProductsPage
    {
        #region Selectors

        private readonly By _subcategoryTitle = By.CssSelector(".category-title h1");
        private readonly By _productsList = By.CssSelector(".products-grid .product-image");
        private readonly By _addToWishlistButtonList = By.CssSelector(".link-wishlist");

        #endregion

        public bool IsSubcategoryTitleDisplayed()
        {
            return _subcategoryTitle.IsElementPresent();
        }

        public bool IsCorrectSubcategoryTitleDisplayed(Enum subcategory)
        {
            return _subcategoryTitle.GetText().Equals(subcategory.GetDescription());
        }

        public void GoToProductDetailsPage(string productName)
        {
            var product = _productsList.GetElements().FirstOrDefault(p => p.GetAttribute("title") == productName);
            if (product == null)
            {
                new ArgumentException($"No product with name: {productName}");
            }
            product.Click();
        }

        public void AddProductToWishlist(string productName)
        {
            var products = _productsList.GetElements();
            var product = products.FirstOrDefault(p => p.GetAttribute("title") == productName);
            if (product == null)
            {
                throw new ArgumentException($"No product with name: {productName}");
            }

            var index = products.IndexOf(product);
            _addToWishlistButtonList.GetElements()[index].Click();
        }

    }
}
