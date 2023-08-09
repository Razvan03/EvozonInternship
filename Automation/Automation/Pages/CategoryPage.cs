using MsTests.Helpers.Enums;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MsTests.Helpers;
using NsTestFrameworkUI.Pages;

namespace Automation.Pages
{
    public class CategoryPage
    {
        #region Selectors

        private readonly By _categoryTitle = By.CssSelector(".category-title h1");

        #endregion

        public bool IsCategoryTitleDisplayed()
        {
            return _categoryTitle.IsElementPresent();
        }

        public bool IsCorrectCategoryTitleDisplayed(Category category)
        {
            return _categoryTitle.GetText().Equals(category.GetDescription());
        }
    }
}
