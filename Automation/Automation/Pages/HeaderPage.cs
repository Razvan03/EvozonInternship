using Automation.Helpers.Enums;
using MsTests.Helpers;
using MsTests.Helpers.Enums;
using NsTestFrameworkUI.Helpers;
using NsTestFrameworkUI.Pages;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class HeaderPage
    {
        #region Selectors

        private readonly By _homeLogoButton = By.CssSelector("a.logo");
        private readonly By _accountButton = By.CssSelector("a.skip-link.skip-account");
        private readonly By _accountOptionsDropdown = By.CssSelector("#header-account li a");

        private readonly By _searchField = By.Id("search");
        private readonly By _searchButton = By.CssSelector(".search-button");

        private readonly By _categoryList = By.CssSelector(".level0 > a, .level0.has-children > a");
        private readonly By _subcategoryList = By.CssSelector(".level1 a");

        private readonly By _welcomeMessage = By.CssSelector(".welcome-msg");
        private readonly By _pageTitleLabel = By.CssSelector(".page-title");

        #endregion

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
            var categories = _categoryList.GetElements();
            var category = categories.FirstOrDefault(c => c.Text == categoryTitle.GetDescription());
            if (category == null)
            {
                throw new ArgumentException($"No category found with title: {categoryTitle}");
            }
            
            if (categoryTitle == Category.VIP)
            {
                category.Click();
                return;
            }

            category.Hover();

            var subcategories = _subcategoryList.GetElements();
            var subcategory = subcategories.FirstOrDefault(s => s.Text == subcategoryTitle.GetDescription());
            if (subcategory == null)
            {
                throw new ArgumentException($"No subcategory found with title: {categoryTitle}");
            }
            subcategory.Click();
        }

        public void Search(string keyword)
        {
            _searchField.ActionSendKeys(keyword);
            _searchButton.ActionClick();
            WaitHelpers.WaitForDocumentReadyState();
        }

        public string GetWelcomeMessage()
        {
            return _welcomeMessage.GetText();
        }

        public string GetPageTitleText()
        {
            return _pageTitleLabel.GetText();
        }

        public bool IsAccountOptionAvailable(AccountOption option)
        {
            _accountButton.ActionClick();
            var selectedOption =
                _accountOptionsDropdown.GetElements().FirstOrDefault(o => o.GetAttribute("title").Equals(option.GetDescription()));
            return selectedOption != null;
        }

    }
}
