using FluentAssertions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;

namespace Automation.Tests
{
    [TestClass]
    public class Login : BaseTest
    {
        [TestMethod]
        public void LoginTest()
        {
            Pages.HomePage.GoToLoginPage();

            Pages.LoginPage.InsertCredentials();

            Pages.LoginPage.SubmitLogin();

            Pages.LoginPage.IsUserLoggedIn().Should().BeTrue();

        }
    }
}
