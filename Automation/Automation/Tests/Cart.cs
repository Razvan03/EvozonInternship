﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;

/*[assembly: Parallelize(Workers = 4,
    Scope = ExecutionScope.MethodLevel)]*/
namespace Automation.Tests
{
    [TestClass]
    public class Cart : BaseTest
    {
        public string productAddedToCart;

        [TestMethod]
        public void AddtoCartConfigurableProductTest()
        {
            Pages.HomePage.GoToConfigurableProduct();

            Pages.ProductDetailPage.ChangeQty();

            productAddedToCart = Pages.ProductDetailPage.GetProductName();

            Pages.ProductDetailPage.AddToCartConfigurableProduct();

            Pages.CartPage.IsConfirmMessageTrue(productAddedToCart).Should().BeTrue();

            Pages.CartPage.IsProductInCart(productAddedToCart).Should().BeTrue();

        }

        [TestMethod]
        public void AddtoCartDigitalProductTest()
        {
            Pages.HomePage.GoToBooksAndMusic();

            Pages.CategoryPage.GoToDigitalProductDetailPage();

            productAddedToCart = Pages.ProductDetailPage.GetProductName();

            Pages.ProductDetailPage.ChangeQty();

            Pages.ProductDetailPage.AddToCartDigitalProduct();

            Pages.CartPage.IsConfirmMessageTrue(productAddedToCart).Should().BeTrue();

            Pages.CartPage.IsProductInCart(productAddedToCart).Should().BeTrue();

        }

        [TestMethod]
        public void AddtoCartSimpleProductTest()
        {
            Pages.HomePage.GoToPrivateSales();

            Pages.CategoryPage.GoToSimpleProductDetailPage();

            productAddedToCart = Pages.ProductDetailPage.GetProductName();

            Pages.ProductDetailPage.ChangeQty();

            Pages.ProductDetailPage.AddToCartSimpleProduct();

            Pages.CartPage.IsConfirmMessageTrue(productAddedToCart).Should().BeTrue();

            Pages.CartPage.IsProductInCart(productAddedToCart).Should().BeTrue();

        }

        [TestCleanup]
        public void AddtoCartTestCleanup()
        {
            Pages.CartPage.RemoveProductFromCart(productAddedToCart);
        }
    }
}
