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

            List<ContactData> oldContacts = appManager.HelperContact.GetContactList();

            appManager.HelperContact.RemoveContact(2);

            List<ContactData> newContacts = appManager.HelperContact.GetContactList();
            oldContacts.RemoveAt(2);
            Assert.AreEqual(oldContacts, newContacts);
        }

    }
}
