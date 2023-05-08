using AvaTradeMobile;
using AvaTradeMobile.Driver;
using AvaTradeMobile.PageObjects;
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
            AndroidDriver.Init();
            Pages.Init();
        }

        [TearDown]
        public virtual void AfterEach()
        {
            AndroidDriver.Quit();
        }
    }
}
