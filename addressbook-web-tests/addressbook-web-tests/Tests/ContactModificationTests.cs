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

            appManager.HelperContact.ModifyContact(contact, newData);
        }
    }
}
