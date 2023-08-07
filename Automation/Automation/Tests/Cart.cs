using OpenQA.Selenium.Chrome;
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
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");
            driver.FindElement(By.CssSelector("h3.product-name a[title=\"Chelsea Tee\"]")).Click(); //CHELSEA TEE product from HomePage
            driver.FindElement(By.Id("swatch27")).Click(); //Color blue
            driver.FindElement(By.Id("swatch79")).Click(); //Size M
            driver.FindElement(By.Id("qty")).Clear();
            driver.FindElement(By.Id("qty")).SendKeys("2"); //Quantity
            var product = driver.FindElement(By.CssSelector("div.product-name h1")).GetAttribute("innerText"); //.Text didn't work
            driver.FindElement(By.CssSelector("button.button.btn-cart[onclick]")).Click(); //Add to cart button

            var message = driver.FindElement(By.CssSelector("li.success-msg span")).Text;

            message.Should().Contain(product);
            Assert.AreEqual(product, message);
            driver.Close();
        }

        [TestMethod]
        public void AddtoCartDigitalProductTest()
        {
            Pages.HomePage.GoToBooksAndMusic();

            Pages.CategoryPage.GoToDigitalProductDetailPage();

            productAddedToCart = Pages.ProductDetailPage.GetProductName();

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
