﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

[assembly: Parallelize(Workers = 4,
    Scope = ExecutionScope.MethodLevel)]
namespace Automation.Tests
{
    [TestClass]
    public class Register
    {
        [TestMethod]
        public void RegisterTest()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");
            driver.FindElement(By.CssSelector("a.skip-link.skip-account")).Click(); //Account button
            driver.FindElement(By.CssSelector("a[title=\"Register\"]")).Click(); //Register Button

            var randomString = Methods.GenerateRandomString(6);
            var emailAddress = randomString + "@email.com";

            driver.FindElement(By.Id("firstname")).SendKeys(randomString);
            driver.FindElement(By.Id("middlename")).SendKeys(randomString);
            driver.FindElement(By.Id("lastname")).SendKeys(randomString);
            driver.FindElement(By.Id("email_address")).SendKeys(emailAddress);
            driver.FindElement(By.Id("password")).SendKeys(randomString);
            driver.FindElement(By.Id("confirmation")).SendKeys(randomString);
            driver.FindElement(By.CssSelector("label[for=\"is_subscribed\"]")).Click(); //Checkbox

            driver.FindElement(By.CssSelector("button[title=\"Register\"]")).Click(); //Submit register

            var welcomeText = driver.FindElement(By.CssSelector("p.hello strong")).Text; //Welcome Text

            var helloText = "Hello, " + randomString + " " + randomString + " " + randomString + "!";

            welcomeText.Should().Be(helloText);
            Assert.AreEqual(helloText, welcomeText);

            driver.Close();
        }
    }
}