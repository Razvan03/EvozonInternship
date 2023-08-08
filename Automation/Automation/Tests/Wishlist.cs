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
        public string productAddedtoWishlist;
        [TestInitialize]
        public override void Before()
        {
            base.Before();

            Pages.HomePage.GoToAccountDropdownOption(AccountOption.LOG_IN);
            Pages.LoginPage.InsertCredentials();
            Pages.LoginPage.SubmitLogin();
            Pages.HomePage.GoToHomepage();
        }

        [TestMethod]
        public void AddtoWishlistSimpleProductTest()
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.VIP, null);
            productAddedtoWishlist = Pages.CategoryPage.GetProductName();
            Pages.CategoryPage.AddProductToWishlist();
            Pages.WishlistPage.IsConfirmMessageTrue(productAddedtoWishlist).Should().BeTrue();
            Pages.WishlistPage.IsProductInWishlist(productAddedtoWishlist).Should().BeTrue();
        }
        [TestCleanup]
        public void AddtoWishlistSimpleProductCleanup()
        {
            Pages.WishlistPage.RemoveProductFromWishlist(productAddedtoWishlist);
        }
    }
}
