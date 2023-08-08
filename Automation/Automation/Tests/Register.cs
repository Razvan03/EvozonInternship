using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Automation.Helpers;
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
            Pages.HomePage.GoToRegisterPage();
            Pages.RegisterPage.InsertCredentials();
            Pages.RegisterPage.SubmitRegister();
            Pages.RegisterPage.IsUserRegistered().Should().BeTrue();
        }

        [TestCleanup]
        public override void After()
        {
            //delete the created user from admin
            Pages.AdminPage.PerformAdminLogin();
            Pages.AdminPage.DeleteLastRegisteredCustomer();

            Browser.WebDriver.SwitchTo().Alert().Accept();

            base.After();
        }
    }
}
