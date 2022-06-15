using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class TestBase
    {   
        protected AppManager appManager;

        [SetUp]
        public void SetupTest()
        {  
            appManager = new AppManager();

            appManager.HelperNavigation.OpenHomePage();
            AccountData account = new AccountData("admin", "secret");
            appManager.HelperLogin.Login(account);
        }



        [TearDown]
        public void TeardownTest()
        {
            appManager.Stop();
        }
         
    }
}
