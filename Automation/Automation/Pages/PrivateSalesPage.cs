using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using OpenQA.Selenium;

namespace Automation.Pages
{
    public class PrivateSalesPage
    {
        private readonly By _briefcaseProductName = By.CssSelector("h2.product-name a[title=\"Broad St. Flapover Briefcase\"]");
        private readonly By _briefcaseToWishlist = By.CssSelector("a[title =\"Broad St. Flapover Briefcase\"] + div a.link-wishlist");
        private readonly By _confirmMessage = By.CssSelector("li.success-msg span");
        public void AddBriefcaseToWishlist()
        {
            Browser.GetDriver().FindElement(_briefcaseToWishlist).Click();
        }

        public string GetBriefcaseName()
        {
            return Browser.GetDriver().FindElement(_briefcaseProductName).Text;
        }

        public bool IsAdded(string product)
        {
            return Browser.GetDriver().FindElement(_confirmMessage).Text.ToUpper().Contains(product);
        }
    }
}
