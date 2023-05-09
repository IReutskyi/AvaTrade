using AvaTrade.Base;
using AvaTrade.PageObjects;
using FluentAssertions;
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
    [Category("SignUp")]
    public class SignUpTests : TestBase
    {
        [Test]
        [TestCase("Afghanistan")]
        [TestCase("France")]
        public void Verify_sign_up_completes_successful(string country)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 1000);

            Pages.MainPage.RegisterNowButton.Click();
            Driver.Wait.Until(drv => Pages.SignUpPage.EmailInput.Displayed);
            Pages.SignUpPage.EmailInput.SendKeys($"avatradetest+{number}@gmail.com");
            Pages.SignUpPage.PasswordInput.SendKeys("testTest1");
            Pages.SignUpPage.CreateMyAccountButton.Click();

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

            if (country == "Afghanistan")
            {
                try
                {
                    Driver.Wait.Until(drv => Pages.SignUpPage.AccountReadyLabel.Displayed);
                    Pages.SignUpPage.FundMyAccountButton.Click();
                }
                catch { }

                Driver.Wait.Until(drv => Pages.DepositPage.IFrameDeposit.Displayed);
                Pages.DepositPage.SwitchToDepositIFrame();
                Driver.Wait.Until(drv => Pages.DepositPage.NotificationLabel.Displayed);
            }
            else
            {
                Driver.Wait.Until(drv => Pages.SignUpPage.CrossButtonOnAlmostThere.Displayed);
                Pages.SignUpPage.CrossButtonOnAlmostThere.Click();
            }
        }

        [Test]
        [TestCase("test@test", "test")]
        [TestCase("test@.com", "123456")]
        public void Verify_validation_messages_displayed(string email, string password)
        {
            Pages.MainPage.RegisterNowButton.Click();
            Driver.Wait.Until(drv => Pages.SignUpPage.EmailInput.Displayed);
            Pages.SignUpPage.EmailInput.SendKeys(email);
            Pages.SignUpPage.PasswordInput.SendKeys(password);

            Pages.SignUpPage.EmailErrorMessage.Text.Should().Be("Please enter a valid email");
            Assert.True(Pages.SignUpPage.PasswordMessage.Displayed, "Password rules are not displayed");
        }
    }
}
