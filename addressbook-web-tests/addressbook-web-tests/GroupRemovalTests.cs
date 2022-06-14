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
            helperNavigation.OpenHomePage();
            AccountData account = new AccountData("admin", "secret");
            helperLogin.Login(account);
            helperNavigation.GoToGroupsPage();
            helperGroup.SelectGroup(1);
            helperGroup.RemoveGroup();
            helperGroup.ReturnToGroupsPage();            
        }
                  
    }
}
