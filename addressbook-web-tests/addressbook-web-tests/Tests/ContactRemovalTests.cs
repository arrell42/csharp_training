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
            if (appManager.HelperContact.ContactNotExist())
            {
                ContactData contact = new ContactData("firstname", "LastName")
                {                    
                    Middlename = "MiddleName",                    
                    Nickname = "NickName",
                    Title = "Title",
                    Company = "Company",
                    Address = "Address",
                };
                appManager.HelperContact.CreateContact(contact);
            }

            // создаем список
            List<ContactData> oldContacts = appManager.HelperContact.GetContactList();

            // удаляем контакт
            appManager.HelperContact.RemoveContact(2);

            // сравниваем хэш
            Assert.AreEqual(oldContacts.Count - 1, appManager.HelperContact.GetContactCount());

            // сравниваем содержимое
            List<ContactData> newContacts = appManager.HelperContact.GetContactList();
            oldContacts.RemoveAt(2);
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
