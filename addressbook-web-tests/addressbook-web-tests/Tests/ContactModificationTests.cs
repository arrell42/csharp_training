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
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("Modifyfirstname", null)
            {                
                Middlename = "ModifyMiddleName",                
                Nickname = null,
                Title = null,
                Company = null,
                Address = null,
            };

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

            // модифицируем контакт
            appManager.HelperContact.ModifyContact(2, newData);

            // сравниваем хэш
            Assert.AreEqual(oldContacts.Count, appManager.HelperContact.GetContactCount());

            // сравниваем содержимое
            List<ContactData> newContacts = appManager.HelperContact.GetContactList();
            oldContacts[2].Firstname = newData.Firstname;            
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
