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
    public class ContactTestBase : AuthTestBase
    {
        [TearDown]
        public void CompareContactsUI_DB()
        {
            if (PERFORM_LONG_UI_CHECKS)
            {
                List<ContactData> fromUI = appManager.ContactHelper.GetContactList();
                List<ContactData> fromBD = ContactData.GetAllContacts();
                fromUI.Sort();
                fromBD.Sort();
                Assert.AreEqual(fromBD, fromUI);
            }            
        }
    }
}
