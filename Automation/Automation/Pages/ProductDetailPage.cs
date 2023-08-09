using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsTests.Helpers.Enums;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class ProductDetailPage
    {
        private readonly By _productTitle = By.CssSelector("div.product-name h1");
        private readonly By _addToCartButton = By.CssSelector("button.button.btn-cart[onclick]");
        private readonly By _digitalItemCheckbox = By.Id("links_20");
        private readonly By _productQty = By.Id("qty");

        public string GetProductName()
        {
            return _productTitle.GetAttribute("innerText");
        }

        public void ChangeQty()
        {
            _productQty.ActionSendKeys("2");
        }

        public void AddProductToCart()
        {
            _addToCartButton.ActionClick();
        }

        public void AddToCartDigitalProduct()
        {
            _digitalItemCheckbox.ActionClick();
            _addToCartButton.ActionClick();
        }
        public void SelectItemColor(Color color)
        {
            Browser.WebDriver.FindElement(By.CssSelector($"#configurable_swatch_color [title=\"{color}\"] .swatch-label")).Click();
        }

        public void SelectItemSize(ClothesSize size)
        {
            Browser.WebDriver.FindElement(By.CssSelector($"#configurable_swatch_size [title=\"{size}\"] .swatch-label")).Click();
        }

    }
}
