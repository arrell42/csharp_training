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
            ContactData oldData = oldContacts[2];

            // модифицируем контакт
            appManager.ContactHelper.ModifyContact(2, newData);

            // сравниваем хэш
            Assert.AreEqual(oldContacts.Count, appManager.ContactHelper.GetContactCount());

            // сравниваем содержимое
            List<ContactData> newContacts = appManager.ContactHelper.GetContactList();
            oldContacts[2].Firstname = newData.Firstname;
            oldContacts[2].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in oldContacts)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);
                }
            }
        }
    }
}
