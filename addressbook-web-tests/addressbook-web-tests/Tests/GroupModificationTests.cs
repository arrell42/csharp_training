using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {   
            GroupData newData = new GroupData("newGroupBeforeModify")
            {
                Header = null,
                Footer = null
            };
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
            List<GroupData> oldGroups = appManager.GroupHelper.GetGroupList();
            // сохраняем Id изменяемой группы
            GroupData oldData = oldGroups[0];

            // модифицируем группу
            appManager.GroupHelper.Modify(0, newData);

            // сравниваем хэш
            Assert.AreEqual(appManager.GroupHelper.GetGroupCount(), oldGroups.Count);

            // сравниваем содержимое
            List<GroupData> newGroups = appManager.GroupHelper.GetGroupList();
            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
            // сравниваем Id измененной группы (должны совпадать)
            foreach (GroupData group in newGroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}
