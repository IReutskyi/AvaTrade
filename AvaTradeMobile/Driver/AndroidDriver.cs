using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTradeMobile.Driver
{
    public static class AndroidDriver
    {
        private static AndroidDriver<AndroidElement> _driver;
        public static Wait Wait;

        public static void Init()
        {
            _driver = DriverFactory.BuildAndroid();
            Wait = new Wait(FW.Config.Driver.WaitSeconds);
        }
        
        public static AndroidDriver<AndroidElement> Current => _driver ?? throw new NullReferenceException("_driver is null.");
        public static void Quit()
        {
            Current.Quit();
        }

    }
}
