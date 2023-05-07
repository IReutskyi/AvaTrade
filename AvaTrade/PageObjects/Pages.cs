using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTrade.PageObjects
{
    public class Pages
    {
        public static MainPage MainPage;
        public static SignUpPage SignUpPage;
        public static LoginPage LoginPage;
        public static DepositPage DepositPage;

        public static void Init()
        {
            MainPage = new MainPage();
            SignUpPage = new SignUpPage();
            LoginPage = new LoginPage();
            DepositPage = new DepositPage();
        }

    }
}
