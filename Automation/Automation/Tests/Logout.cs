using Automation.Helpers;
using Automation.Helpers.Enums;
using FluentAssertions;

namespace Automation.Tests
{
    [TestClass]
    public class Logout : BaseTest
    {
        [TestInitialize]
        public override void Before()
        {
            base.Before();
            Pages.HeaderPage.GoToAccountDropdownOption(AccountOption.LOG_IN);
            Pages.LoginPage.Login(Constants.VALID_EMAIL, Constants.VALID_PASSWORD);
        }

        [TestMethod]
        public void UserIsAbleToLogout()
        {
            Pages.HeaderPage.GoToAccountDropdownOption(AccountOption.LOG_OUT);
            Pages.HeaderPage.GetWelcomeMessage().Should().Be(Constants.HEADER_LOGGED_IN_MESSAGE);
            Pages.HeaderPage.GetPageTitleText().Should().Be(Constants.LOGOUT_MESSAGE);
            Pages.HeaderPage.IsAccountOptionAvailable(AccountOption.LOG_OUT).Should().BeFalse();
            Pages.HeaderPage.IsAccountOptionAvailable(AccountOption.LOG_IN).Should().BeTrue();
        }
    }
}
