﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebAddressBookTests;
using System.Xml;
using System.Xml.Serialization;


namespace addressbook_test_data_generators
{

    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[2];

            List<GroupData> groups = new List<GroupData>();
            for(int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });                
            }
            if(format == "csv")
            {
                writeGroupsToCsvFile(groups, writer);
            }
            else if(format == "xml")
            {
                writeGroupsToXmlFile(groups, writer);
            }
            else
            {
                Console.Out.Write("Unrecognized format " + format);
            }
            writer.Close();
        }

        static void writeGroupsToCsvFile(List<GroupData>groups, StreamWriter writer)
        {
            foreach(GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}",
                    group.Name, group.Header, group.Footer));
            }
        }

        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups);
        }


        /*
        static void Main1(string[] args)
        {
            int count = Convert.ToInt32(args[0]);
            StreamWriter writer = new StreamWriter(args[1]);
            string format = args[3];

            List<ContactData> contacts = new List<ContactData>();
            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(10), TestBase.GenerateRandomString(5)));
            }
            if (format == "csv")
            {
                writeContactsToCsvFile(contacts, writer);
            }
            else if (format == "xml")
            {
                writeContactsToXmlFile(contacts, writer);
            }
            else
            {
                Console.Out.Write("Unrecognized format " + format);
            }
            writer.Close();
        }

        static void writeContactsToCsvFile(List<ContactData> contacts, StreamWriter writer)
        {
            foreach (ContactData contact in contacts)
            {
                writer.WriteLine(String.Format("${0},${1}",
                    contact.Firstname, contact.Lastname));
            }
        }

        static void writeContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {

        }
        */
    }
}