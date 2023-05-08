using AvaTradeMobile.Driver;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTradeMobile.PageObjects
{
    public class MainPage
    {
        public AndroidElement RegisterNowButton => AndroidDriver.Current.FindElement(By.Id("onboarding_avatrade_email_registration"));

    }
}
