using FluentAssertions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using Automation.Helpers.Enums;
using MsTests.Helpers.Enums;

/*[assembly: Parallelize(Workers = 4,
    Scope = ExecutionScope.MethodLevel)]*/
namespace Automation.Tests
{
    [TestClass]
    public class Wishlist : BaseTest
    {
        [TestInitialize]
        public override void Before()
        {
            base.Before();

            Pages.HomePage.GoToAccountDropdownOption(AccountOption.LOG_IN);
            Pages.LoginPage.InsertCredentialsAndLogin();
        }

        [TestMethod]
        public void AddProductToWishlistFromProductsPage()
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.VIP, null);
            Pages.ProductsPage.AddProductToWishlist(Constants.WISHLIST_PRODUCT);

            Pages.WishlistPage.IsConfirmMessageTrue(Constants.WISHLIST_PRODUCT).Should().BeTrue();
            Pages.WishlistPage.IsProductInWishlist(Constants.WISHLIST_PRODUCT).Should().BeTrue();
        }
        [TestCleanup]
        public void AddtoWishlistSimpleProductCleanup()
        {
            Pages.WishlistPage.RemoveProductFromWishlist(Constants.WISHLIST_PRODUCT);
        } 
    }
}
