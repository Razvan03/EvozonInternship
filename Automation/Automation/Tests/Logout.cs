using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            Pages.HomePage.GoToAccountDropdownOption(AccountOption.LOG_IN);
            Pages.LoginPage.InsertCredentialsAndLogin(Constants.VALID_EMAIL, Constants.VALID_PASSWORD);
        }

        [TestMethod]
        public void LogoutFromAccountDropdown()
        {
            Pages.HomePage.GoToAccountDropdownOption(AccountOption.LOG_OUT);
            Pages.HomePage.GetWelcomeMessage().Should().Be(Constants.WELCOME_MESSAGE);
            Pages.HomePage.GetPageTitleText().Should().Be(Constants.LOGOUT_MESSAGE);
            Pages.AccountPage.IsUserLoggedIn().Should().BeFalse();
            Pages.HomePage.IsAccountOptionAvailable(AccountOption.LOG_OUT).Should().BeFalse();
            Pages.HomePage.IsAccountOptionAvailable(AccountOption.LOG_IN).Should().BeTrue();
        }
    }
}
