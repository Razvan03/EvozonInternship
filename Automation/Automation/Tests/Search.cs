using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

namespace Automation.Tests
{
    [TestClass]
    public class Search
    {
        [TestMethod]
        public void SearchResultsAreDisplayed()
        {
            Pages.HomePage.PerformSearchForKeyword("red");
            Pages.SearchResultsPage.IsKeywordResultsMessageDisplayed().Should().BeTrue();
        }
    }
}
