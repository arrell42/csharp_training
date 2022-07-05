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
        protected LoginHelper helperLogin;
        protected NavigationHelper helperNavigation;
        protected GroupHelper helperGroup;
        protected ContactHelper helperContact;

        public static ThreadLocal<AppManager> appManager = new ThreadLocal<AppManager>();


        //HELPERS INIT
        private AppManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost";            

            helperLogin = new LoginHelper(this);
            helperNavigation = new NavigationHelper(this, baseURL);
            helperGroup = new GroupHelper(this);
            helperContact = new ContactHelper(this);
        }

        public static AppManager GetInstance()
        {
            if (! appManager.IsValueCreated)
            {
                AppManager newInstance = new AppManager();
                newInstance.NavigationHelper.OpenHomePage();
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
                
        public LoginHelper LoginHelper
        {
            get { return helperLogin; }
        }
        public NavigationHelper NavigationHelper
        {
            get { return helperNavigation; }
        }
        public ContactHelper ContactHelper
        {
            get { return helperContact; }
        }
        public GroupHelper GroupHelper
        {
            get { return helperGroup; }
        }
    }
}
