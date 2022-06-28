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
    public class GroupRemovalTests : AuthTestBase
    {       

        [Test]
        public void GroupRemovalTest()
        {
            if (appManager.HelperGroup.GroupNotExist())
            {
                GroupData group = new GroupData("aaa")
                {
                    Header = "ddd",
                    Footer = "fff"
                };
                appManager.HelperGroup.CreateGroup(group);
            }

            List<GroupData> oldGroups = appManager.HelperGroup.GetGroupList();

            appManager.HelperGroup.RemoveGroup(0);

            List<GroupData> newGroups = appManager.HelperGroup.GetGroupList();

            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
        }
                  
    }
}
