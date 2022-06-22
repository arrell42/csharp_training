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
    public class GroupHelper : BaseHelper
    {        
        public GroupHelper(AppManager manager) : base(manager)
        {            
        }

        public GroupHelper CreateGroup(GroupData group)
        {
            manager.HelperNavigation.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public GroupHelper RemoveGroup(int v, GroupData newData)
        {
            manager.HelperNavigation.GoToGroupsPage();           
            
            if (GroupNotPresent())
            {
                CreateGroup(newData);                
            }
            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            return this;
        }

        public bool GroupNotPresent() => driver.FindElements(By.XPath("//span[@class='group']")).Count == 0;

        public GroupHelper Modify(int v, GroupData newData, GroupData data)
        {
            manager.HelperNavigation.GoToGroupsPage();
            if (GroupNotPresent())
            {
                CreateGroup(data);
            }
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }



        //низкоуровневые методы
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {            
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);            
            return this;
        }

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            //driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {            
            driver.FindElement(By.XPath("//input[@name='selected[]'][" + index + "]")).Click();
            return this;
        }
                

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
    }
}
