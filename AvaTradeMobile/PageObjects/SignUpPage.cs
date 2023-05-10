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
        //Step 2 - Credentials
        public AndroidElement CountryDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.view.View[@resource-id='question-5_250']//android.widget.EditText"));
        public AndroidElement EmailInput => AndroidDriver.Current.FindElement(By.XPath("//android.view.View[@resource-id='question-6_246']//android.widget.EditText"));
        public AndroidElement PasswordInput => AndroidDriver.Current.FindElement(By.XPath("//android.view.View[@resource-id='question-7_36']//android.widget.EditText"));
        public AndroidElement CreateMyAccount => AndroidDriver.Current.FindElement(By.XPath("//android.view.View[@resource-id='scroll-target']/android.view.View/android.view.View/android.view.View/android.widget.Button"));

        public void SelectCountry(string country)
        {
            CountryDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
            CountryDropdown.Clear();
            CountryDropdown.SendKeys(country);
            AndroidDriver.Current.PressKeyCode(new KeyEvent(AndroidKeyCode.Enter));
            Thread.Sleep(1000);
        }

        public void EnterEmail(string email) 
        {
            EmailInput.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
            EmailInput.SendKeys(email);
        }

        public void EnterPassword(string password)
        {
            PasswordInput.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
            PasswordInput.SendKeys(password);
        }

        //Step 2 - Your Personal Details
        public AndroidElement FirstNameInput => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-1_247']"));
        public AndroidElement LastNameInput => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-2_248']"));
        public AndroidElement DayInput => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='date-day']"));
        public AndroidElement MonthInput => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='date-month']"));
        public AndroidElement YearInput => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='date-year']"));
        public AndroidElement PhoneNumberInput => AndroidDriver.Current.FindElement(By.XPath("//android.view.View[@resource-id='question-4_245']//android.view.View[@text='Phone Number']/following-sibling::android.widget.EditText"));
        public AndroidElement ContinueButton => AndroidDriver.Current.FindElement(By.XPath("//android.widget.Button[@text='Continue']"));

        public void EnterFirstName(string firstName)
        {
            FirstNameInput.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
            FirstNameInput.SendKeys(firstName);
        }
        public void EnterLastName(string lastName)
        {
            LastNameInput.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
            LastNameInput.SendKeys(lastName);
        }

        public void EnterBirthDay(string birthDay)
        {
            var date = DateTime.Parse(birthDay);
            DayInput.Click();
            DayInput.SendKeys($"{date.Day}");
            MonthInput.Click();
            MonthInput.SendKeys($"{date.Month}");
            YearInput.Click();
            YearInput.SendKeys($"{date.Year}");
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
        }

        public void EnterPhone(string phoneNumber)
        {
            PhoneNumberInput.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
            PhoneNumberInput.SendKeys(phoneNumber);
        }

        //Step 2 - Your Personal Details (2)
        public AndroidElement CityInput => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-3_3']"));
        public AndroidElement StreetNameInput => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-4_94']"));
        public AndroidElement NumberInput => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-5_95']"));
        public AndroidElement ApartmentInput => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-6_96']"));
        public AndroidElement PostalCodeInput => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-7_5']"));
        public AndroidElement CurrencyDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.view.View[@resource-id='question-8_189']"));

        public void EnterCity(string city)
        {
            CityInput.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
            CityInput.SendKeys(city);
        }

        public void EnterStreet(string street)
        {
            StreetNameInput.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
            StreetNameInput.SendKeys(street);
        }

        public void EnterNumber(string number)
        {
            NumberInput.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
            NumberInput.SendKeys(number);
        }

        public void EnterApartment(string apartment)
        {
            ApartmentInput.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
            ApartmentInput.SendKeys(apartment);
        }

        public void EnterPostalCode(string zip)
        {
            PostalCodeInput.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.IsKeyboardShown());
            AndroidDriver.Current.HideKeyboard();
            PostalCodeInput.SendKeys(zip);
        }

        public void SelectCurrency(string currency)
        {
            CurrencyDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{currency}')]")).Click();
        }

        //Step 3 - Your Financial Details 
        public AndroidElement PrimaryOccupationDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-1_15']"));
        public AndroidElement EmploymentStatusDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-2_91']"));
        public AndroidElement FundsSourceDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-3_18']"));
        public AndroidElement EstimatedIncomeDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-4_16']"));
        public AndroidElement EstimatedIncomeFranceDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-4_88']"));

        public void SelectOccupation(string occupation)
        {
            PrimaryOccupationDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{occupation}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{occupation}')]")).Click();
        }

        public void SelectEmploymentStatus(string status)
        {
            EmploymentStatusDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{status}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{status}')]")).Click();
        }
        public void SelectFundsSource(string source)
        {
            FundsSourceDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{source}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{source}')]")).Click();
        }

        public void SelectEstimatedIncome(string income)
        {
            try
            {
                EstimatedIncomeDropdown.Click();
            }
            catch
            {
                EstimatedIncomeFranceDropdown.Click();
            }
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{income}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{income}')]")).Click();
        }

        //Step 4 - Your Financial Details (2)
        public AndroidElement EstimatedValueDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-1_89']"));
        public AndroidElement InvestAmountDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-2_90']"));
        public void SelectEstimatedValue(string value)
        {
            EstimatedValueDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Click();
        }

        public void SelectInvestAmount(string amount)
        {
            InvestAmountDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{amount}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{amount}')]")).Click();
        }

        //Step 5 - Terms&Conditions

        public AndroidElement AcceptTermsToggle => AndroidDriver.Current.FindElement(By.XPath("//android.widget.CheckBox[@resource-id='question-2_21']"));
        public AndroidElement FinishButton => AndroidDriver.Current.FindElement(By.XPath("//android.widget.Button[@text='Finish']"));

        //Step 6 - AlmostThere

        public AndroidElement FundAccountButton => AndroidDriver.Current.FindElement(By.XPath("//android.widget.TextView[contains(@text,'Fund Your Account')]"));
        public AndroidElement VerifyAccountButton => AndroidDriver.Current.FindElement(By.XPath("//android.widget.TextView[contains(@text,'Verify Your Account')]"));

        //Step - Trading Experience
        public AndroidElement YesButton => AndroidDriver.Current.FindElement(By.XPath("//android.view.View[contains(@text, 'Avatrade')]//following-sibling::android.view.View[1]"));
        public AndroidElement NoButton => AndroidDriver.Current.FindElement(By.XPath("//android.view.View[contains(@text, 'Avatrade')]//following-sibling::android.view.View[2]"));
        public AndroidElement ExpectExperienceDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-3_82']"));
        public AndroidElement EstimatedValueOfTradesDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-4_83']"));

        public void SelectExperienceYesNo(bool yesNo)
        {
            Thread.Sleep(8000);
            if(yesNo == true)
            {
                YesButton.Click();
            }
            else
            {
                NoButton.Click();
                AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.view.View[contains(@text, 'AvaAcademy')]//following-sibling::android.widget.Button")).Displayed);
                AndroidDriver.Current.FindElement(By.XPath($"//android.view.View[contains(@text, 'AvaAcademy')]//following-sibling::android.widget.Button")).Click();
            }
        }

        public void SelectExpectExperience(string exp)
        {
            ExpectExperienceDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{exp}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{exp}')]")).Click();
        }

        public void SelectValueTrades(string value)
        {
            EstimatedValueOfTradesDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Click();
        }

        //Step - More Questions
        public AndroidElement LeverageDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-1_85']"));
        public AndroidElement SizePositionDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-2_86']"));
        public AndroidElement ClosePositionDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-3_87']"));
        public AndroidElement PrimaryPurposeDropdown => AndroidDriver.Current.FindElement(By.XPath("//android.widget.EditText[@resource-id='question-2_294']"));
        public AndroidElement RisksCheckbox => AndroidDriver.Current.FindElement(By.XPath("//android.widget.CheckBox[@resource-id='question-4_297']"));

        public void SelectLeverage(string value)
        {
            LeverageDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Click();
        }

        public void SelectSizePosition(string value)
        {
            SizePositionDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Click();
        }

        public void SelectClosePosition(string value)
        {
            ClosePositionDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Click();
        }

        public void SelectPurpose(string value)
        {
            PrimaryPurposeDropdown.Click();
            AndroidDriver.Wait.Until(drv => AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Displayed);
            AndroidDriver.Current.FindElement(By.XPath($"//android.widget.ListView//android.view.View[contains(@text, '{value}')]")).Click();
        }

        //Step - Warning
        public AndroidElement AgreeCheckbox => AndroidDriver.Current.FindElement(By.XPath("//android.app.Dialog//android.widget.CheckBox"));
        public AndroidElement CompleteRegistrationButton => AndroidDriver.Current.FindElement(By.XPath("//android.widget.Button[@text='Complete Registration']"));
    }
}
