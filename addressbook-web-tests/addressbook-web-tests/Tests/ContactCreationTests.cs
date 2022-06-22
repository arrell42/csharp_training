using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {     
        [Test]
        public void ContactCreationTest()
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

    }
}

