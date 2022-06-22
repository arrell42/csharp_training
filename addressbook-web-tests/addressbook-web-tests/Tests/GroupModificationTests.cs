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
            GroupData newData = new GroupData("modifyData")
            {
                Header = null,
                Footer = null
            };

            GroupData data = new GroupData("newGroupBeforeModify")
            {
                Header = null,
                Footer = null
            };
            appManager.HelperGroup.Modify(1, newData, data);
        }
    }
}
