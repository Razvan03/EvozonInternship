using Automation.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using SeleniumExtras.PageObjects;
using NsTestFrameworkUI.Pages;

namespace Automation.Tests
{
    public static class Pages
    {
        public static Homepage HomePage => PageHelpers.InitPage(new Homepage());

        public static LoginPage LoginPage => PageHelpers.InitPage(new LoginPage());

        public static RegisterPage RegisterPage => PageHelpers.InitPage(new RegisterPage());
        public static PrivateSalesPage PrivateSalesPage => PageHelpers.InitPage(new PrivateSalesPage());
        public static WishlistPage WishlistPage => PageHelpers.InitPage(new WishlistPage());

        public static ProductDetailPage ProductDetailPage => PageHelpers.InitPage(new ProductDetailPage());

        public static CartPage CartPage => PageHelpers.InitPage(new CartPage());
    }
}
