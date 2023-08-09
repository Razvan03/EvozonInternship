using FluentAssertions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using Automation.Helpers.Enums;
using Faker;
using MsTests.Helpers.Enums;

namespace Automation.Tests
{
    [TestClass]
    public class Login : BaseTest
    {
        [TestInitialize]
        public override void Before()
        {
            base.Before();
            Pages.HomePage.GoToAccountDropdownOption(AccountOption.LOG_IN);
        }

        [DataRow(Constants.VALID_EMAIL, Constants.VALID_PASSWORD)]
        [TestMethod]
        public void LoginWithValidCredentials(string email, string password)
        {
            Pages.LoginPage.InsertCredentialsAndLogin(email, password);
            Pages.AccountPage.IsUserLoggedIn().Should().BeTrue();
            Pages.HomePage.GetWelcomeMessage().Should().Be(Constants.LOGIN_WELCOME_MESSAGE);
            Pages.HomePage.IsAccountOptionAvailable(AccountOption.LOG_IN).Should().BeFalse();
            Pages.HomePage.IsAccountOptionAvailable(AccountOption.LOG_OUT).Should().BeTrue();
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
            Pages.LoginPage.InsertCredentialsAndLogin(email, password);
            Pages.LoginPage.IsErrorMessageDisplayed().Should().BeTrue();
            Pages.AccountPage.IsUserLoggedIn().Should().BeFalse();
            Pages.HomePage.GetWelcomeMessage().Should().Be(Constants.WELCOME_MESSAGE);
            Pages.HomePage.IsAccountOptionAvailable(AccountOption.LOG_OUT).Should().BeFalse();
            Pages.HomePage.IsAccountOptionAvailable(AccountOption.LOG_IN).Should().BeTrue();
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
            Pages.LoginPage.InsertCredentialsAndLogin(email, password);
            Pages.LoginPage.IsValidationAdviceDisplayed().Should().BeTrue();
            Pages.AccountPage.IsUserLoggedIn().Should().BeFalse();
            Pages.HomePage.GetWelcomeMessage().Should().Be(Constants.WELCOME_MESSAGE);
            Pages.HomePage.IsAccountOptionAvailable(AccountOption.LOG_OUT).Should().BeFalse();
            Pages.HomePage.IsAccountOptionAvailable(AccountOption.LOG_IN).Should().BeTrue();
        }
    }
}
    


