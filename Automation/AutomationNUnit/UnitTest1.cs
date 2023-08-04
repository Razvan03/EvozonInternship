using FluentAssertions;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;

[assembly: Parallelizable(ParallelScope.Fixtures)]
[assembly: LevelOfParallelism(4)]
namespace AutomationNUnit
{
    public class Tests
    {
        [TestFixture]
        public class UnitTest
        {
            #region Login && Register

            [Test]
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

                welcomeText.Should().Be("Hello, Roman Razvan!");
                Assert.That(welcomeText, Is.EqualTo("Hello, Roman Razvan!"));
                driver.Close();
            }

            [Test]
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
                Assert.That(welcomeText, Is.EqualTo(helloText));

                driver.Close();
            }

            #endregion

        }
        [TestFixture]
        public class Wishlist
        {
            #region Wishlist

            public WebDriver driver;
            public string productName;

            [SetUp]
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

            [Test]
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
                Assert.That(ConfirmMessage, Is.EqualTo(productName));

            }
            [TearDown]
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
            #endregion
        }
        [TestFixture]
        public class Cart
        {
            #region Cart
            [Test]
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
                Assert.That(message, Is.EqualTo(product));
                driver.Close();
            }

            [Test]
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
                Assert.That(message, Is.EqualTo(product));
                driver.Close();
            }
            [Test]
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
                Assert.That(message, Is.EqualTo(product));
                driver.Close();

            }
            #endregion
        }
    }
}