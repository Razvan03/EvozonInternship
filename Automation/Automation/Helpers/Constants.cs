using Faker;

namespace Automation.Helpers
{
    public static class Constants
    {
        public const string URL = "http://qa3magento.dev.evozon.com/";

        public const string VALID_EMAIL = "roman_razvan03@yahoo.com";
        public const string VALID_PASSWORD = "tester1";
        public const string VALID_FULL_NAME = "Roman Razvan";

        public const string LOGIN_HELLO_MESSAGE = "Hello, Roman Razvan!";
        public const string HEADER_LOGGED_OUT_MESSAGE = "WELCOME, ROMAN RAZVAN!";
        public const string HEADER_LOGGED_IN_MESSAGE = "WELCOME";
        public const string LOGOUT_MESSAGE = "YOU ARE NOW LOGGED OUT";

        public static string RANDOM_EMAIL = Internet.Email();
        public static string RANDOM_PASSWORD = StringFaker.Randomize(
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()-_=+[{]};:'\",<.>/?");

        public static string ADMIN_USERNAME = "testuser";
        public static string ADMIN_PASSWORD = "password123";
        public static string OrderPlacedWithSuccessMessage = "YOUR ORDER HAS BEEN RECEIVED.";
    }
}
