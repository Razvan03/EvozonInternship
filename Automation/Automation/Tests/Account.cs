using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Automation.Helpers;
using Automation.Helpers.Enums;
using Automation.Pages;

namespace Automation.Tests
{
    [TestClass]
    public class Account : BaseTest
    {
        [TestInitialize]
        public override void Before()
        {
            base.Before();
            Pages.HeaderPage.GoToAccountDropdownOption(AccountOption.LOG_IN);
            Pages.LoginPage.Login(Constants.VALID_EMAIL, Constants.VALID_PASSWORD);
        }
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
                    Telephone = Faker.PhoneFaker.Phone(),
                    Country = "Romania",
                    State = "Suceava"
                }
            };
        }
        [DynamicData(nameof(BillingData), DynamicDataSourceType.Method)]
        [TestMethod]
        public void ChangeBillingAddress(BillingInformation billingInfo)
        {
            Pages.AccountPage.EditBillingAddress(billingInfo);
        }
    }
}
