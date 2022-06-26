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
            if (appManager.HelperContact.ContactNotexist())
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
            appManager.HelperContact.RemoveContact(2);
        }

    }
}
