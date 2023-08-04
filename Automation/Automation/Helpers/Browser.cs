using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Helpers
{
    public static class Browser
    {
        private static IWebDriver driver;

        public static IWebDriver GetDriver() => driver;

        public static void InitializeDriver()
        {
            driver = new ChromeDriver();
        }
        public static void GoToWebsite(string url)
        {
            
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(url);
        }
        public static void Cleanup()
        {
            driver.Quit();
        }
    }
}
