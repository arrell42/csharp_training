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
    public class NavigationHelper : BaseHelper
    {        
        private string baseURL;

        public NavigationHelper(AppManager manager, string baseURL) : base(manager)
        {            
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            if (driver.Url == baseURL + "/addressbook/")
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL + "/addressbook/");            
        }
        public void GoToGroupsPage()
        {
            if(driver.Url == baseURL + "/addressbook/group.php"
                & IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
