using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvaTradeMobile.PageObjects
{
    public class Pages
    {
        public static MainPage MainPage;
        public static SignUpPage SignUpPage;
        public static void Init()
        {
            MainPage = new MainPage();
            SignUpPage = new SignUpPage();
        }

    }
}
