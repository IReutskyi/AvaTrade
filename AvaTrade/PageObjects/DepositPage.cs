using Framework.Selenium;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTrade.PageObjects
{
    public class DepositPage
    {
        public Element IFrameDeposit => Driver.FindElement(By.XPath("//iframe[contains(@src, 'deposit')]"), "IFrame deposit");
        public Element ChooseDepositLabel => Driver.FindElement(By.XPath("//p[text()='Please choose deposit method']"), "Deposit Method Label");
        public Element CreditDebitCardLabel => Driver.FindElement(By.XPath("//p[text()='Credit and Debit Card']"), "Credit and Debit Card Label");
        public Element NotificationLabel => Driver.FindElement(By.XPath("//div[@class='dy-deposit-notification']"), "Notification Label");

        public void SwitchToDepositIFrame()
        {
            Driver.Current.SwitchTo().Frame(0);
        }
    }
}
