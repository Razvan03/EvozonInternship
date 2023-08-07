using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NsTestFrameworkUI.Helpers;

[assembly: Parallelize(Workers = 4,
    Scope = ExecutionScope.MethodLevel)]
namespace Automation.Helpers
{
    public class BaseTest
    {
        public TestContext TestContext { get; set; }

        [TestInitialize]
        public virtual void Before()
        {
            Browser.InitializeDriver(new DriverOptions
            {
                IsHeadless = false,
                ChromeDriverPath = @"D:\SeleniumDrivers\chromedriver-win64 115"
            });
            Browser.WebDriver.Manage().Window.Maximize();
            Browser.GoTo("http://qa3magento.dev.evozon.com/"); 
        }

        [TestCleanup]
        public virtual void After() 
        {
            if(TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
            {
                var path = Screenshot.GetScreenShotPath(TestContext.TestName,Browser.WebDriver);
                TestContext.AddResultFile(path);
            }
            Browser.Cleanup();
        }
    }
}
