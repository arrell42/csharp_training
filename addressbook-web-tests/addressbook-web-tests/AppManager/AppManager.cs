using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

        //HELPERS
        protected HelperLogin helperLogin;
        protected HelperNavigation helperNavigation;
        protected HelperGroup helperGroup;
        protected HelperContact helperContact;

        public static ThreadLocal<AppManager> appManager = new ThreadLocal<AppManager>();


        //HELPERS INIT
        private AppManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";            

            helperLogin = new HelperLogin(this);
            helperNavigation = new HelperNavigation(this, baseURL);
            helperGroup = new HelperGroup(this);
            helperContact = new HelperContact(this);
        }

        public static AppManager GetInstance()
        {
            if (! appManager.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                newInstance.HelperNavigation.OpenHomePage();
                appManager.Value = newInstance;
                
            }
            return appManager.Value;
        }

        ~AppManager()
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
