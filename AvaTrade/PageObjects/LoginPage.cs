using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTrade.PageObjects
{
    public class LoginPage
    {
        //Step 1
        public Element EmailInput => Driver.FindElement(By.Id("input-email"), "Input email");
        public Element PasswordInput => Driver.FindElement(By.Id("input-password"), "Password email");
        public Element LoginButton => Driver.FindElement(By.Id("btn_ga_real_main menu_cfd"), "Login button");
    }
}
