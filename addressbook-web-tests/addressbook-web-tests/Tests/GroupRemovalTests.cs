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
    public class GroupRemovalTests : GroupTestBase
    {

        [Test]
        public void GroupRemovalTest()
        {
            if (appManager.GroupHelper.GroupNotExist())
            {
                GroupData group = new GroupData("aaa")
                {
                    Header = "ddd",
                    Footer = "fff"
                };
                appManager.GroupHelper.CreateGroup(group);
            }

            // создаем список
            List<GroupData> oldGroups = GroupData.GetAllGroups();
            GroupData toBeRemoved = oldGroups[0];
            // удаляем группу
            appManager.GroupHelper.RemoveGroup(toBeRemoved);

            // сравниваем хэш
            Assert.AreEqual(oldGroups.Count - 1, appManager.GroupHelper.GetGroupCount());

            // сравниваем содержимое
            List<GroupData> newGroups = GroupData.GetAllGroups();
            // сохраняем Id удаляемой группы            
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
