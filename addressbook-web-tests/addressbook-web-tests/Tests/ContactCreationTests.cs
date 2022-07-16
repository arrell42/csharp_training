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
    public class ContactCreationTests : AuthTestBase
    {     
        [Test]
        public void ContactCreationTest()
        {
            ContactData contact = new ContactData("firstname", "lastName");           

            // создаем список
            List<ContactData> oldContacts = appManager.ContactHelper.GetContactList();

            // создаем контакт
            appManager.ContactHelper.CreateContact(contact);
            // проверка хэшей
            Assert.AreEqual(appManager.ContactHelper.GetContactCount(), oldContacts.Count + 1);

            List<ContactData> newContacts = appManager.ContactHelper.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }                

    }
}

