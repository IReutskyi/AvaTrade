using AvaTrade.PageObjects;
using AventStack.ExtentReports;
using Framework;
using Framework.Selenium;
using Framework.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;

namespace AvaTrade.Base
{
    public abstract class TestBase
    {
        [OneTimeSetUp]
        public virtual void DeforeAll()
        {
            FW.SetConfig();
        }

        [SetUp]
        public virtual void BeforeEach()
        {
            Driver.Init();
            Pages.Init();

            var cookies = new Cookie("CookieConsent",
                "{stamp:%27g5a4EHCAHEZESEjy9ShEcmRpx5ptDTRYO56PEw+AYbLrwRY0LVfiBA==%27%2Cnecessary:true%2Cpreferences:true%2Cstatistics:true%2Cmarketing:true%2Cmethod:%27explicit%27%2Cver:1%2Cutc:1683102746537%2Cregion:%27bg%27}",
                "avatrade.com", "/",
                new DateTime(2024, 04, 18));

            Driver.GoTo("https://www.avatrade.com/about");

            Driver.Current.Manage().Cookies.AddCookie(cookies);
            Driver.GoTo(FW.Config.Test.Url);
        }

        [TearDown]
        public virtual void AfterEach()
        {
            var outcome = TestContext.CurrentContext.Result.Outcome.Status;
            var testName = TestContext.CurrentContext.Test.Name;
            testName = Utilities.ReplaceQuotesInFilePath(testName);
            if (outcome == TestStatus.Failed)
            {
                Driver.TakeScreenshot("test_failed" + testName);
            }

            Driver.Quit();
        }
    }
}
