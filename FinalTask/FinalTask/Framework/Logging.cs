using OpenQA.Selenium;
using Serilog;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalTask.Framework
{
    public class Logging
    {


        public static Logger CreateLogger(string logFileName)
        {
            return new LoggerConfiguration()
                .WriteTo.Console()
                .MinimumLevel.Debug()
                .WriteTo.File(logFileName)
                .CreateLogger();
        }

        public static void SaveScreenshotToFolder(IWebDriver driver, string path, string filename)
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            screenshot.SaveAsFile(Path.Combine(path, filename));
        }
    }
}
