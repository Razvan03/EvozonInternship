using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsTestFrameworkUI.Pages;

namespace Automation.Pages
{
    public class SearchResultsPage
    {
        #region Selectors

        private readonly By _keywordResultsMessage = By.CssSelector(".page-title h1");

        #endregion

        public bool IsKeywordResultsMessageDisplayed()
        {
            return _keywordResultsMessage.IsElementPresent();
        }
    }
}
