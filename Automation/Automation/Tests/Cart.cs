using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium;
using FluentAssertions;
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
    public class Cart
    {
        [TestMethod]
        public void AddtoCartConfigurableProductTest()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");
            driver.FindElement(By.CssSelector("h3.product-name a[title=\"Chelsea Tee\"]")).Click(); //CHELSEA TEE product from HomePage
            driver.FindElement(By.Id("swatch27")).Click(); //Color blue
            driver.FindElement(By.Id("swatch79")).Click(); //Size M
            driver.FindElement(By.Id("qty")).Clear();
            driver.FindElement(By.Id("qty")).SendKeys("2"); //Quantity
            var product = driver.FindElement(By.CssSelector("div.product-name h1")).GetAttribute("innerText"); //.Text didn't work
            driver.FindElement(By.CssSelector("button.button.btn-cart[onclick]")).Click(); //Add to cart button

            var message = driver.FindElement(By.CssSelector("li.success-msg span")).Text;

            message.Should().Contain(product);
            Assert.AreEqual(product, message);
            driver.Close();
        }

        [TestMethod]
        public void AddtoCartDigitalProductTest()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");

            Actions actions = new Actions(driver);
            var element = driver.FindElement(By.CssSelector("li.level0.nav-4.parent a.level0.has-children")); // Home&Decor element
            actions.MoveToElement(element).Perform(); //Hover over

            driver.FindElement(By.CssSelector("li.level0.nav-4.parent li.level1.nav-4-1.first a.level1 ")).Click(); //Books & Music //Intr-un proiect adevarat as fi mers pe elementele copil al Home&Decor element si as cauta elementul copil dupa innertext :)
            driver.FindElement(By.Id("product-collection-image-448")).Click(); //A Tale of Two Cities disk

            var product = driver.FindElement(By.CssSelector("div.product-name h1")).GetAttribute("innerText"); //Product name

            driver.FindElement(By.Id("links_20")).Click(); //Checkbox
            driver.FindElement(By.CssSelector("button.button.btn-cart[onclick]")).Click(); //Add to cart button

            var message = driver.FindElement(By.CssSelector("li.success-msg span")).Text;

            message.Should().Contain(product);
            Assert.AreEqual(product, message);
            driver.Close();
        }
        [TestMethod]
        public void AddtoCartSimpleProductTest()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");

            driver.FindElement(By.CssSelector("img[alt=\"Shop Private Sales - Members Only\"]")).Click(); //Shop Private Sales Button

            driver.FindElement(By.Id("product-collection-image-373")).Click(); //Broad St. Flapover Briefcase click

            var product = driver.FindElement(By.CssSelector("div.product-name h1")).GetAttribute("innerText");

            driver.FindElement(By.CssSelector("button.button.btn-cart[onclick]")).Click(); //Add to cart button

            var message = driver.FindElement(By.CssSelector("li.success-msg span")).Text;

            message.Should().Contain(product);
            Assert.AreEqual(product, message);
            driver.Close();

        }
    }
}
