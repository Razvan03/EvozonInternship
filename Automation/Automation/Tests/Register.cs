using FluentAssertions;
using Automation.Helpers;
using Automation.Helpers.Enums;
using NsTestFrameworkUI.Helpers;

namespace Automation.Tests
{
    [TestClass]
    public class Register : BaseTest
    {
        [TestMethod]
        public void RegisterValidTest()
        {
            Pages.HeaderPage.GoToAccountDropdownOption(AccountOption.REGISTER);
            Pages.RegisterPage.InsertCredentials();
            Pages.RegisterPage.SubmitRegister();
            Pages.RegisterPage.IsUserRegistered().Should().BeTrue();
        }

        [TestCleanup]
        public override void After()
        {
            Pages.AdminPage.PerformAdminLogin();
            Pages.AdminPage.DeleteLastRegisteredCustomer();

            Browser.WebDriver.SwitchTo().Alert().Accept();

            base.After();
        }
    }
}
