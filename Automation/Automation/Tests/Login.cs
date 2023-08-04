using FluentAssertions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*[assembly: Parallelize(Workers = 4,
    Scope = ExecutionScope.MethodLevel)]*/
namespace Automation.Tests
{
    [TestClass]
    public class Login
    {
        [TestMethod]
        public void LoginTest()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");
            driver.FindElement(By.CssSelector("a.skip-link.skip-account")).Click(); //Account button
            driver.FindElement(By.CssSelector("a[title=\"Log In\"]")).Click(); //Login Button  
            driver.FindElement(By.Id("email")).SendKeys("roman_razvan03@yahoo.com");
            driver.FindElement(By.Id("pass")).SendKeys("tester1");
            driver.FindElement(By.Id("send2")).Click(); //Login submit
            var welcomeText = driver.FindElement(By.CssSelector("p.hello strong")).Text; //Hello Text
            //welcomeText.Should().Be("Hello, Roman Razvan!");
            Assert.AreEqual("Hello, Roman Razvan!", welcomeText);
            driver.Close();
        }
    }
}
