using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Mail;
using System.ComponentModel;
using FluentAssertions;

namespace Automation
{
    [TestClass]
    public class UnitTest1
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

        [TestMethod]
        public void WishlistTest()
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
    }
}