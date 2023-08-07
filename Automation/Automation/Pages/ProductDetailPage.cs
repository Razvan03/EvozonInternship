using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class ProductDetailPage
    {
        private readonly By _productTitle = By.CssSelector("div.product-name h1");
        private readonly By _addToCartButton = By.CssSelector("button.button.btn-cart[onclick]");
        private readonly By _digitalItemCheckbox = By.Id("links_20");

        public string GetProductName()
        {
            return _productTitle.GetAttribute("innerText");
        }

        public void AddToCartSimpleProduct()
        {
            _addToCartButton.ActionClick();
        }

        public void AddToCartDigitalProduct()
        {
            _digitalItemCheckbox.ActionClick();
            _addToCartButton.ActionClick();
        }
    }
}
