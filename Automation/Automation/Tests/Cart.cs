using FluentAssertions;
using Automation.Helpers;
using MsTests.Helpers.Enums;

/*[assembly: Parallelize(Workers = 4,
    Scope = ExecutionScope.MethodLevel)]*/
namespace Automation.Tests
{
    [TestClass]
    public class Cart : BaseTest
    {
        public string productName;

        [TestMethod]
        public void AddtoCartConfigurableProductTest()
        {
            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.MEN, Subcategory.Men.TEES_KNITS_AND_POLOS);

            productName = "Chelsea Tee";

            Pages.ProductsPage.GoToProductDetailsPage(productName);

            Pages.ProductDetailsPage.SelectItemColor(Color.Black);
            Pages.ProductDetailsPage.SelectItemSize(ClothesSize.M);
            Pages.ProductDetailsPage.ChangeQuantity();
            Pages.ProductDetailsPage.AddProductToCart();

            Pages.CartPage.IsConfirmMessageTrue(productName).Should().BeTrue();
            Pages.CartPage.IsProductInCart(productName).Should().BeTrue();
        }

        [TestMethod]
        public void AddtoCartDigitalProductTest()
        {
            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.HOME_AND_DECOR, Subcategory.HomeAndDecor.BOOKS_AND_MUSIC);

            productName = "A Tale of Two Cities";

            Pages.ProductsPage.GoToProductDetailsPage(productName);

            Pages.ProductDetailsPage.ChangeQuantity();

            Pages.ProductDetailsPage.CheckDigitalProduct();

            Pages.ProductDetailsPage.AddProductToCart();

            Pages.CartPage.IsConfirmMessageTrue(productName).Should().BeTrue();

            Pages.CartPage.IsProductInCart(productName).Should().BeTrue();

        }

        [TestMethod]
        public void AddtoCartSimpleProductTest()
        {
            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.VIP, null);

            productName = "Broad St. Flapover Briefcase";

            Pages.ProductsPage.GoToProductDetailsPage(productName);

            Pages.ProductDetailsPage.ChangeQuantity();

            Pages.ProductDetailsPage.AddProductToCart();

            Pages.CartPage.IsConfirmMessageTrue(productName).Should().BeTrue();

            Pages.CartPage.IsProductInCart(productName).Should().BeTrue();
        }

        [TestCleanup]
        public void AddtoCartTestCleanup()
        {
            Pages.CartPage.RemoveProductFromCart(productName);
        }
    }
}
