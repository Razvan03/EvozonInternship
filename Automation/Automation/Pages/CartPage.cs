using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class CartPage
    {
        private readonly By _confirmMessage = By.CssSelector("li.success-msg span");
        private readonly By _productsList = By.CssSelector("h2[class] a");
        private readonly By _removeButtons = By.CssSelector(".a-center.product-cart-remove.last a");

        public bool IsConfirmMessageTrue(string productAdded)
        {
            return _confirmMessage.GetText().Contains(productAdded);
        }

        public bool IsProductInCart(string product)
        {
            var cartElementsName = _productsList.GetElements();
            return cartElementsName.Any(i => i.Text.Equals(product.ToUpper()));
        }

        public void RemoveProductFromCart(string product)
        {

            var cartElementsName = _productsList.GetElements();

            var removeButtons = _removeButtons.GetElements();

            var elementToRemove = cartElementsName.First(i => i.Text == product.ToUpper());
            var index = cartElementsName.IndexOf(elementToRemove);

            removeButtons[index].Click();

            WaitHelpers.WaitForDocumentReadyState();
        }
    }
}
