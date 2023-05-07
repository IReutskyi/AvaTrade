using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Selenium
{
    public static class DriverFactory
    {
        public static IWebDriver Build(string browserName, string type)
        {
            if (type.ToLower() == "remote")
            {
                switch (browserName.ToLower())
                {
                    case "chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--headless");
                        chromeOptions.AddArgument("--no-sandbox");
                        chromeOptions.AddArgument("window-size=1920,1080");
                        chromeOptions.AddArgument("--disable-dev-shm-usage");

                        return new RemoteWebDriver(new Uri("http://selenium__standalone-chrome:4444/wd/hub"), chromeOptions);
                    case "firefox":
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AddArgument("--headless");
                        firefoxOptions.AddArgument("--no-sandbox");
                        firefoxOptions.AddArgument("window-size=1920,1080");
                        firefoxOptions.AddArgument("--disable-dev-shm-usage");
                        return new RemoteWebDriver(new Uri("http://selenium__standalone-firefox:4444/wd/hub"), firefoxOptions);
                    default:
                        throw new ArgumentException($"{browserName} not supported");
                }
            }
            else if (type.ToLower() == "local")
            {
                switch (browserName.ToLower())
                {
                    case "chrome":
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArgument("--ignore-certificate-errors");
                        chromeOptions.AddArgument("--disable-dev-shm-usage");
                        chromeOptions.AddArgument("--incognito");
                        chromeOptions.AddArgument("--disable-blink-features=AutomationControlled");
                        chromeOptions.AddAdditionalChromeOption("useAutomationExtension", false);
                        chromeOptions.AddExcludedArgument("enable-automation");
                        chromeOptions.AddArgument("--no-sandbox");
                        return new ChromeDriver(chromeOptions);
                    case "firefox":
                        return new FirefoxDriver();
                    default:
                        throw new ArgumentException($"{browserName} not supported");
                }
            }
            else
            {
                throw new ArgumentException($"{type} is unknown type of browser");
            }
        }
    }
}