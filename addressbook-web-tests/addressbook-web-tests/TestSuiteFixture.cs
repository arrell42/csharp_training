using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    [SetUpFixture]
    public class TestSuiteFixture
    {
        

        [SetUp]
        public void InitApplicationManager()
        {
            AppManager appManager = AppManager.GetInstance();
            appManager.HelperNavigation.OpenHomePage();
            appManager.HelperLogin.Login(new AccountData("admin", "secret"));
        }
    }
}
