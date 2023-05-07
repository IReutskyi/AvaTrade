using AvaTrade.Base;
using AvaTrade.PageObjects;
using Framework.Selenium;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTrade.Tests
{
    public class SignUpTests : TestBase
    {
        [Test]
        [TestCase("Afghanistan", "reutskyitest+15@gmail.com")]
        [TestCase("France", "reutskyitest+16@gmail.com")]
        public void Verify_sign_up__completes_successful(string country, string email)
        {
            Pages.MainPage.LoginButton.Click();
            Driver.Wait.Until(drv => Pages.LoginPage.EmailInput.Displayed);
            Pages.LoginPage.EmailInput.SendKeys(email);
            Pages.LoginPage.PasswordInput.SendKeys("testTest1");
            Pages.LoginPage.LoginButton.Click();

            //Pages.MainPage.RegisterNowButton.Click();
            //Driver.Wait.Until(drv => Pages.SignUpPage.EmailInput.Displayed);
            //Pages.SignUpPage.EmailInput.SendKeys("reutskyitest+11@gmail.com");
            //Pages.SignUpPage.PasswordInput.SendKeys("testTest1");
            //Pages.SignUpPage.CreateMyAccountButton.Click();

            Driver.Wait.Until(drv => Pages.SignUpPage.IFrameRegistration.Displayed);
            Pages.SignUpPage.SwitchToRegistrationIFrame();

            Driver.Wait.Until(drv => Pages.SignUpPage.FirstNameInput.Displayed);
            Pages.SignUpPage.FillInPersonalDetails(Faker.Name.First(), Faker.Name.Last(), "1995-12-22", "668128180", country);
            Pages.SignUpPage.SubmitButton.Click();

            Driver.Wait.Until(drv => Pages.SignUpPage.PrincipalOccupationDropdown.Displayed);
            Pages.SignUpPage.FillInFinancialDetailsByRandom();
            Pages.SignUpPage.SubmitButton.Click();

            try
            {
                Driver.Wait.Until(drv => Pages.SignUpPage.TradeExpirienceDropdown.Displayed);
                Pages.SignUpPage.FillInTradingExperienceInfo();
                Pages.SignUpPage.SubmitButton.Click();
            }
            catch { }

            Driver.Wait.Until(drv => Pages.SignUpPage.TermAndConditionsLink.Displayed);
            Pages.SignUpPage.AcceptTerms();
            Pages.SignUpPage.SubmitButton.Click();

            try
            {
                Driver.Wait.Until(drv => Pages.SignUpPage.AgreeCheckbox.Displayed);
                Pages.SignUpPage.AgreeCheckbox.Click();
                Thread.Sleep(300);
                Pages.SignUpPage.CompleteRegistrationButtonOnWarning.Click();
            }
            catch { }

            try
            {
                Driver.Wait.Until(drv => Pages.DepositPage.IFrameDeposit.Displayed);
                Pages.DepositPage.SwitchToDepositIFrame();
                Assert.True(Pages.DepositPage.ChooseDepositLabel.Displayed);
            }
            catch
            {
                Driver.Wait.Until(drv => Pages.SignUpPage.CrossButtonOnAlmostThere.Displayed);
                Pages.SignUpPage.CrossButtonOnAlmostThere.Click();
            }
        }
    }
}
