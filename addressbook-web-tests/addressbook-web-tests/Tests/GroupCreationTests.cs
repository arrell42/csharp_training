using System;
using System.Collections.Generic;
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
    public class GroupCreationTests : AuthTestBase
    {        

        [Test]
        public void GroupCreationTest()
        {            
            GroupData group = new GroupData("aaa")
            {                
                Header = "ddd",
                Footer = "fff"
            };

            List<GroupData> oldGroups = appManager.HelperGroup.GetGroupList();

            appManager.HelperGroup.CreateGroup(group);

            List<GroupData> newGroups = appManager.HelperGroup.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };

            List<GroupData> oldGroups = appManager.HelperGroup.GetGroupList();

            appManager.HelperGroup.CreateGroup(group);

            List<GroupData> newGroups = appManager.HelperGroup.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a")
            {
                Header = "",
                Footer = ""
            };

            List<GroupData> oldGroups = appManager.HelperGroup.GetGroupList();

            appManager.HelperGroup.CreateGroup(group);

            List<GroupData> newGroups = appManager.HelperGroup.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

    }
}

