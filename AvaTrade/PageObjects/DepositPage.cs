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

        public void SwitchToDepositIFrame()
        {
            Driver.Current.SwitchTo().Frame(0);
        }
    }
}
