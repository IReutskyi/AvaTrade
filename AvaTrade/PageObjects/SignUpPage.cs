using FluentAssertions;
using Framework.Selenium;
using Microsoft.CodeAnalysis.CSharp;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTrade.PageObjects
{
    public class SignUpPage
    {
        //Step 1
        public Element EmailInput => Driver.FindElement(By.Id("input-email"), "Input email");
        public Element PasswordInput => Driver.FindElement(By.Id("input-password"), "Password email");
        public Element CreateMyAccountButton => Driver.FindElement(By.Id("btn_ga_real_main menu_cfd"), "Create My Account button");

        //Step 2 - Personal Details
        public Element IFrameRegistration => Driver.FindElement(By.XPath("//iframe[contains(@src, 'registration')]"), "IFrame registration");
        public Element FirstNameInput => Driver.FindElement(By.XPath("//input[@name='FirstName']"), "First Name input");
        public Element LastNameInput => Driver.FindElement(By.XPath("//input[@name='LastName']"), "Last Name input");
        public Element DateOfBirthInput => Driver.FindElement(By.XPath("//input[@name='DateOfBirth']"), "Date of Birth input");
        public Element CountryInput => Driver.FindElement(By.XPath("//input[@name='Country']"), "Country input");
        public Element AddressInput => Driver.FindElement(By.XPath("//input[@name='Address']"), "Address input");
        public Element CityInput => Driver.FindElement(By.XPath("//input[@name='City']"), "City input");
        public Element StreetInput => Driver.FindElement(By.XPath("//input[@name='Street']"), "Street input");
        public Element BuildingNumberInput => Driver.FindElement(By.XPath("//input[@name='BuildingNumber']"), "Number input");
        public Element FlatInput => Driver.FindElement(By.XPath("//input[@name='Flat']"), "Flat input");
        public Element ZipInput => Driver.FindElement(By.XPath("//input[@name='ZipCode']"), "ZipCode input");
        public Element EnterAddressButton => Driver.FindElement(By.XPath("//div[text()='Or Enter Address Manually']"), "Enter Address Manually");
        public Element PhoneInput => Driver.FindElement(By.XPath("//input[@name='Phone']"), "Phone input");
        public Element SubmitButton => Driver.FindElement(By.XPath("//button[@type='submit']"), "Submit input");

        public void SwitchToRegistrationIFrame()
        {
            Driver.Current.SwitchTo().Frame(0);
        }

        public void FillInPersonalDetails(string firstName, string lastName, string dateOfBirth, string phoneNumber, string country = "Random")
        {
            FirstNameInput.SendKeys(firstName);
            LastNameInput.SendKeys(lastName);
            if (country != "Random")
            {
                SelectCountryByName(country);
            }
            else
            {
                SelectRandomCountry();
            }
            EnterBirthDay(dateOfBirth);
            EnterAddressButton.Click();
            EnterRandomAddress();
            PhoneInput.SendKeys(phoneNumber);
        }

        public void EnterRandomAddress()
        {
            CityInput.SendKeys(Faker.Address.City());
            StreetInput.SendKeys(Faker.Address.StreetName());
            BuildingNumberInput.SendKeys(Faker.RandomNumber.Next(1, 100).ToString());
            FlatInput.SendKeys(Faker.Address.SecondaryAddress());
            ZipInput.SendKeys(Faker.Address.ZipCode());
        }
        public void SelectRandomCountry()
        {
            throw new NotImplementedException();
        }

        public void SelectCountryByName(string countryName)
        {
            Actions actions = new Actions(Driver.Current);
            CountryInput.Click();
            actions.SendKeys(Keys.Backspace).Perform();
            CountryInput.SendKeys(countryName);
            actions.SendKeys(Keys.Enter).Perform();
        }

        public void EnterBirthDay(string dateOfBirth)
        {
            var date = DateTime.Parse(dateOfBirth);
            DateOfBirthInput.Click();
            var year = Driver.FindElement(By.XPath($"//li[text()='{date.Year}']"), $"{date.Year} year");
            year.ScrollElementToCenter();
            Thread.Sleep(500);
            year.Click();
            var months = Driver.FindElements(By.XPath($"//div[@class='v-date-picker-table v-date-picker-table--month theme--light']//ancestor::td"), $"Months");
            months[date.Month - 1].Click();
            var days = Driver.FindElements(By.XPath($"//div[@class='v-date-picker-table v-date-picker-table--date theme--light']//ancestor::td"), $"Days");
            days[date.Day - 1].Click();

            DateOfBirthInput.GetDomProperty("value").Should().Be(dateOfBirth);
        }

        //Step 3 - Financial Details
        public Element PrincipalOccupationDropdown => Driver.FindElement(By.XPath("//label[text()='Principal Occupation']/parent::div"), "Principal Occupation dropdown");
        public Element SelectPrincipalOccupationOption(string option) => Driver.FindElement(By.XPath($"//div[@label='Principal Occupation']//div[text()='{option}']"), $"Principal Occupation {option} option");

        public Element TotalIncomeDropdown => Driver.FindElement(By.XPath("//label[text()='What is your total estimated annual income?']/parent::div"), "Total Income dropdown");
        public Element SelectTotalIncomeOption(string option) => Driver.FindElement(By.XPath($"//div[@label='What is your total estimated annual income?']//div[text()='{option}']"), $"Total Income {option} option");

        public Element EmploymentStatusDropdown => Driver.FindElement(By.XPath("//label[text()='What is your current employment status?']/parent::div"), "Employment Status dropdown");
        public Element TradingSourceDropdown => Driver.FindElement(By.XPath("//label[text()='Source of Trading funds']/parent::div"), "Source of Trading funds dropdown");
        public Element TradingPlatformDropdown => Driver.FindElement(By.XPath("//label[text()='Trading Platform']/parent::div"), "Tranding Platform dropdown");
        public Element CurrencyDropdown => Driver.FindElement(By.XPath("//label[text()='Base Currency']/parent::div"), "Source of Trading funds dropdown");

        public void FillInFinancialDetailsByRandom()
        {
            SelectRandomPrincipalOccupation();
            SelectRandomEmploymentStatus();
            SelectRandomTrandingSource();
            SelectRandomTotalIncome();
            SelectRandomEstimatedInvestments();
            SelectRandomIntendAmount();
            try
            {
                SelectRandomTrandingPlatform();
                SelectRandomCurrency();
            }
            catch { }

        }
        Random rm = new Random();
        public void SelectRandomPrincipalOccupation()
        {
            PrincipalOccupationDropdown.Click();
            Thread.Sleep(500);
            var principalOccipationOptions = Driver.FindElements(By.XPath($"//div[@id='question-1_15']//div[@role='option']"), $"Principal Occupation options");
            principalOccipationOptions[rm.Next(0, principalOccipationOptions.Count - 1)].Click();
        }
        public void SelectRandomTotalIncome()
        {
            var totalIncomeOptions = Driver.FindElements(By.XPath($"//div[@id='question-3_88']//div[@class='v-radio theme--light']"), "Total income options");
            if (totalIncomeOptions.Count == 0)
            {
                TotalIncomeDropdown.Click();
                totalIncomeOptions = Driver.FindElements(By.XPath("//div[@id='question-2_16']//div[@role='option']"), $"Total income options");
            }
            totalIncomeOptions[rm.Next(0, totalIncomeOptions.Count - 1)].Click();
        }

        public void SelectRandomEstimatedInvestments()
        {
            var investmentsOptions = Driver.FindElements(By.XPath($"//div[@id='question-3_89']//div[@class='v-radio theme--light']"), "Investments options");
            if (investmentsOptions.Count == 0)
            {
                investmentsOptions = Driver.FindElements(By.XPath($"//div[@id='question-4_89']//div[@class='v-radio theme--light']"), "Investments options");
            }
            investmentsOptions[rm.Next(0, investmentsOptions.Count - 1)].Click();
        }

        public void SelectRandomIntendAmount()
        {
            var intendAmountOptions = Driver.FindElements(By.XPath($"//div[@id='question-4_90']//div[@class='v-radio theme--light']"), "Intend Amount options");
            if (intendAmountOptions.Count == 0)
            {
                intendAmountOptions = Driver.FindElements(By.XPath($"//div[@id='question-5_90']//div[@class='v-radio theme--light']"), "Intend Amount options");
            }
            intendAmountOptions[rm.Next(0, intendAmountOptions.Count - 1)].Click();
        }

        public void SelectRandomEmploymentStatus()
        {
            EmploymentStatusDropdown.Click();
            Thread.Sleep(500);
            var employmentStatusOptions = Driver.FindElements(By.XPath("//div[@id='question-5_91']//div[@role='option']"), "Employment status options");
            if (employmentStatusOptions.Count == 0)
            {
                employmentStatusOptions = Driver.FindElements(By.XPath("//div[@id='question-2_91']//div[@role='option']"), "Employment status options");
            }
            employmentStatusOptions[rm.Next(0, employmentStatusOptions.Count -1)].Click();
        }

        public void SelectRandomTrandingSource()
        {
            TradingSourceDropdown.Click();
            var trandingSourceOptions = Driver.FindElements(By.XPath("//div[@id='question-6_18']//div[@role='option']"), "Tranding status options");
            trandingSourceOptions[rm.Next(0, trandingSourceOptions.Count - 1)].Click();
        }

        public void SelectRandomTrandingPlatform()
        {
            TradingPlatformDropdown.Click();
            var trandingPlatformOptions = Driver.FindElements(By.XPath("//div[@id='question-7_188']//div[@role='option']"), "Tranding Platform options");
            trandingPlatformOptions[rm.Next(0, trandingPlatformOptions.Count -1)].Click();
        }
        public void SelectRandomCurrency()
        {
            CurrencyDropdown.Click();
            var currencyOptions = Driver.FindElements(By.XPath("//div[@id='question-8_189']//div[@role='option']"), "Currency options");
            currencyOptions[rm.Next(0, currencyOptions.Count)].Click();
        }

        //Step (optional) - Trading Experience & Knowledge
        public Element TradeExpirienceDropdown => Driver.FindElement(By.XPath("//div[@id='question-1_82']"), "Trade expirience dropdown");
        public Element AvarageVolumeDropdown => Driver.FindElement(By.XPath("//div[@id='question-2_83']"), "Avarege volume dropdown");
        public Element LeverageDropdown => Driver.FindElement(By.XPath("//div[@id='question-4_85']"), "Leverage dropdown");
        public Element MaxPositionDropdown => Driver.FindElement(By.XPath("//div[@id='question-5_86']"), "Maximum position dropdown");
        public Element ClosePositionDropdown => Driver.FindElement(By.XPath("//div[@id='question-6_87']"), "Close position dropdown");
        public Element WhyWishTradeDropdown => Driver.FindElement(By.XPath("//div[@id='question-9_294']"), "Why do you wish trade dropdown");
        public Element ConfirmCheckbox => Driver.FindElement(By.XPath("//input[@id='question-11_297']//parent::div"), "Confirm checkbox");

        public void FillInTradingExperienceInfo()
        {
            SelectRandomTradeExpirience();
            SelectRandomAvarageVolume();
            SelectRandomEducationOption();
            SelectRandomLeverage();
            SelectRandomMaxPosition();
            SelectRandomClosePosition();
            SelectRandomTrandingPlatform();
            SelectRandomCurrency();
            SelectRandomWish();
            ConfirmRisks();
        }

        public void SelectRandomTradeExpirience()
        {
            TradeExpirienceDropdown.Click();
            Thread.Sleep(500);
            var tradeExpirienceOptions = Driver.FindElements(By.XPath($"//div[@id='question-1_82']//div[@role='option']"), $"Trade Expirience options");
            tradeExpirienceOptions[rm.Next(0, tradeExpirienceOptions.Count - 1)].Click();
        }

        public void SelectRandomAvarageVolume()
        {
            AvarageVolumeDropdown.Click();
            Thread.Sleep(500);
            var tradeExpirienceOptions = Driver.FindElements(By.XPath($"//div[@id='question-2_83']//div[@role='option']"), $"Avarage Volume options");
            tradeExpirienceOptions[rm.Next(0, tradeExpirienceOptions.Count - 1)].Click();
        }

        public void SelectRandomEducationOption()
        {
            var tradeExpirienceOptions = Driver.FindElements(By.XPath($"//div[@id='question-3_84']//div[@class='v-radio theme--light']"), $"Education options");
            tradeExpirienceOptions[rm.Next(0, tradeExpirienceOptions.Count - 1)].Click();
        }

        public void SelectRandomLeverage()
        {
            LeverageDropdown.Click();
            Thread.Sleep(500);
            var leverageOptions = Driver.FindElements(By.XPath($"//div[@id='question-4_85']//div[@role='option']"), $"Leverage options");
            leverageOptions[rm.Next(0, leverageOptions.Count - 1)].Click();
        }

        public void SelectRandomMaxPosition()
        {
            MaxPositionDropdown.Click();
            Thread.Sleep(500);
            var maxPositionOptions = Driver.FindElements(By.XPath($"//div[@id='question-5_86']//div[@role='option']"), $"Max position options");
            maxPositionOptions[rm.Next(0, maxPositionOptions.Count - 1)].Click();
        }

        public void SelectRandomClosePosition()
        {
            ClosePositionDropdown.Click();
            Thread.Sleep(500);
            var closePositionOptions = Driver.FindElements(By.XPath($"//div[@id='question-6_87']//div[@role='option']"), $"Close position options");
            closePositionOptions[rm.Next(0, closePositionOptions.Count - 1)].Click();
        }

        public void SelectRandomWish()
        {
            WhyWishTradeDropdown.Click();
            Thread.Sleep(500);
            var whyOptions = Driver.FindElements(By.XPath($"//div[@id='question-9_294']//div[@role='option']"), $"Why do you wish trade options");
            whyOptions[rm.Next(0, whyOptions.Count - 1)].Click();
        }

        public void ConfirmRisks()
        {
            ConfirmCheckbox.Click();
        }

        //Step 4 - Terms & Conditions
        public Element TermAndConditionsToggl => Driver.FindElement(By.XPath("//input[@name='TermsAndConditions']/parent::div"), "Terms and Conditions toggl");
        public Element TermAndConditionsLink => Driver.FindElement(By.XPath("//a[text()=' Terms and Conditions']"), "Terms and Conditions link");
        public Element CompleteRegistrationButton => Driver.FindElement(By.XPath("//button[@type='submit']"), "Complete Registration button");

        public void AcceptTerms()
        {
            TermAndConditionsToggl.Click();
        }

        //Step - Warning
        public Element AgreeCheckbox => Driver.FindElement(By.XPath("//input[@type='checkbox']//parent::div"), "Agree checkbox");
        public Element CompleteRegistrationButtonOnWarning => Driver.FindElement(By.XPath("//button/span[text()='Complete Registration']"), "Agree checkbox");

        //Step - Almost there
        public Element CrossButtonOnAlmostThere => Driver.FindElement(By.XPath("//button[@id='btn_skip']"), "Cross button");
    }
}
