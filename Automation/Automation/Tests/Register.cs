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


namespace Automation.Tests
{
    [TestClass]
    public class Register : BaseTest
    {
        public static IEnumerable<object> RegisterData()
        {
            yield return new object[] { Faker.Name.First(), Faker.Name.Middle(), Faker.Name.Last(), Faker.Internet.Email() };
        }

        [DynamicData(nameof(RegisterData),DynamicDataSourceType.Method)]
        [TestMethod]
        public void RegisterValidTest(string firstName, string middleName, string lastName, string email)
        {
            Pages.HomePage.GoToAccountDropdownOption(AccountOption.REGISTER);
            var helloText = "Hello, " + firstName + " " + middleName + " " + lastName + "!";
            Pages.RegisterPage.InsertCredentials(firstName, middleName, lastName, email);
            Pages.RegisterPage.SubmitRegister();
            Pages.RegisterPage.IsUserRegistered(helloText).Should().BeTrue();
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
