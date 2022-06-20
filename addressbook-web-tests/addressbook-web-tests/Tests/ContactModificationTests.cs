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
                Lastname = "ModifyLastName",
                Nickname = "ModifyNickName",
                Title = "ModifyTitle",
                Company = "ModifyCompany",
                Address = "ModifyAddress",                
            };

            appManager.HelperContact.ModifyContact(newData);
        }
    }
}
