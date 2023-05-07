using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTrade.PageObjects
{
    public class MainPage
    {
        public Element RegisterNowButton => Driver.FindElement(By.XPath("//a[text()='Register now']"), "Register Now button");
        public Element LoginButton => Driver.FindElement(By.XPath("//div[@class='log-in-desktop']"), "Login link");
        public Element AllowAllButton => Driver.FindElement(By.XPath("//a[text()='Allow all']"), "Allow All cookies button");

    }
}
