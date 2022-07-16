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
            ContactData newData = new ContactData("Modifyfirstname", "Modifylastname")
            {   
                
                Middlename = "ModifyMiddleName",                
                Nickname = null,
                Title = null,
                Company = null,
                Address = null,
            };

            if (appManager.ContactHelper.ContactNotExist())
            {
                ContactData contact = new ContactData("firstname", "lastName")
                {                    
                    Middlename = "MiddleName",                    
                    Nickname = "NickName",
                    Title = "Title",
                    Company = "Company",
                    Address = "Address",
                };
                appManager.ContactHelper.CreateContact(contact);
            }
            
            List<ContactData> oldContacts = appManager.ContactHelper.GetContactList();            

            // модифицируем контакт
            appManager.ContactHelper.ModifyContact(0, newData);

            Assert.AreEqual(appManager.ContactHelper.GetContactCount(), oldContacts.Count);

            List<ContactData> newContacts = appManager.ContactHelper.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);

            
        }
    }
}
