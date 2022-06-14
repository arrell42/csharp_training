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
    public class HelperNavigation : HelperBase
    {        
        private string baseURL;

        public HelperNavigation(IWebDriver driver, string baseURL) : base(driver)
        {            
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void AddNewContact()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}
