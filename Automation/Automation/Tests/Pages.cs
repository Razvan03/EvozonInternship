using Automation.Pages;
using MsTests.Pages;
using NsTestFrameworkUI.Pages;
using Automation.Pages.CheckoutPage;

namespace Automation.Tests
{
    public static class Pages
    {
        public static HeaderPage HeaderPage => PageHelpers.InitPage(new HeaderPage());
        public static LoginPage LoginPage => PageHelpers.InitPage(new LoginPage());
        public static RegisterPage RegisterPage => PageHelpers.InitPage(new RegisterPage());
        public static WishlistPage WishlistPage => PageHelpers.InitPage(new WishlistPage());
        public static ProductDetailsPage ProductDetailsPage => PageHelpers.InitPage(new ProductDetailsPage());
        public static CartPage CartPage => PageHelpers.InitPage(new CartPage());
        public static SearchResultsPage SearchResultsPage => PageHelpers.InitPage(new SearchResultsPage());
        public static AdminPage AdminPage => PageHelpers.InitPage(new AdminPage());
        public static CategoryPage CategoryPage => PageHelpers.InitPage(new CategoryPage());
        public static ProductsPage ProductsPage => PageHelpers.InitPage(new ProductsPage());
        public static CheckoutBillingPage CheckoutBillingPage => PageHelpers.InitPage(new CheckoutBillingPage());

        public static CheckoutShippingPage CheckoutShippingPage => PageHelpers.InitPage(new CheckoutShippingPage());

        public static CheckoutShippingMethodPage CheckoutShippingMethodPage => PageHelpers.InitPage(new CheckoutShippingMethodPage());

        public static CheckoutPaymentPage CheckoutPaymentPage => PageHelpers.InitPage(new CheckoutPaymentPage());

        public static CheckoutOrderReviewPage CheckoutOrderReviewPage => PageHelpers.InitPage(new CheckoutOrderReviewPage());

        public static PlaceOrderSuccessPage PlaceOrderSuccess => PageHelpers.InitPage(new PlaceOrderSuccessPage());
    }
}
