using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            Browser.InitializeDriver();
            Browser.GoToWebsite(Constants.Url);
        }

        [TestCleanup]
        public virtual void After() 
        {
            if(TestContext.CurrentTestOutcome.Equals(UnitTestOutcome.Failed))
            {
                var path = Screenshot.GetScreenShotPath(TestContext.TestName, Browser.GetDriver());
                TestContext.AddResultFile(path);
            }
            Browser.Cleanup();
        }
    }
}
