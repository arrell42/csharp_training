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
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using Excel = Microsoft.Office.Interop.Excel;
using System.Linq;

namespace WebAddressBookTests
{
    [TestFixture]
    public class ContactCreationTests : ContactTestBase
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

        public static IEnumerable<ContactData> ContactDataFromCsvFile()
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
        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
            return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>))
                    .Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                File.ReadAllText(@"contacts.json"));
        }

        public static IEnumerable<ContactData> ContactDataFromExcelFile()
        {
            List<ContactData> groups = new List<ContactData>();
            Excel.Application app = new Excel.Application();
            Excel.Workbook wb = app.Workbooks.Open(Path.Combine(Directory.GetCurrentDirectory(), @"contacts.xlsx"));
            Excel.Worksheet sheet = wb.ActiveSheet;
            Excel.Range range = sheet.UsedRange;
            for (int i = 1; i <= range.Rows.Count; i++)
            {
                groups.Add(new ContactData()
                {
                    Firstname = range.Cells[i, 1].Value,
                    Lastname = range.Cells[i, 2].Value                    
                });
            }
            wb.Close();
            app.Visible = false;
            app.Quit();
            return groups;

        }




        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {   
            // создаем список
            List<ContactData> oldContacts = ContactData.GetAllContacts();

            // создаем контакт
            appManager.ContactHelper.CreateContact(contact);
            // проверка хэшей
            Assert.AreEqual(appManager.ContactHelper.GetContactCount(), oldContacts.Count + 1);

            List<ContactData> newContacts = ContactData.GetAllContacts();
            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts, newContacts);
        }

        [Test]
        public void TestDBContactsConnect()
        {
            DateTime start = DateTime.Now;
            appManager.ContactHelper.GetContactList();
            DateTime end = DateTime.Now;
            Console.Out.WriteLine(end.Subtract(start));

            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetAllContacts();                       
            end = DateTime.Now;
            Console.Out.WriteLine(end.Subtract(start));
        }
    }
}

