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
        public string productAddedToCart;

        [TestMethod]
        public void AddtoCartConfigurableProductTest()
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.MEN, Subcategory.Men.TEES_KNITS_AND_POLOS);

            Pages.ProductsPage.GoToProductDetailsPage("Chelsea Tee");

            productAddedToCart = Pages.ProductDetailPage.GetProductName();

            Pages.ProductDetailPage.SelectItemColor(Color.Black);
            Pages.ProductDetailPage.SelectItemSize(ClothesSize.M);
            Pages.ProductDetailPage.ChangeQty();
            Pages.ProductDetailPage.AddProductToCart();

            Pages.CartPage.IsConfirmMessageTrue(productAddedToCart).Should().BeTrue();
            Pages.CartPage.IsProductInCart(productAddedToCart).Should().BeTrue();

        }

        [TestMethod]
        public void AddtoCartDigitalProductTest()
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.HOME_AND_DECOR, Subcategory.HomeAndDecor.BOOKS_AND_MUSIC);

            Pages.ProductsPage.GoToProductDetailsPage("A Tale of Two Cities");

            productAddedToCart = Pages.ProductDetailPage.GetProductName();

            Pages.ProductDetailPage.ChangeQty();

            Pages.ProductDetailPage.CheckDigitalProduct();

            Pages.ProductDetailPage.AddProductToCart();

            Pages.CartPage.IsConfirmMessageTrue(productAddedToCart).Should().BeTrue();

            Pages.CartPage.IsProductInCart(productAddedToCart).Should().BeTrue();

        }

        [TestMethod]
        public void AddtoCartSimpleProductTest()
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.VIP, null);

            Pages.ProductsPage.GoToProductDetailsPage("Broad St. Flapover Briefcase");

            productAddedToCart = Pages.ProductDetailPage.GetProductName();

            Pages.ProductDetailPage.ChangeQty();

            Pages.ProductDetailPage.AddProductToCart();

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
