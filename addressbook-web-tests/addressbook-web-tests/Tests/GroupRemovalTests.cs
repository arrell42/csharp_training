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
    public class GroupRemovalTests : TestBase
    {       

        [Test]
        public void GroupRemovalTest()
        {
            appManager.HelperNavigation.OpenHomePage();
            AccountData account = new AccountData("admin", "secret");
            appManager.HelperLogin.Login(account);
            appManager.HelperNavigation.GoToGroupsPage();
            appManager.HelperGroup.SelectGroup(1);
            appManager.HelperGroup.RemoveGroup();
            appManager.HelperGroup.ReturnToGroupsPage();            
        }
                  
    }
}
