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

        public string GetProductName()
        {
            return _productTitle.GetAttribute("innerText");
        }

        public void AddToCart()
        {
            _addToCartButton.ActionClick();
        }
    }
}
