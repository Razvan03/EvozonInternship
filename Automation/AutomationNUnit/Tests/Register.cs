using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationNUnit.Tests
{
    [TestFixture]
    public class Register
    {
        [Test]
        public void RegisterTest()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");
            driver.FindElement(By.CssSelector("a.skip-link.skip-account")).Click(); //Account button
            driver.FindElement(By.CssSelector("a[title=\"Register\"]")).Click(); //Register Button

            var firstName = Faker.Name.First();
            var middleName = Faker.Name.Middle();
            var lastName = Faker.Name.Last();
            var emailAddress = Faker.Internet.Email();

            driver.FindElement(By.Id("firstname")).SendKeys(firstName);
            driver.FindElement(By.Id("middlename")).SendKeys(middleName);
            driver.FindElement(By.Id("lastname")).SendKeys(lastName);
            driver.FindElement(By.Id("email_address")).SendKeys(emailAddress);
            driver.FindElement(By.Id("password")).SendKeys(lastName);
            driver.FindElement(By.Id("confirmation")).SendKeys(lastName);
            driver.FindElement(By.CssSelector("label[for=\"is_subscribed\"]")).Click(); //Checkbox

            driver.FindElement(By.CssSelector("button[title=\"Register\"]")).Click(); //Submit register

            var welcomeText = driver.FindElement(By.CssSelector("p.hello strong")).Text; //Welcome Text

            var helloText = "Hello, " + firstName + " " + middleName + " " + lastName + "!";

            welcomeText.Should().Be(helloText);
            Assert.That(welcomeText, Is.EqualTo(helloText));

            driver.Close();
        }
    }
}
