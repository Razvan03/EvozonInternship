using Automation.Helpers;
using FluentAssertions;

namespace Automation.Tests
{
    [TestClass]
    public class Search : BaseTest
    {
        [TestMethod]
        public void SearchResultsAreDisplayed()
        {
            Pages.HeaderPage.Search("red");
            Pages.SearchResultsPage.IsKeywordResultsMessageDisplayed().Should().BeTrue();
        }
    }
}
