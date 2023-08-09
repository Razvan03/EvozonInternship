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
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.MEN, Subcategory.Men.TEES_KNITS_AND_POLOS);

            productName = "Chelsea Tee";

            Pages.ProductsPage.GoToProductDetailsPage("Chelsea Tee");

            Pages.ProductDetailPage.SelectItemColor(Color.Black);
            Pages.ProductDetailPage.SelectItemSize(ClothesSize.M);
            Pages.ProductDetailPage.ChangeQty("2");
            Pages.ProductDetailPage.AddProductToCart();

            Pages.CartPage.IsConfirmMessageTrue(productName).Should().BeTrue();
            Pages.CartPage.IsProductInCart(productName).Should().BeTrue();
        }

        [TestMethod]
        public void AddtoCartDigitalProductTest()
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.HOME_AND_DECOR, Subcategory.HomeAndDecor.BOOKS_AND_MUSIC);

            productName = "A Tale of Two Cities";

            Pages.ProductsPage.GoToProductDetailsPage(productName);

            Pages.ProductDetailPage.ChangeQty("2");

            Pages.ProductDetailPage.CheckDigitalProduct();

            Pages.ProductDetailPage.AddProductToCart();

            Pages.CartPage.IsConfirmMessageTrue(productName).Should().BeTrue();

            Pages.CartPage.IsProductInCart(productName).Should().BeTrue();

        }

        [TestMethod]
        public void AddtoCartSimpleProductTest()
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.VIP, null);

            productName = "Broad St. Flapover Briefcase";

            Pages.ProductsPage.GoToProductDetailsPage(productName);

            Pages.ProductDetailPage.ChangeQty("2");

            Pages.ProductDetailPage.AddProductToCart();

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
