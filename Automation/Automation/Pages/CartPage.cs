using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class CartPage
    {
        private readonly By _confirmMessage = By.CssSelector("li.success-msg span");
        private readonly By _productsList = By.CssSelector("h2[class] a");
        private readonly By _removeButtons = By.CssSelector(".product-cart-remove.last a");
        private readonly By _proceedToCheckoutButton = By.CssSelector("li[class] .btn-checkout");

        public void goToSelectedProduct(string productName)
        {

        }

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
            _removeButtons.ClickBasedOnLabel(_productsList, product.ToUpper());

            WaitHelpers.WaitForDocumentReadyState();
        }

        public void ProceedToCheckout()
        {
            _proceedToCheckoutButton.ActionClick();
        }
    }
}
