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
    public class ContactRemovalTests : ContactTestBase
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
            
            List<ContactData> oldContacts = ContactData.GetAllContacts();
            ContactData toBeRemoved = oldContacts[0];
            // удаляем контакт
            appManager.ContactHelper.RemoveContact(toBeRemoved);

            Assert.AreEqual(oldContacts.Count - 1, appManager.ContactHelper.GetContactCount());

            List<ContactData> newContacts = ContactData.GetAllContacts();            
            oldContacts.RemoveAt(0);
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
