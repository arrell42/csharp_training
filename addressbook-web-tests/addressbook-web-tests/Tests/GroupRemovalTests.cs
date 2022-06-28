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

            // создаем список
            List<GroupData> oldGroups = appManager.HelperGroup.GetGroupList();

            // удаляем группу
            appManager.HelperGroup.RemoveGroup(0);

            // сравниваем хэш
            Assert.AreEqual(appManager.HelperGroup.GetGroupCount(), oldGroups.Count - 1);

            // сравниваем содержимое
            List<GroupData> newGroups = appManager.HelperGroup.GetGroupList();
            // сохраняем Id удаляемой группы
            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);
            // сравниваем Id удаленной группы и группы, которая теперь на ее месте
            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }
        }         
    }
}
