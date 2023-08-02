using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Mail;
using System.ComponentModel;
using FluentAssertions;
using OpenQA.Selenium.Interactions;
using System.Xml.Linq;

namespace Automation
{
    [TestClass]
    public class UnitTest1
    {
        #region Login && Register

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

        [TestMethod]
        public void RegisterTest()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");
            driver.FindElement(By.CssSelector("#header > div > div.skip-links > div > a > span.label")).Click(); //Account button
            driver.FindElement(By.CssSelector("#header-account > div > ul > li:nth-child(5) > a")).Click(); //Register Button

            string randomString = Methods.GenerateRandomString(6);
            string emailAddress = randomString + "@email.com";

            driver.FindElement(By.Id("firstname")).SendKeys(randomString);
            driver.FindElement(By.Id("middlename")).SendKeys(randomString);
            driver.FindElement(By.Id("lastname")).SendKeys(randomString);
            driver.FindElement(By.Id("email_address")).SendKeys(emailAddress);
            driver.FindElement(By.Id("password")).SendKeys(randomString);
            driver.FindElement(By.Id("confirmation")).SendKeys(randomString);
            driver.FindElement(By.CssSelector("#form-validate > div.fieldset > ul > li.control > label")).Click(); //Checkbox

            driver.FindElement(By.CssSelector("#form-validate > div.buttons-set > button")).Click(); //Submit register

            String welcomeText = driver.FindElement(By.CssSelector("body > div > div > div.main-container.col2-left-layout > div > div.col-main > div.my-account > div > div.welcome-msg > p.hello > strong")).Text; //Welcome Text

            string helloText ="Hello, " + randomString + " " + randomString + " " + randomString + "!";
       
            welcomeText.Should().Be(helloText);

            driver.Close();
        }

        #endregion

        #region Wishlist
        [TestMethod]
        public void toWishlistSimpleProductTest()
        {
        
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");
            //Login
            driver.FindElement(By.CssSelector("#header > div > div.skip-links > div > a > span.label")).Click(); //Account button
            driver.FindElement(By.CssSelector("#header-account > div > ul > li.last > a")).Click(); //Login Button
            driver.FindElement(By.Id("email")).SendKeys("roman_razvan03@yahoo.com");
            driver.FindElement(By.Id("pass")).SendKeys("tester1");
            driver.FindElement(By.Id("send2")).Click(); //Login submit

            //Add to wishlist
            driver.FindElement(By.CssSelector("#header > div > a")).Click(); //Home button
            driver.FindElement(By.CssSelector("body > div > div > div.main-container.col1-layout > div > div > div.std > ul > li:nth-child(2) > a > img")).Click(); //Shop Private Sales Button

            String ItemtoAdd = driver.FindElement(By.CssSelector("body > div > div > div.main-container.col3-layout > div.main > div.col-wrapper > div.col-main > div.category-products > ul > li:nth-child(1) > div > h2 > a")).Text; //Item Broad St. Flapover Briefcase name

            driver.FindElement(By.CssSelector("body > div > div > div.main-container.col3-layout > div > div.col-wrapper > div.col-main > div.category-products > ul > li:nth-child(1) > div > div.actions > ul > li:nth-child(1) > a")).Click(); //Add to Wishlist button
            
            String ConfirmMessage = driver.FindElement(By.CssSelector("body > div > div > div.main-container.col2-left-layout > div > div.col-main > div.my-account > div.my-wishlist > ul > li > ul > li > span")).Text.ToUpper(); //Confirmation Added to Wishlist message

            ConfirmMessage.Should().Contain(ItemtoAdd);
            driver.Close();

        }
        #endregion

        #region Cart
        [TestMethod]
        public void toCartConfigurableProductTest()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");
            driver.FindElement(By.CssSelector("body > div > div > div.main-container.col1-layout > div > div > div.std > div.widget.widget-new-products > div.widget-products > ul > li:nth-child(3) > a")).Click(); //CHELSEA TEE product from HomePage
            driver.FindElement(By.Id("swatch27")).Click(); //Color blue
            driver.FindElement(By.Id("swatch79")).Click(); //Size M
            driver.FindElement(By.Id("qty")).Clear();
            driver.FindElement(By.Id("qty")).SendKeys("2"); //Quantity
            String product = driver.FindElement(By.CssSelector("#product_addtocart_form > div.product-shop > div.product-name > span")).Text;
            driver.FindElement(By.CssSelector("#product_addtocart_form > div.product-shop > div.product-options-bottom > div.add-to-cart > div.add-to-cart-buttons > button")).Click(); //Add to cart button

            String message = driver.FindElement(By.CssSelector("body > div > div > div.main-container.col1-layout > div > div > div.cart.display-single-price > ul > li > ul > li > span")).Text.ToUpper();

            message.Should().Contain(product);
            driver.Close();
        }

        [TestMethod]
        public void toCartDigitalProductTest()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");

            Actions actions = new Actions(driver);
            var element = driver.FindElement(By.CssSelector("#nav > ol > li.level0.nav-4.parent > a")); // Home&Decor element
            actions.MoveToElement(element).Perform(); //Hover over

            driver.FindElement(By.CssSelector("#nav > ol > li.level0.nav-4.parent > ul > li.level1.nav-4-1.first > a")).Click(); //Books & Music
            driver.FindElement(By.Id("product-collection-image-448")).Click(); //A Tale of Two Cities disk

            String product = driver.FindElement(By.CssSelector("#product_addtocart_form > div.product-shop > div.product-name > span")).Text; //Product name

            driver.FindElement(By.Id("links_20")).Click(); //Checkbox
            driver.FindElement(By.CssSelector("#product_addtocart_form > div.product-shop > div.product-options-bottom > div.add-to-cart > div.add-to-cart-buttons > button")).Click(); //Add to cart button

            String message = driver.FindElement(By.CssSelector("body > div > div > div.main-container.col1-layout > div > div > div.cart.display-single-price > ul > li > ul > li > span")).Text.ToUpper();

            message.Should().Contain(product);
            driver.Close();
        }
        [TestMethod]
        public void toCartSimpleProductTest()
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("http://qa3magento.dev.evozon.com/");

            driver.FindElement(By.CssSelector("body > div > div > div.main-container.col1-layout > div > div > div.std > ul > li:nth-child(2) > a > img")).Click(); //Shop Private Sales Button

            String product = driver.FindElement(By.CssSelector("body > div > div > div.main-container.col3-layout > div.main > div.col-wrapper > div.col-main > div.category-products > ul > li:nth-child(1) > div > h2 > a")).Text;

            driver.FindElement(By.Id("product-collection-image-373")).Click(); //Broad St. Flapover Briefcase click

            driver.FindElement(By.CssSelector("#product_addtocart_form > div.add-to-cart-wrapper > div > div > div.add-to-cart-buttons > button")).Click(); //Add to cart button

            String message = driver.FindElement(By.CssSelector("body > div > div > div.main-container.col1-layout > div > div > div.cart.display-single-price > ul > li > ul > li > span")).Text.ToUpper();

            message.Should().Contain(product);
            driver.Close();

        }
        #endregion
    }
}