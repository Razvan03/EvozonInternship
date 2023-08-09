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
        public const string URL = "http://qa3magento.dev.evozon.com/";
        public const string VALID_EMAIL = "roman_razvan03@yahoo.com";
        public const string VALID_PASSWORD = "tester1";
        public const string LOGIN_HELLO_MESSAGE = "Hello, Roman Razvan!";
        public const string LOGIN_WELCOME_MESSAGE = "WELCOME, ROMAN RAZVAN!";
        public const string WELCOME_MESSAGE = "WELCOME";
        public static string RANDOM_EMAIL = Internet.Email();
        public static string RANDOM_PASSWORD = StringFaker.Randomize(
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_=+[{]};:'\",<.>/?");

        public const string ADMIN_USERNAME = "testuser";
        public const string ADMIN_PASSWORD = "password123";

        public const string WISHLIST_PRODUCT = "Broad St. Flapover Briefcase";
    }
}
