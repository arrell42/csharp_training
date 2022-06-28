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
            ContactData newData = new ContactData()
            {
                Firstname = "Modifyfirstname",
                Middlename = "ModifyMiddleName",
                Lastname = null,
                Nickname = null,
                Title = null,
                Company = null,
                Address = null,
            };

            if (appManager.HelperContact.ContactNotExist())
            {
                ContactData contact = new ContactData()
                {
                    Firstname = "firstname",
                    Middlename = "MiddleName",
                    Lastname = "LastName",
                    Nickname = "NickName",
                    Title = "Title",
                    Company = "Company",
                    Address = "Address",
                };
                appManager.HelperContact.CreateContact(contact);
            }
            appManager.HelperContact.ModifyContact(2, newData);
        }
    }
}
