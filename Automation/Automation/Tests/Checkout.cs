using Automation.Helpers;
using MsTests.Helpers.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;

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
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.MEN, Subcategory.Men.TEES_KNITS_AND_POLOS);
            Pages.ProductsPage.GoToProductDetailsPage(producInfo.Name);
            var productName= Pages.ProductDetailPage.GetProductName().ToUpper();

            Pages.ProductDetailPage.ChangeQty(producInfo.quantity);
            Pages.ProductDetailPage.SelectItemColor(producInfo.Color);
            Pages.ProductDetailPage.SelectItemSize(producInfo.Size);
            Pages.ProductDetailPage.AddProductToCart();

            Pages.CartPage.ProceedToCheckout();

            Pages.CheckoutBillingPage.ContinueToCheckoutAsGuest();
            Pages.CheckoutBillingPage.InsertBillingInformation(billingInfo);
            Pages.CheckoutShippingPage.InsertShippingInformation();
            Pages.CheckoutShippingMethodPage.SelectShippingMethod();
            Pages.CheckoutPaymentPage.SelectPayment();

            var nume = Pages.CheckoutOrderReviewPage.GetProductName();
            Pages.CheckoutOrderReviewPage.GetProductName().Should().Be(productName);
            Pages.CheckoutOrderReviewPage.GetProductAttributes()[0].Should().Be(producInfo.Color.ToString());
            Pages.CheckoutOrderReviewPage.GetProductAttributes()[1].Should().Be(producInfo.Size.ToString());

            Pages.CheckoutOrderReviewPage.GetBillingInformation().Should().BeEquivalentTo(billingInfo, options => options.Excluding(b => b.Email));

            Pages.CheckoutOrderReviewPage.PlaceOrder();

            Pages.PlaceOrderSuccess.GetSuccessMessage().Should().Be(Constants.OrderPlacedWithSuccessMessage);

            //Verify in Admin if the order exist!

        }
    }
}
