using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faker;

namespace Automation.Helpers
{
    public static class Constants
    {
        public const string Url = "http://qa3magento.dev.evozon.com/";
        public const string email = "roman_razvan03@yahoo.com";
        public const string password = "tester1";
        public const string myWelcomeText = "Hello, Roman Razvan!";
        public static string RANDOM_PASSWORD = StringFaker.Randomize(
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_=+[{]};:'\",<.>/?");

        public static string ADMIN_USERNAME = "testuser";
        public static string ADMIN_PASSWORD = "password123";

        public static string WISHLIST_PRODUCT = "Broad St. Flapover Briefcase";
    }
}
