﻿using Automation.Helpers;
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
            Pages.HomePage.SelectItemFromNewProducts("Chelsea Tee");

            Pages.ProductDetailPage.ChangeQty();

            //productAddedToCart = Pages.ProductDetailPage.GetProductName();

            Pages.ProductDetailPage.SelectItemColor(Color.Black);
            Pages.ProductDetailPage.SelectItemSize(ClothesSize.M);
            Pages.ProductDetailPage.AddProductToCart();

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