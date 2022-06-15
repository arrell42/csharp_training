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
    public class AppManager
    {
        protected IWebDriver driver;        
        protected string baseURL;
        private StringBuilder verificationErrors;

        //HELPERS
        protected HelperLogin helperLogin;
        protected HelperNavigation helperNavigation;
        protected HelperGroup helperGroup;
        protected HelperContact helperContact;


        //HELPERS INIT
        public AppManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();

            helperLogin = new HelperLogin(this);
            helperNavigation = new HelperNavigation(this, baseURL);
            helperGroup = new HelperGroup(this);
            helperContact = new HelperContact(this);            
        }

        public void Stop()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }

        public IWebDriver Driver
        {
            get { return driver; }
        }
                
        public HelperLogin HelperLogin
        {
            get { return helperLogin; }
        }
        public HelperNavigation HelperNavigation
        {
            get { return helperNavigation; }
        }
        public HelperContact HelperContact
        {
            get { return helperContact; }
        }
        public HelperGroup HelperGroup
        {
            get { return helperGroup; }
        }
    }
}
