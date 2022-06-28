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

        public GroupHelper RemoveGroup(int v)
        {
            manager.HelperNavigation.GoToGroupsPage();
            SelectGroup(v);
            RemoveGroupButtonClick();
            ReturnToGroupsPage();
            return this;
        }               

        public GroupHelper Modify(int v, GroupData newData)
        {
            manager.HelperNavigation.GoToGroupsPage();            
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }



        // низкоуровневые методы

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }


        private List<GroupData> groupCache = null;

        public List<GroupData> GetGroupList()
        {
            if (groupCache == null)
            {
                groupCache = new List<GroupData>();

                List<GroupData> groups = new List<GroupData>();
                manager.HelperNavigation.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    groupCache.Add(new GroupData(element.Text));
                }
            }            
            return new List<GroupData>(groupCache);
        }

        public bool GroupNotExist() => driver.FindElements(By.XPath("//span[@class='group']")).Count == 0;

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCache = null;
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
            groupCache = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();            
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {            
            driver.FindElement(By.XPath("//input[@name='selected[]'][" + (index+1) + "]")).Click();
            return this;
        }
                

        public GroupHelper RemoveGroupButtonClick()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCache = null;
            return this;
        }
    }
}
