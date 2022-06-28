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

            List<ContactData> oldContacts = appManager.HelperContact.GetContactList();

            appManager.HelperContact.ModifyContact(2, newData);

            List<ContactData> newContacts = appManager.HelperContact.GetContactList();
            oldContacts[2].Firstname = newData.Firstname;            
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }
    }
}
