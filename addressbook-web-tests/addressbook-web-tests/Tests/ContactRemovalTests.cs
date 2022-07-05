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
    public class ContactRemovalTests : AuthTestBase
    {
        [Test]
        public void ContactRemovalTest()
        {  
            if (appManager.ContactHelper.ContactNotExist())
            {
                ContactData contact = new ContactData("firstname", "LastName")
                {                    
                    Middlename = "MiddleName",                    
                    Nickname = "NickName",
                    Title = "Title",
                    Company = "Company",
                    Address = "Address",
                };
                appManager.ContactHelper.CreateContact(contact);
            }

            // создаем список
            List<ContactData> oldContacts = appManager.ContactHelper.GetContactList();           

            // удаляем контакт
            appManager.ContactHelper.RemoveContact(2);

            // сравниваем хэш
            Assert.AreEqual(oldContacts.Count - 1, appManager.ContactHelper.GetContactCount());

            // сравниваем содержимое
            List<ContactData> newContacts = appManager.ContactHelper.GetContactList();
            ContactData toBeRemoved = oldContacts[2];
            oldContacts.RemoveAt(2);
            Assert.AreEqual(oldContacts, newContacts);

            foreach(ContactData contact in oldContacts)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }
        }

    }
}
