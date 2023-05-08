using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvaTradeMobile.Driver;

namespace AvaTradeMobile.PageObjects
{
    public class SignUpPage
    {
        public AndroidElement CountryDropdown => AndroidDriver.Current.FindElement(By.XPath(""));
        public AndroidElement EmailInput => AndroidDriver.Current.FindElement(By.XPath(""));
        public AndroidElement PasswordInput => AndroidDriver.Current.FindElement(By.XPath(""));
    }
}
