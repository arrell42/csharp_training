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
            List<ContactData> oldContacts = appManager.HelperContact.GetContactList();

            // создаем контакт
            appManager.HelperContact.CreateContact(contact);
                        
            // сравниваем хэш
            Assert.AreEqual(appManager.HelperContact.GetContactCount(), oldContacts.Count + 1);

            // сравниваем содержимое
            List<ContactData> newContacts = appManager.HelperContact.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }                

    }
}

