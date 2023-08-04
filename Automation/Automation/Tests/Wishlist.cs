using FluentAssertions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
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
    public class Wishlist
    {
        public WebDriver driver;
        public string productName;
        [TestInitialize]
        public void AddtoWishlistSimpleProductInitialize()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");
            //Login
            driver.FindElement(By.CssSelector("a.skip-link.skip-account")).Click(); //Account button
            driver.FindElement(By.CssSelector("a[title=\"Log In\"]")).Click(); //Login Button
            driver.FindElement(By.Id("email")).SendKeys("roman_razvan03@yahoo.com");
            driver.FindElement(By.Id("pass")).SendKeys("tester1");
            driver.FindElement(By.Id("send2")).Click(); //Login submit
        }

        [TestMethod]
        public void AddtoWishlistSimpleProductTest()
        {

            //Add to wishlist
            driver.FindElement(By.CssSelector("a.logo")).Click(); //Home button
            //img[alt="Shop Private Sales - Members Only"]
            driver.FindElement(By.CssSelector("img[alt=\"Shop Private Sales - Members Only\"]")).Click(); //Shop Private Sales Button

            productName = driver.FindElement(By.CssSelector("h2.product-name a[title=\"Broad St. Flapover Briefcase\"]")).Text; //Item Broad St. Flapover Briefcase name

            driver.FindElement(By.CssSelector("a[title=\"Broad St. Flapover Briefcase\"] + div a.link-wishlist")).Click(); //Add to Wishlist button

            var ConfirmMessage = driver.FindElement(By.CssSelector("li.success-msg span")).Text.ToUpper(); //Confirmation Added to Wishlist message

            ConfirmMessage.Should().Contain(productName);
            Assert.AreEqual(productName, ConfirmMessage);

        }
        [TestCleanup]
        public void AddtoWishlistSimpleProductCleanup()
        {

            var wishlistElementsName = driver.FindElements(By.CssSelector("#wishlist-table tbody tr h3 a"));
            var removeButtons = driver.FindElements(By.CssSelector("#wishlist-table tbody tr td[class*=\"remove\"] a"));
            var element = wishlistElementsName.First(i => i.Text == productName);
            var index = wishlistElementsName.IndexOf(element);
            removeButtons[index].Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent()).Accept();
            wait.Until(drv => !drv.FindElements(By.CssSelector($"#wishlist-table tbody tr h3 a[title=\"Broad St. Flapover Briefcase\"]")).Any());
            driver.Quit();
        }
    }
}
