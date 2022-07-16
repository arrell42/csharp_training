using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper : BaseHelper
    {        
        public ContactHelper(AppManager manager) : base(manager)
        {            
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.NavigationHelper.AddNewContact();
            FillContactForm(contact);
            //SelectGroupInContact();
            //SelectDates();
            EnterButtonClick();
            ReturnToHomePage();            
            return this;
        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.NavigationHelper.OpenHomePage();
            manager.ContactHelper.EditContactButtonClick(index);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstname, lastname)
            {   
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone
            };
        }

        /*
        public ContactData GetContactInformationFromDetails()
        {
            manager.NavigationHelper.OpenHomePage();
            DetailsButtonClick(0);

            string content = driver.FindElement(By.Id("content")).Text;

            return new ContactData();

        }
        */

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.NavigationHelper.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allphones = cells[5].Text;

            return new ContactData(firstname, lastname)
            {   
                Address = address,
                AllPhones = allphones
            };
        }

        public ContactHelper RemoveContact(int v)
        {
            SelectContact(v);
            ClickDeleteButton();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(4000);
            return this;
        }

        public ContactHelper ModifyContact(int v, ContactData newData)
        {
            EditContactButtonClick(v);
            FillContactForm(newData);
            UpdateContact();
            manager.NavigationHelper.OpenHomePage();
            return this;
        }

        // тут хранится кеш списка контактов
        private List<ContactData> groupCache = null;
        // создание списка контактов
        public List<ContactData> GetContactList()
        {
            if(groupCache == null)
            {
                groupCache = new List<ContactData>();                
                manager.NavigationHelper.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.Name("entry"));
                foreach (IWebElement element in elements)
                {
                    IList<IWebElement> cells = element.FindElements(By.TagName("td"));
                    string lastname = cells[1].Text;
                    string firstname = cells[2].Text;
                    groupCache.Add(new ContactData(firstname, lastname));
                }
            }            
            return new List<ContactData>(groupCache);
        }


        // хэширование
        public int GetContactCount()
        {
            return driver.FindElements(By.XPath("//tr[@name = 'entry']")).Count;
        }


        //Методы низкого уровня

        public ContactHelper DetailsButtonClick(int index)
        {
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr["+ (index+2) +"]/td[7]/a")).Click();
            return this;
        }

        public bool ContactNotExist() => driver.FindElements(By.XPath("//tr[@name = 'entry']")).Count == 0;
        public ContactHelper ClickDeleteButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            groupCache = null;
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index+2) + "]/td/input")).Click();
            return this;
        }
        
        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            groupCache = null;
            return this;
        }

        public ContactHelper EditContactButtonClick(int index)
        {
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr["+ (index+2) +"]/td[8]/a")).Click();
            return this;
        }

        public ContactHelper SelectDates()
        {
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText("1");
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText("January");
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).Clear();
            driver.FindElement(By.Name("byear")).SendKeys("1988");
            driver.FindElement(By.Name("aday")).Click();
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText("1");
            driver.FindElement(By.Name("amonth")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText("January");
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).Clear();
            driver.FindElement(By.Name("ayear")).SendKeys("1999");
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            return this;
        }


        public ContactHelper SelectGroupInContact()
        {
            new SelectElement(driver.FindElement(By.Name("new_group"))).SelectByText("aaa");
            return this;
        }

        public ContactHelper EnterButtonClick()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            groupCache = null;
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.XPath("//a[@href= 'index.php']")).Click();
            return this;

        }

        public int GetNumberOfSearchResults()
        {
            manager.NavigationHelper.OpenHomePage();
            string text =  driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }


    }
}
