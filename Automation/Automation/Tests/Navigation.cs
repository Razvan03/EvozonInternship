using Automation.Helpers;
using FluentAssertions;
using MsTests.Helpers.Enums;

namespace Automation.Tests
{
    [TestClass]
    public class Navigation : BaseTest
    {
        [TestMethod]
        public void GoThroughMainCategories()
        {
            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.VIEW_ALL);
            Pages.CategoryPage.IsCategoryTitleDisplayed().Should().BeTrue();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.WOMEN);

            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.MEN, Subcategory.Men.VIEW_ALL);
            Pages.CategoryPage.IsCategoryTitleDisplayed();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.MEN);

            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.ACCESSORIES, Subcategory.Accessories.VIEW_ALL);
            Pages.CategoryPage.IsCategoryTitleDisplayed();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.ACCESSORIES);

            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.HOME_AND_DECOR, Subcategory.HomeAndDecor.VIEW_ALL);
            Pages.CategoryPage.IsCategoryTitleDisplayed();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.HOME_AND_DECOR);

            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.SALE, Subcategory.Sale.VIEW_ALL);
            Pages.CategoryPage.IsCategoryTitleDisplayed();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.SALE);

            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.VIP, null);
            Pages.CategoryPage.IsCategoryTitleDisplayed();
            Pages.CategoryPage.IsCorrectCategoryTitleDisplayed(Category.VIP);
        }

        [TestMethod]
        public void GoThroughWomenSubcategories()
        {
            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.VIEW_ALL);
            Pages.ProductsPage.IsSubcategoryTitleDisplayed();
            Pages.ProductsPage.IsCorrectSubcategoryTitleDisplayed(Category.WOMEN);

            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.NEW_ARRIVALS);
            Pages.ProductsPage.IsSubcategoryTitleDisplayed();
            Pages.ProductsPage.IsCorrectSubcategoryTitleDisplayed(Subcategory.Women.NEW_ARRIVALS);

            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.TOPS_AND_BLOUSES);
            Pages.ProductsPage.IsSubcategoryTitleDisplayed();
            Pages.ProductsPage.IsCorrectSubcategoryTitleDisplayed(Subcategory.Women.TOPS_AND_BLOUSES);

            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.PANTS_AND_DENIM);
            Pages.ProductsPage.IsSubcategoryTitleDisplayed();
            Pages.ProductsPage.IsCorrectSubcategoryTitleDisplayed(Subcategory.Women.PANTS_AND_DENIM);

            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.WOMEN, Subcategory.Women.DRESSES_AND_SKIRTS);
            Pages.ProductsPage.IsSubcategoryTitleDisplayed();
            Pages.ProductsPage.IsCorrectSubcategoryTitleDisplayed(Subcategory.Women.DRESSES_AND_SKIRTS);
        }
    }
}
