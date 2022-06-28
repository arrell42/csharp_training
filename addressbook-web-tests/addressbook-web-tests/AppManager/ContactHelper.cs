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
    public class ContactHelper : BaseHelper
    {        
        public ContactHelper(AppManager manager) : base(manager)
        {            
        }

        public ContactHelper CreateContact(ContactData contact)
        {
            manager.HelperNavigation.AddNewContact();
            FillContactForm(contact);
            //SelectGroupInContact();
            //SelectDates();
            ClickInputButton();
            ReturnToHomePage();
            return this;
        }

        public ContactHelper RemoveContact(int v)
        {
            SelectContact(v);
            ClickDeleteButton();
            driver.SwitchTo().Alert().Accept();
            manager.HelperNavigation.OpenHomePage();
            return this;
        }

        public ContactHelper ModifyContact(int v, ContactData newData)
        {
            EditContact(v);
            FillContactForm(newData);
            UpdateContact();
            manager.HelperNavigation.OpenHomePage();
            return this;
        }

        



        // оптимизация кеширования
        private List<ContactData> contactCache = null;
        public List<ContactData> GetContactList()
        {
            if(contactCache == null)
            {
                contactCache = new List<ContactData>();
                List<ContactData> contacts = new List<ContactData>();
                manager.HelperNavigation.AddNewContact();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.contacts"));
                foreach (IWebElement element in elements)
                {
                    contactCache.Add(new ContactData(element.Text, element.Text));
                }
            }
            return new List<ContactData>(contactCache);
        }

        // хэширование
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("span.contacts")).Count;
        }

        //Методы низкого уровня

        public bool ContactNotExist() => driver.FindElements(By.XPath("//tr[@name = 'entry']")).Count == 0;
        public ContactHelper ClickDeleteButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            contactCache = null;
            return this;
        }
        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input")).Click();
            return this;
        }
        
        public ContactHelper UpdateContact()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[22]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper EditContact(int index)
        {
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr["+ index +"]/td[8]/a")).Click();
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

        public ContactHelper ClickInputButton()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ReturnToHomePage()
        {
            driver.FindElement(By.XPath("//a[@href= 'index.php']")).Click();
            return this;

        }


    }
}
