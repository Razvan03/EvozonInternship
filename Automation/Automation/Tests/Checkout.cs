using Automation.Helpers;
using MsTests.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Automation.Helpers.Enums;

namespace Automation.Tests
{
    [TestClass]
    public class Checkout : BaseTest
    {
        public static IEnumerable<object[]> BillingData()
        {
            yield return new object[]
            {
                new BillingInformation
                {
                    FirstName = Faker.Name.First(),
                    MiddleName = Faker.Name.Middle(),
                    LastName = Faker.Name.Last(),
                    Email = Faker.Internet.Email(),
                    Address = Faker.Address.StreetAddress(),
                    City = Faker.Address.City(),
                    PostalCode = Faker.Address.ZipCode(),
                    Telephone = Faker.Phone.Number(),
                    Country = "Romania",
                    State = "Suceava"
                },
                new ProductInfo
                {
                    Name = "Chelsea Tee",
                    Color = Color.Black,
                    Size = ClothesSize.M,
                    quantity = 2
                }
            };
        }
        [DynamicData(nameof(BillingData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void PlaceOrderWithoutAccount(BillingInformation billingInfo, ProductInfo producInfo)
        {
            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.MEN, Subcategory.Men.TEES_KNITS_AND_POLOS);
            Pages.ProductsPage.GoToProductDetailsPage(producInfo.Name);

            Pages.ProductDetailsPage.ChangeQty(producInfo.quantity);
            Pages.ProductDetailsPage.SelectItemColor(producInfo.Color);
            Pages.ProductDetailsPage.SelectItemSize(producInfo.Size);
            Pages.ProductDetailsPage.AddProductToCart();

            Pages.CartPage.ProceedToCheckout();

            Pages.CheckoutBillingPage.ContinueToCheckoutAsGuest();
            Pages.CheckoutBillingPage.InsertBillingInformation(billingInfo);
            Pages.CheckoutShippingPage.InsertShippingInformation();
            Pages.CheckoutShippingMethodPage.SelectShippingMethod();
            Pages.CheckoutPaymentPage.SelectPayment();

            Pages.CheckoutOrderReviewPage.GetProductName().Should().Be(producInfo.Name.ToUpper());
            Pages.CheckoutOrderReviewPage.GetProductAttributes()[0].Should().Be(producInfo.Color.ToString());
            Pages.CheckoutOrderReviewPage.GetProductAttributes()[1].Should().Be(producInfo.Size.ToString());

            Pages.CheckoutOrderReviewPage.GetBillingInformation().Should().BeEquivalentTo(billingInfo, options => options.Excluding(b => b.Email));

            Pages.CheckoutOrderReviewPage.PlaceOrder();

            Pages.PlaceOrderSuccess.GetSuccessMessage().Should().Be(Constants.OrderPlacedWithSuccessMessage);

            var orderId = Pages.PlaceOrderSuccess.GetOrderId();

            Pages.AdminPage.PerformAdminLogin();

            Pages.AdminPage.NavigateToOrders();

            Pages.AdminPage.GetOrderId().Should().Be(orderId);

            //Improvement: Check the billing info and product info from Admin, not UI!
        }

        public void PlaceOrderWithAccount(BillingInformation billingInfo, ProductInfo producInfo)
        {
            Pages.HeaderPage.GoToAccountDropdownOption(AccountOption.LOG_IN);
            Pages.LoginPage.Login(Constants.VALID_EMAIL, Constants.VALID_PASSWORD);

            Pages.HeaderPage.GoToSubcategoryFromDropdown(Category.MEN, Subcategory.Men.TEES_KNITS_AND_POLOS);
            Pages.ProductsPage.GoToProductDetailsPage(producInfo.Name);

            Pages.ProductDetailsPage.ChangeQty(producInfo.quantity);
            Pages.ProductDetailsPage.SelectItemColor(producInfo.Color);
            Pages.ProductDetailsPage.SelectItemSize(producInfo.Size);
            Pages.ProductDetailsPage.AddProductToCart();

            Pages.CartPage.ProceedToCheckout();

            Pages.CheckoutBillingPage.SelectShipToThisAddress();
            Pages.CheckoutShippingPage.InsertShippingInformation();
            Pages.CheckoutShippingMethodPage.SelectShippingMethod();
            Pages.CheckoutPaymentPage.SelectPayment();

            Pages.CheckoutOrderReviewPage.GetProductName().Should().Be(producInfo.Name.ToUpper());
            Pages.CheckoutOrderReviewPage.GetProductAttributes()[0].Should().Be(producInfo.Color.ToString());
            Pages.CheckoutOrderReviewPage.GetProductAttributes()[1].Should().Be(producInfo.Size.ToString());

            Pages.CheckoutOrderReviewPage.GetBillingInformation().Should().BeEquivalentTo(billingInfo, options => options.Excluding(b => b.Email));

            Pages.CheckoutOrderReviewPage.PlaceOrder();

            Pages.PlaceOrderSuccess.GetSuccessMessage().Should().Be(Constants.OrderPlacedWithSuccessMessage);

            var orderId = Pages.PlaceOrderSuccess.GetOrderId();

            Pages.AdminPage.PerformAdminLogin();

            Pages.AdminPage.NavigateToOrders();

            Pages.AdminPage.GetOrderId().Should().Be(orderId);

            //Improvement: Check the billing info and product info from Admin, not UI!
        }
    }
}
