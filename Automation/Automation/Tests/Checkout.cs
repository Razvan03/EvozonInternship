using Automation.Helpers;
using MsTests.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Tests
{
    [TestClass]
    public class Checkout : BaseTest
    {
        [TestMethod]
        public void ProceedToCheckoutWithoutAccount()
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.MEN, Subcategory.Men.TEES_KNITS_AND_POLOS);
            Pages.ProductsPage.GoToProductDetailsPage("Chelsea Tee");

            Pages.ProductDetailsPage.ChangeQty();

            //productAddedToCart = Pages.ProductDetailsPage.GetProductName();

            Pages.ProductDetailsPage.SelectItemColor(Color.Black);
            Pages.ProductDetailsPage.SelectItemSize(ClothesSize.M);
            Pages.ProductDetailsPage.AddProductToCart();

            Pages.CartPage.ProceedToCheckout();

            Pages.CheckoutPage.ContinueToCheckout();

            Pages.CheckoutPage.InsertBillingInfo();

            Pages.CheckoutPage.ContinueToNextStep();

            Pages.CheckoutPage.SelectShippingMethod();

            Pages.CheckoutPage.ContinueToNextStep();

            Console.ReadKey();
        }
    }
}
