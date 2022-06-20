﻿using OpenQA.Selenium;


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

        public void Type(By locator, string text)
        {
            if (text != null)
            {
                driver.FindElement(locator).Click();
                driver.FindElement(locator).Clear();
                driver.FindElement(locator).SendKeys(text);
            }
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}
