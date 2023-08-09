using MsTests.Helpers.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsTests.Helpers;
using NsTestFrameworkUI.Pages;

namespace Automation.Pages
{
    public class ProductsPage
    {
        #region Selectors

        private readonly By _subcategoryTitle = By.CssSelector(".category-title h1");
        private readonly By _productsList = By.CssSelector(".products-grid .product-image");

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
    }
}
