using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation.Helpers
{
    public static class Screenshot
    {
        public static string GetScreenShotPath(string testName, IWebDriver driver)
        {
            string folderPath = "D:\\Evozon\\Github Repository\\Screenshots";
            ITakesScreenshot takesScreenshot = (ITakesScreenshot)driver;

            var screenshot = takesScreenshot.GetScreenshot();
            string path = $"{folderPath}/{testName}.png";
            screenshot.SaveAsFile(path, ScreenshotImageFormat.Png);

            return path;
        }
    }
}
