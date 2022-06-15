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
    public class HelperBase
    {
        protected IWebDriver driver;
        public AppManager manager;

        public HelperBase(AppManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public HelperBase(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
