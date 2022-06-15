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
            GroupData group = new GroupData("aaa")
            {                
                Header = "ddd",
                Footer = "fff"
            };            
            appManager.HelperGroup.createGroup(group);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            GroupData group = new GroupData("")
            {
                Header = "",
                Footer = ""
            };            
            appManager.HelperGroup.createGroup(group);            
        }

    }
}

