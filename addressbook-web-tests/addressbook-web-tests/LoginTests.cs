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
    [TestFixture]
    public class LoginTests : TestBase
    {
        [Test]
        public void LoginWithValidCredentials()
        {
            // prepare
            appManager.HelperLogin.Logout();

            // action
            AccountData account = new AccountData("admin", "secret");
            appManager.HelperLogin.Login(account);

            // verification
            Assert.IsTrue(appManager.HelperLogin.IsLoggedIn());
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            // prepare
            appManager.HelperLogin.Logout();

            // action
            AccountData account = new AccountData("admin", "123456");
            appManager.HelperLogin.Login(account);

            // verification
            Assert.IsFalse(appManager.HelperLogin.IsLoggedIn());
        }

    }
}
