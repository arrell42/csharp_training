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
    public class HelperGroup : HelperBase
    {        
        public HelperGroup(AppManager manager) : base(manager)
        {            
        }

        public HelperGroup createGroup(GroupData group)
        {
            manager.HelperNavigation.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            return this;
        }

        public HelperGroup Modify(int v, GroupData newData)
        {
            manager.HelperNavigation.GoToGroupsPage();
            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            return this;
        }

        public HelperGroup SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public HelperGroup InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public HelperGroup RemoveGroup(int v)
        {
                manager.HelperNavigation.GoToGroupsPage();                
                SelectGroup(v);
                RemoveGroup();
                ReturnToGroupsPage();
                return this;
        }        

        public HelperGroup InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public HelperGroup FillGroupForm(GroupData group)
        {
            driver.FindElement(By.Name("group_name")).Click();
            driver.FindElement(By.Name("group_name")).Clear();
            driver.FindElement(By.Name("group_name")).SendKeys(group.Name);
            driver.FindElement(By.Name("group_header")).Click();
            driver.FindElement(By.Name("group_header")).Clear();
            driver.FindElement(By.Name("group_header")).SendKeys(group.Header);
            driver.FindElement(By.Name("group_footer")).Click();
            driver.FindElement(By.Name("group_footer")).Clear();
            driver.FindElement(By.Name("group_footer")).SendKeys(group.Footer);
            return this;
        }

        public HelperGroup SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public HelperGroup ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        public HelperGroup SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//input[@name='selected[]'][" + index + "]")).Click();
            return this;
        }

        public HelperGroup RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }
    }
}
