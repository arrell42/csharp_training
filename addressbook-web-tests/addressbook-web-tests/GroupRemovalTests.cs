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
            OpenHomePage();
            AccountData account = new AccountData("admin", "secret");
            Login(account);
            GoToGroupsPage();            
            SelectGroup(1);
            RemoveGroup();
            ReturnToGroupsPage();            
        }
                  
    }
}
