using FluentAssertions;
using Automation.Helpers;
using Automation.Helpers.Enums;
using Faker;

namespace Automation.Tests
{
    [TestClass]
    public class Login : BaseTest
    {
        [TestInitialize]
        public override void Before()
        {
            base.Before();
            Pages.HeaderPage.GoToAccountDropdownOption(AccountOption.LOG_IN);
        }

        [DataRow(Constants.VALID_EMAIL, Constants.VALID_PASSWORD)]
        [TestMethod]
        public void LoginWithValidCredentials(string email, string password)
        {
            Pages.LoginPage.Login(email, password);
            Pages.AccountPage.IsUserLoggedIn().Should().BeTrue();
            Pages.HeaderPage.GetWelcomeMessage().Should().Be(Constants.HEADER_LOGGED_OUT_MESSAGE);
            Pages.HeaderPage.IsAccountOptionAvailable(AccountOption.LOG_IN).Should().BeFalse();
            Pages.HeaderPage.IsAccountOptionAvailable(AccountOption.LOG_OUT).Should().BeTrue();
        }

        public static IEnumerable<object[]> ErrorMessageData()
        {
            yield return new object[] { Constants.VALID_EMAIL , StringFaker.AlphaNumeric(36)};
            yield return new object[] { Constants.VALID_EMAIL , null};
            yield return new object[] { Internet.Email(), Constants.VALID_PASSWORD };
            yield return new object[] { Internet.Email(), StringFaker.AlphaNumeric(36) };
            yield return new object[] { Internet.Email(), null };
        }

        [DynamicData(nameof(ErrorMessageData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void LoginWithInvalidCredentialsWhichDisplayErrorMessage(string email, string password)
        {
            Pages.LoginPage.Login(email, password);
            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
            Pages.AccountPage.IsUserLoggedIn().Should().BeFalse();
            Pages.HeaderPage.GetWelcomeMessage().Should().Be(Constants.HEADER_LOGGED_IN_MESSAGE);
            Pages.HeaderPage.IsAccountOptionAvailable(AccountOption.LOG_OUT).Should().BeFalse();
            Pages.HeaderPage.IsAccountOptionAvailable(AccountOption.LOG_IN).Should().BeTrue();
        }

        public static IEnumerable<object[]> ValidationAdviceData()
        {
            yield return new object[] { null, Constants.VALID_PASSWORD };
            yield return new object[] { null, StringFaker.AlphaNumeric(4) };
            yield return new object[] { Constants.VALID_EMAIL, StringFaker.AlphaNumeric(4) };
            yield return new object[] { Internet.Email(), StringFaker.AlphaNumeric(4) };
            yield return new object[] { null, null };
        }

        [DynamicData(nameof(ValidationAdviceData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void LoginWithInvalidCredentialsWhichDisplayValidationAdviceMessage(string email, string password)
        {
            Pages.LoginPage.Login(email, password);
            Pages.LoginPage.IsValidationAdviceDisplayed().Should().BeTrue();
            Pages.AccountPage.IsUserLoggedIn().Should().BeFalse();
            Pages.HeaderPage.GetWelcomeMessage().Should().Be(Constants.HEADER_LOGGED_IN_MESSAGE);
            Pages.HeaderPage.IsAccountOptionAvailable(AccountOption.LOG_OUT).Should().BeFalse();
            Pages.HeaderPage.IsAccountOptionAvailable(AccountOption.LOG_IN).Should().BeTrue();
        }
    }
}
    


