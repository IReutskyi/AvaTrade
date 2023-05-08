using AvaTrade.Base;
using AvaTradeMobile.Driver;
using AvaTradeMobile.PageObjects;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTradeMobile.Tests
{
    public class SignUpTest : TestBase
    {
        [Test]
        public void Test()
        {
            AndroidDriver.Wait.Until(drv => Pages.MainPage.RegisterNowButton.Displayed);
            Pages.MainPage.RegisterNowButton.Click();
            Pages.SignUpPage.CountryDropdown.Click();
            Pages.SignUpPage.EmailInput.SendKeys("test+958@mail.com");
            Pages.SignUpPage.PasswordInput.SendKeys("testTEst1");

            Console.Read();
        }
    }
}
