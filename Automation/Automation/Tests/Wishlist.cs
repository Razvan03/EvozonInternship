using FluentAssertions;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;

/*[assembly: Parallelize(Workers = 4,
    Scope = ExecutionScope.MethodLevel)]*/
namespace Automation.Tests
{
    [TestClass]
    public class Wishlist : BaseTest
    {
        [TestInitialize]
        public override void Before()
        {
            base.Before();

            Pages.HomePage.GoToLoginPage();

            Pages.LoginPage.InsertCredentials();

            Pages.LoginPage.SubmitLogin();
        }

        [TestMethod]
        public void AddtoWishlistSimpleProductTest()
        {
            Pages.HomePage.GoToHomepage();

            Pages.HomePage.GoToPrivateSales();

            var productAddedtoWishlist = Pages.PrivateSalesPage.GetBriefcaseName();

            Pages.PrivateSalesPage.AddBriefcaseToWishlist();

            Pages.PrivateSalesPage.IsAdded(productAddedtoWishlist);

        }
        [TestCleanup]
        public void AddtoWishlistSimpleProductCleanup() //TO DO , NOT COMPLETED
        {


            /*var wishlistElementsName = driver.FindElements(By.CssSelector("#wishlist-table tbody tr h3 a"));
            var removeButtons = driver.FindElements(By.CssSelector("#wishlist-table tbody tr td[class*=\"remove\"] a"));
            var element = wishlistElementsName.First(i => i.Text == productName);
            var index = wishlistElementsName.IndexOf(element);
            removeButtons[index].Click();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent()).Accept();
            wait.Until(drv => !drv.FindElements(By.CssSelector($"#wishlist-table tbody tr h3 a[title=\"Broad St. Flapover Briefcase\"]")).Any());
            driver.Quit();*/
        }
    }
}
