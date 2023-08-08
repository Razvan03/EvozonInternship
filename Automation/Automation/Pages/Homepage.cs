using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using Automation.Helpers.Enums;
using MsTests.Helpers;
using MsTests.Helpers.Enums;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Automation.Pages
{
    public class Homepage
    {
        #region Selectors

        private readonly By _homeLogoButton = By.CssSelector("a.logo");
        private readonly By _accountButton = By.CssSelector("a.skip-link.skip-account");
        private readonly By _accountOptionsDropdown = By.CssSelector("#header-account li a");
        private readonly By _toLoginButton = By.CssSelector("a[title=\"Log In\"]");
        private readonly By _toRegisterButton = By.CssSelector("a[title=\"Register\"]");
        private readonly By _newProductsItems = By.CssSelector("a[class=\"product-image\"]");

        private readonly By _searchField = By.Id("search");
        private readonly By _searchButton = By.CssSelector(".search-button");

        private readonly By _categoryList = By.CssSelector(".level0 > a, .level0.has-children > a");
        private readonly By _subcategoryList = By.CssSelector(".level1 a");

        #endregion

        public void SelectItemFromNewProducts(string productName)
        {
            var newProductsList = _newProductsItems.GetElements();
            var SelectedItem = newProductsList.First(i => i.GetAttribute("title") == productName);
            SelectedItem.Click();
        }

        public void GoToAccountDropdownOption(AccountOption option)
        {
            _accountButton.ActionClick();
            var selectedOption =
                _accountOptionsDropdown.GetElements().First(o => o.GetAttribute("title").Equals(option.GetDescription()));
            selectedOption.Click();
        }

        public void GoToHomepage()
        {
            _homeLogoButton.ActionClick();
        }

        public void GoToSubcategoryFromDropdown(Category categoryTitle, Enum subcategoryTitle)
        {
            // get all category elements
            var categories = _categoryList.GetElements();
            // find the category with the matching title
            var category = categories.FirstOrDefault(c => c.Text == categoryTitle.GetDescription());
            if (category == null)
            {
                throw new ArgumentException($"No category found with title: {categoryTitle}");
            }
            
            // the vip  category doesn't have any subcategories
            if (categoryTitle == Category.VIP)
            {
                category.Click();
                return;
            }

            // hover over the category
            category.Hover();

            var subcategories = _subcategoryList.GetElements();
            var subcategory = subcategories.FirstOrDefault(s => s.Text == subcategoryTitle.GetDescription());
            if (subcategory == null)
            {
                throw new ArgumentException($"No subcategory found with title: {categoryTitle}");
            }
            subcategory.Click();
        }

        public void PerformSearchForKeyword(string keyword)
        {
            _searchField.ActionSendKeys(keyword);
            _searchButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }


    }
}
