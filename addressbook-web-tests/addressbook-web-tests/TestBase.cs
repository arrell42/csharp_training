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
    public class TestBase
    {
        protected IWebDriver driver;
        private StringBuilder verificationErrors;
        protected string baseURL;
        //HELPERS
        protected HelperLogin helperLogin;
        protected HelperNavigation helperNavigation;
        protected HelperGroup helperGroup;
        protected HelperContact helperContact;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();
            //HELPERS INIT
            helperLogin = new HelperLogin(driver);
            helperNavigation = new HelperNavigation(driver, baseURL);
            helperGroup = new HelperGroup(driver);
            helperContact = new HelperContact(driver);
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }
         
    }
}
