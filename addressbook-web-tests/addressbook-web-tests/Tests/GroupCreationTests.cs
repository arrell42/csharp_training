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
    public class GroupCreationTests : TestBase
    {        

        [Test]
        public void GroupCreationTest()
        {
            appManager.HelperNavigation.OpenHomePage();

            AccountData account = new  AccountData("admin", "secret");
            appManager.HelperLogin.Login(account);

            appManager.HelperNavigation.GoToGroupsPage();
            appManager.HelperGroup.InitNewGroupCreation();

            GroupData group = new GroupData("aaa")
            {                
                Header = "ddd",
                Footer = "fff"
            };
            appManager.HelperGroup.FillGroupForm(group);
            appManager.HelperGroup.SubmitGroupCreation();
            appManager.HelperGroup.ReturnToGroupsPage();
        }

    }
}

