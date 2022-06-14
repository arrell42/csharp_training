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
    public class ContactCreationTests : TestBase
    {     
        [Test]
        public void ContactCreationTest()
        {

            OpenHomePage();

            AccountData account = new AccountData("admin", "secret");
            Login(account);
            Thread.Sleep(5000);
            ContactData contact = new ContactData()
            {
                Firstname = "firstname",
                Middlename = "MiddleName",
                Lastname = "LastName",
                Nickname = "NickName",
                Title = "Title",
                Company = "Company",
                Address = "Address",
                HomePhone = "5555",
                MobilePhone = "666",
                WorkPhone = "777",
                Fax = "888",
                Email = "test1@test.ru",
                Email2 = "test2@test.ru",
                Email3 = "test3@test.ru",
                HomePagePhone = "HomePagePhone",
                Address2 = "Address2",
                Phone2 = "Phone2",
                Notes = "Notes",
            };
            FillContactForm(contact);            
            SelectGroupInContact();
            SelectDates();
            ClickInputButton();

        }                

    }
}

