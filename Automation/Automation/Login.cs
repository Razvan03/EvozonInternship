using FluentAssertions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation
{
    [TestClass]
    internal class Login
    {
        [TestMethod]
        public void LoginTest()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");
            driver.FindElement(By.CssSelector("#header > div > div.skip-links > div > a > span.label")).Click(); //Account button
            driver.FindElement(By.CssSelector("#header-account > div > ul > li.last > a")).Click(); //Login Button
            driver.FindElement(By.Id("email")).SendKeys("roman_razvan03@yahoo.com");
            driver.FindElement(By.Id("pass")).SendKeys("tester1");
            driver.FindElement(By.Id("send2")).Click(); //Login submit
            String welcomeText = driver.FindElement(By.CssSelector("body > div > div.page > div.main-container.col2-left-layout > div > div.col-main > div.my-account > div > div.welcome-msg > p.hello > strong")).Text; //Hello Text

            welcomeText.Should().Be("Hello, Roman Razvan!");

            driver.Close();
        }
    }
}
