using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTradeMobile.Driver
{
    public static class DriverFactory
    {
        public static AndroidDriver<AndroidElement> BuildAndroid()
        {
            var appiumOptions = new AppiumOptions();
            appiumOptions.AddAdditionalCapability("appium:automationName", "UiAutomator2");
            appiumOptions.AddAdditionalCapability("DeviceName", "emulator-5554");
            appiumOptions.AddAdditionalCapability("PlatformName", "Android");
            appiumOptions.AddAdditionalCapability("PlatformVersion", "12.0");
            appiumOptions.AddAdditionalCapability("AppPackage", "com.avatrade.mobile");
            appiumOptions.AddAdditionalCapability("AppActivity", ".AvaTrades");
            appiumOptions.AddAdditionalCapability("appium:ignoreHiddenApiPolicyError", "true");
            appiumOptions.AddAdditionalCapability("appium:app", $"{FW.WORKSPACE_DIRECTORY}\\AvaTradeMobile\\App\\AvaTradeGO.apk");
            return new AndroidDriver<AndroidElement>(new Uri("http://127.0.0.1:4723/"), appiumOptions);
        }

    }
}