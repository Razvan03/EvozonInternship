﻿using FluentAssertions;
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

        public static IEnumerable<object[]> WishlistData()
        {
            yield return new object[] { Category.VIP, null, "Broad St. Flapover Briefcase" };
            yield return new object[] { Category.WOMEN, Subcategory.Women.NEW_ARRIVALS, "Elizabeth Knit Top" };
            yield return new object[] { Category.MEN, Subcategory.Men.SHIRTS, "White Shirt" };
            yield return new object[] { Category.ACCESSORIES, Subcategory.Accessories.SHOES, "Suede Loafer, Navy" };
            yield return new object[] { Category.HOME_AND_DECOR, Subcategory.HomeAndDecor.BOOKS_AND_MUSIC, "Alice in Wonderland" };
        }

        [DynamicData(nameof(WishlistData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void AddProductToWishlistFromProductsPage(Category category, Enum subcategory, string productName)
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(category, subcategory);
            Pages.ProductsPage.AddProductToWishlist(productName);

            Pages.WishlistPage.IsConfirmMessageTrue(productName).Should().BeTrue();
            Pages.WishlistPage.IsProductInWishlist(productName).Should().BeTrue();
        }
        
        [DataRow("Broad St. Flapover Briefcase")]
        [DataRow("Elizabeth Knit Top")]
        [DataRow("White Shirt")]
        [DataRow("Suede Loafer, Navy")]
        [DataRow("Alice in Wonderland")]
        [TestCleanup]
        public void AddtoWishlistSimpleProductCleanup(string productName)
        {
            Pages.WishlistPage.RemoveProductFromWishlist(productName);
        }
    }
}
