using OpenQA.Selenium;

namespace Framework.Selenium
{
    public static class Driver
    {

        private static IWebDriver _driver;

        public static Wait Wait;

        public static void Init()
        {
            _driver = DriverFactory.Build(FW.Config.Driver.Browser, FW.Config.Driver.BrowserType);
            Wait = new Wait(FW.Config.Driver.WaitSeconds);
            _driver.Manage().Window.Maximize();
        }

        public static IWebDriver Current => _driver ?? throw new NullReferenceException("_driver is null.");

        public static void GoTo(string url)
        {
            if (!url.StartsWith("http://") && !url.StartsWith("https://"))
            {
                url = $"https://{url}";
            }

            Current.Navigate().GoToUrl(url);
        }

        public static string GetCurrentUrl()
        {
            return Current.Url;
        }

        public static void TakeScreenshot(string imageName)
        {
            var ss = ((ITakesScreenshot)Current).GetScreenshot();
            var ssFileName = Path.Combine(FW.WORKSPACE_DIRECTORY + "/AvaTrade/TestResult/", imageName);
            ss.SaveAsFile($"{ssFileName}.png", ScreenshotImageFormat.Png);
        }

        public static void Quit()
        {
            Current.Quit();
        }

        public static Element FindElement(By by, string elementName)
        {
            return new Element(Current.FindElement(by), elementName)
            {
                FoundBy = by
            };
        }

        public static Elements FindElements(By by, string elementName)
        {
            return new Elements(Current.FindElements(by), elementName)
            {
                FoundBy = by
            };
        }
    }
}
