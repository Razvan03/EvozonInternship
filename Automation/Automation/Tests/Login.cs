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

namespace Automation.Tests
{
    [TestClass]
    public class Login : BaseTest
    {
        [TestMethod]
        public void LoginValidTest()
        {
            Pages.HomePage.GoToAccountDropdownOption(AccountOption.LOG_IN);

            Pages.LoginPage.InsertCredentialsAndLogin();

            Pages.LoginPage.IsUserLoggedIn().Should().BeTrue();

        }
    }
}
