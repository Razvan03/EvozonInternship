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
                "Chelsea Tee", Color.Black, ClothesSize.M, "2"
            };
        }

        [DynamicData(nameof(BillingData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void PlaceOrderWithoutAccount(BillingInformation billingInfo, string productName, Color productColor, ClothesSize productSize, string productQty)
        {
            Pages.HomePage.GoToSubcategoryFromDropdown(Category.MEN, Subcategory.Men.TEES_KNITS_AND_POLOS);
            Pages.ProductsPage.GoToProductDetailsPage(productName);

            //productAddedToCart = Pages.ProductDetailPage.GetProductName();

            Pages.ProductDetailPage.ChangeQty(productQty);
            Pages.ProductDetailPage.SelectItemColor(productColor);
            Pages.ProductDetailPage.SelectItemSize(productSize);
            Pages.ProductDetailPage.AddProductToCart();

            Pages.CartPage.ProceedToCheckout();

            Pages.CheckoutBillingPage.ContinueToCheckoutAsGuest();

            Pages.CheckoutBillingPage.InsertBillingInformation(billingInfo);

            Pages.CheckoutShippingPage.InsertShippingInformation();

            Pages.CheckoutShippingMethodPage.SelectShippingMethod();

            Pages.CheckoutPaymentPage.SelectPayment();

            //Pages.CheckoutOrderReviewPage.AreBillingDetailsTrue(billingInfo).Should().BeTrue();

            Pages.CheckoutOrderReviewPage.AreProductAttributesCorrect(productColor.ToString(), productSize.ToString(), productQty).Should().BeTrue();

            Console.ReadKey();
        }
    }
}
