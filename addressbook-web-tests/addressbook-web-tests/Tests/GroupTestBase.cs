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
    public class GroupTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareGroupsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<GroupData> fromUI = appManager.GroupHelper.GetGroupList();
                List<GroupData> fromBD = GroupData.GetAllGroups();
                fromUI.Sort();
                fromBD.Sort();
                Assert.AreEqual(fromBD, fromUI);
            }            
        }
    }
}
