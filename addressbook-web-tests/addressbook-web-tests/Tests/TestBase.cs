using NUnit.Framework;


namespace WebAddressBookTests
{
    public class TestBase
    {   
        protected AppManager appManager;

        [SetUp]
        public void SetupAppManager()
        {
            appManager = AppManager.GetInstance();            
        }
    }
}
