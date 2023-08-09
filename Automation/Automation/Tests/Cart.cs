using FluentAssertions;
using Automation.Helpers;
using MsTests.Helpers.Enums;


namespace Automation.Tests
{
    [TestClass]
    public class Cart : BaseTest
    {
        private TestContext testContext { get; set; }


        [DataRow("Chelsea Tee")]
        [TestMethod]
        public void AddtoCartConfigurableProductTest(string productName)
        {
            testContext.Properties["ProductName"] = productName;
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.MEN, Subcategory.Men.TEES_KNITS_AND_POLOS);

            Pages.ProductsPage.GoToProductDetailsPage(productName);

            Pages.ProductDetailPage.SelectItemColor(Color.Black);
            Pages.ProductDetailPage.SelectItemSize(ClothesSize.M);
            Pages.ProductDetailPage.ChangeQty();
            Pages.ProductDetailPage.AddProductToCart();

            Pages.CartPage.IsConfirmMessageTrue(productName).Should().BeTrue();
            Pages.CartPage.IsProductInCart(productName).Should().BeTrue();
        }

        [DataRow("A Tale of Two Cities")]
        [TestMethod]
        public void AddtoCartDigitalProductTest(string productName)
        {
            testContext.Properties["ProductName"] = productName;
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.HOME_AND_DECOR, Subcategory.HomeAndDecor.BOOKS_AND_MUSIC);

            Pages.ProductsPage.GoToProductDetailsPage(productName);

            Pages.ProductDetailPage.ChangeQty();

            Pages.ProductDetailPage.CheckDigitalProduct();

            Pages.ProductDetailPage.AddProductToCart();

            Pages.CartPage.IsConfirmMessageTrue(productName).Should().BeTrue();

            Pages.CartPage.IsProductInCart(productName).Should().BeTrue();

        }

        [DataRow("Broad St. Flapover Briefcase")]
        [TestMethod]
        public void AddtoCartSimpleProductTest(string productName)
        {
            testContext.Properties["ProductName"] = productName;
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.VIP, null);


            Pages.ProductsPage.GoToProductDetailsPage(productName);

            Pages.ProductDetailPage.ChangeQty();

            Pages.ProductDetailPage.AddProductToCart();

            Pages.CartPage.IsConfirmMessageTrue(productName).Should().BeTrue();

            Pages.CartPage.IsProductInCart(productName).Should().BeTrue();
        }

        [TestCleanup]
        public void AddtoCartTestCleanup()
        {
            string productName = (string)testContext.Properties["ProductName"];
            Pages.CartPage.RemoveProductFromCart(productName);
            base.After();
        }
    }
}
