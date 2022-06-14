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
            OpenHomePage();

            AccountData account = new  AccountData("admin", "secret");            
            Login(account);

            GoToGroupsPage();
            InitNewGroupCreation();

            GroupData group = new GroupData("aaa")
            {                
                Header = "ddd",
                Footer = "fff"
            };
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
        }

    }
}

