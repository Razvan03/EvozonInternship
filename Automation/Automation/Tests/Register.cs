using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Automation.Helpers;
using Automation.Helpers.Enums;
using NsTestFrameworkUI.Helpers;

/*[assembly: Parallelize(Workers = 4,
    Scope = ExecutionScope.MethodLevel)]*/
namespace Automation.Tests
{
    [TestClass]
    public class Register : BaseTest
    {
        [TestMethod]
        public void RegisterTest()
        {
            Pages.HomePage.GoToAccountDropdownOption(AccountOption.REGISTER);
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
