using AvaTrade.Base;
using AvaTradeMobile.Driver;
using AvaTradeMobile.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTradeMobile.Tests
{
    public class SignUpTest : TestBase
    {
        [Test]
        [TestCase("Afghanistan")]
        [TestCase("France")]
        public void Verify_sign_up_completes_successful_android(string country)
        {
            Random rnd = new Random();
            int number = rnd.Next(1, 1000);

            AndroidDriver.Wait.Until(drv => Pages.MainPage.CreateAnAccountButton.Displayed);
            Pages.MainPage.CreateAnAccountButton.Click();
            AndroidDriver.Wait.Until(drv => Pages.SignUpPage.CountryDropdown.Displayed);
            Pages.SignUpPage.SelectCountry(country);
            Pages.SignUpPage.EnterEmail($"test+{number}@mail.com");
            Pages.SignUpPage.EnterPassword("testTest1");
            Pages.SignUpPage.CreateMyAccount.Click();

            AndroidDriver.Wait.Until(drv => Pages.SignUpPage.FirstNameInput.Displayed);
            Pages.SignUpPage.EnterFirstName("TestFirstName");
            Pages.SignUpPage.EnterLastName("TestLastName");
            Pages.SignUpPage.EnterBirthDay("22-12-1995");
            Pages.SignUpPage.EnterPhone("668128180");
            Pages.SignUpPage.ContinueButton.Click();

            AndroidDriver.Wait.Until(drv => Pages.SignUpPage.CityInput.Displayed);
            Pages.SignUpPage.EnterCity("TestCity");
            Pages.SignUpPage.EnterStreet("TestStreet");
            Pages.SignUpPage.EnterNumber("TestNumber");
            Pages.SignUpPage.EnterApartment("TestApartment");
            Pages.SignUpPage.EnterPostalCode("12435");
            Pages.SignUpPage.SelectCurrency("USD");
            Pages.SignUpPage.ContinueButton.Click();

            AndroidDriver.Wait.Until(drv => Pages.SignUpPage.PrimaryOccupationDropdown.Displayed);
            Pages.SignUpPage.SelectOccupation("Agriculture");
            Pages.SignUpPage.SelectEmploymentStatus("Employed");
            Pages.SignUpPage.SelectFundsSource("Real Estate");
            Pages.SignUpPage.SelectEstimatedIncome("100,000+");
            Pages.SignUpPage.ContinueButton.Click();
            AndroidDriver.Wait.Until(drv => Pages.SignUpPage.EstimatedValueDropdown.Displayed);
            Pages.SignUpPage.SelectEstimatedValue("500,000+");
            Pages.SignUpPage.SelectInvestAmount("100,000+");
            Pages.SignUpPage.ContinueButton.Click();

            if(country == "France")
            {
                Pages.SignUpPage.SelectExperienceYesNo(true);
                Pages.SignUpPage.SelectExpectExperience("1-10");
                Pages.SignUpPage.SelectValueTrades("1-999");
                Pages.SignUpPage.ContinueButton.Click();

                AndroidDriver.Wait.Until(drv => Pages.SignUpPage.LeverageDropdown.Displayed);
                Pages.SignUpPage.SelectLeverage("It may increase");
                Pages.SignUpPage.SelectSizePosition("50,000");
                Pages.SignUpPage.SelectClosePosition("The market is moving");
                Pages.SignUpPage.ContinueButton.Click();

                AndroidDriver.Wait.Until(drv => Pages.SignUpPage.PrimaryPurposeDropdown.Displayed);
                Pages.SignUpPage.SelectPurpose("Intraday trading");
                Pages.SignUpPage.RisksCheckbox.Click();
                Pages.SignUpPage.ContinueButton.Click();


            }

            AndroidDriver.Wait.Until(drv => Pages.SignUpPage.AcceptTermsToggle.Displayed);
            Pages.SignUpPage.AcceptTermsToggle.Click();
            Pages.SignUpPage.FinishButton.Click();
            if (country == "France")
            {
                Thread.Sleep(1000);
                AndroidDriver.Wait.Until(drv => Pages.SignUpPage.AgreeCheckbox.Displayed);
                Pages.SignUpPage.AgreeCheckbox.Click();
                Pages.SignUpPage.CompleteRegistrationButton.Click();
                AndroidDriver.Wait.Until(drv => Pages.SignUpPage.VerifyAccountButton.Displayed);
            }
            else
            {
                AndroidDriver.Wait.Until(drv => Pages.SignUpPage.FundAccountButton.Displayed);
            }
        }
    }
}
