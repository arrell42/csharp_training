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
            appManager.LoginHelper.Logout();

            // action
            AccountData account = new AccountData("admin", "secret");
            appManager.LoginHelper.Login(account);

            // verification
            Assert.IsTrue(appManager.LoginHelper.IsLoggedIn());
        }

        [Test]
        public void LoginWithInvalidCredentials()
        {
            // prepare
            appManager.LoginHelper.Logout();

            // action
            AccountData account = new AccountData("admin", "123456");
            appManager.LoginHelper.Login(account);

            // verification
            Assert.IsFalse(appManager.LoginHelper.IsLoggedIn());
        }

    }
}
