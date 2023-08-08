using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using MsTests.Helpers.Enums;

namespace Automation.Tests
{
    [TestClass]
    public class Navigation : BaseTest
    {
        [TestMethod]
        public void NavigateThroughMainCategories()
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.VIEW_ALL);
            Pages.CategoryPage.IsCategoryTitleDisplayed();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.WOMEN);

            Pages.HomePage.GoToSubcategoryFromDropdown(Category.MEN, Subcategory.Men.VIEW_ALL);
            Pages.CategoryPage.IsCategoryTitleDisplayed();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.MEN);

            Pages.HomePage.GoToSubcategoryFromDropdown(Category.ACCESSORIES, Subcategory.Accessories.VIEW_ALL);
            Pages.CategoryPage.IsCategoryTitleDisplayed();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.ACCESSORIES);

            Pages.HomePage.GoToSubcategoryFromDropdown(Category.HOME_AND_DECOR, Subcategory.HomeAndDecor.VIEW_ALL);
            Pages.CategoryPage.IsCategoryTitleDisplayed();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.HOME_AND_DECOR);

            Pages.HomePage.GoToSubcategoryFromDropdown(Category.SALE, Subcategory.Sale.VIEW_ALL);
            Pages.CategoryPage.IsCategoryTitleDisplayed();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.SALE);

            Pages.HomePage.GoToSubcategoryFromDropdown(Category.VIP, null);
            Pages.CategoryPage.IsCategoryTitleDisplayed();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.VIP);
        }

        [TestMethod]
        public void NavigateThroughWomenSubcategories()
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.VIEW_ALL);
            Pages.ProductsPage.IsSubcategoryTitleDisplayed();
            Pages.ProductsPage.IsCorrectSubcategoryTitleDisplayed(Category.WOMEN);

            Pages.HomePage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.NEW_ARRIVALS);
            Pages.ProductsPage.IsSubcategoryTitleDisplayed();
            Pages.ProductsPage.IsCorrectSubcategoryTitleDisplayed(Subcategory.Women.NEW_ARRIVALS);

            Pages.HomePage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.TOPS_AND_BLOUSES);
            Pages.ProductsPage.IsSubcategoryTitleDisplayed();
            Pages.ProductsPage.IsCorrectSubcategoryTitleDisplayed(Subcategory.Women.TOPS_AND_BLOUSES);

            Pages.HomePage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.PANTS_AND_DENIM);
            Pages.ProductsPage.IsSubcategoryTitleDisplayed();
            Pages.ProductsPage.IsCorrectSubcategoryTitleDisplayed(Subcategory.Women.PANTS_AND_DENIM);

            Pages.HomePage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.DRESSES_AND_SKIRTS);
            Pages.ProductsPage.IsSubcategoryTitleDisplayed();
            Pages.ProductsPage.IsCorrectSubcategoryTitleDisplayed(Subcategory.Women.DRESSES_AND_SKIRTS);
        }
    }
}
