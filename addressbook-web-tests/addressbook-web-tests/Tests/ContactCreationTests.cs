using System;
using System.Collections.Generic;
using System.IO;
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
        public static IEnumerable<ContactData> RandomGroupDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(30), GenerateRandomString(20))
                {
                    Address = GenerateRandomString(100)                    
                });
            }
            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromFile()
        {
            List<ContactData> contacts = new List<ContactData>();
            string[] lines = File.ReadAllLines(@"contacts.csv");
            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                contacts.Add(new ContactData(parts[0], parts[1]));
            }
            return contacts;
        }

        [Test, TestCaseSource("ContactDataFromFile")]
        public void ContactCreationTest(ContactData contact)
        {   
            // создаем список
            List<ContactData> oldContacts = appManager.ContactHelper.GetContactList();

            // создаем контакт
            appManager.ContactHelper.CreateContact(contact);
            // проверка хэшей
            Assert.AreEqual(appManager.ContactHelper.GetContactCount(), oldContacts.Count + 1);

            List<ContactData> newContacts = appManager.ContactHelper.GetContactList();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }                

    }
}

