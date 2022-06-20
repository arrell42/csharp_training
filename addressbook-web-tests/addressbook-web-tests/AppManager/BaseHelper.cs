using OpenQA.Selenium;


namespace WebAddressBookTests
{
    public class BaseHelper
    {
        protected IWebDriver driver;
        public AppManager manager;

        public BaseHelper(AppManager manager)
        {
            this.manager = manager;
            driver = manager.Driver;
        }

        public BaseHelper(IWebDriver driver)
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
