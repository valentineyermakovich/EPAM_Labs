using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using Framework.Util;

namespace Framework.Driver
{
    public static class DriverManager
    {
        private static ThreadLocal<IWebDriver> _driver = new ThreadLocal<IWebDriver>();

        public static IWebDriver GetWebDriver()
        {
            if (_driver.Value == null)
            {
                switch (TestDataReader.GetTestsSettings().browser.BrowserName)
                {
                    case "firefox":
                        {
                            var firefoxOptions = new FirefoxOptions();
                            firefoxOptions.AddArguments("--headless", "--disable-gpu", "--window-size=1920,1200",
                                "--ignore-certificate-errors", "--disable-extensions", "--no-sandbox", "--disable-dev-shm-usage");
                            _driver.Value = new FirefoxDriver(Directory.GetCurrentDirectory(), firefoxOptions);
                            break;
                        }
                    default:
                        {
                            var chromeOptions = new ChromeOptions();
                            chromeOptions.AddArguments("--headless", "--disable-gpu", "--window-size=1920,1200",
                                "--ignore-certificate-errors", "--disable-extensions", "--no-sandbox", "--disable-dev-shm-usage");
                            _driver.Value = new ChromeDriver(Directory.GetCurrentDirectory(), chromeOptions);
                            break;
                        }
                }
            }

            return _driver.Value;
        }

        public static void CloseWebDriver()
        {
            _driver.Value.Quit();
            _driver.Value = null;
        }
    }
}
