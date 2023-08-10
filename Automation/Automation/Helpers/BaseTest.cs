using System.Reflection;
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
                ChromeDriverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)
            });
            Browser.WebDriver.Manage().Window.Maximize();
            Browser.GoTo("http://qa3magento.dev.evozon.com/"); 
        }

        [TestCleanup]
        public virtual void After() 
        {
            if(TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
            {
                var path = ScreenShot.GetScreenShotPath(TestContext.TestName);
                TestContext.AddResultFile(path);
            }
            Browser.Cleanup();
        }
    }
}
