﻿using System;
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
                SelectGroupInContact();
                SelectDates();
                ClickInputButton();
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

        public ContactHelper ModifyContact(ContactData newData)
        {
            EditContact();
            FillContactForm(newData);
            UpdateContact();
            manager.HelperNavigation.OpenHomePage();
            return this;
        }




        //Методы низкого уровня
        public ContactHelper ClickDeleteButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
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
            return this;
        }

        public ContactHelper EditContact()
        {
            driver.FindElement(By.XPath("//*[@id='maintable']/tbody/tr[2]/td[8]/a")).Click();
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
            return this;
        }

        
    }
}