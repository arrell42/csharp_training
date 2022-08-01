using NUnit.Framework;
using System;
using System.Text;

namespace WebAddressBookTests
{
    public class TestBase
    {   
        public static bool PERFORM_LONG_UI_CHECKS = true;
        protected AppManager appManager;

        [SetUp]
        public void SetupAppManager()
        {
            appManager = AppManager.GetInstance();            
        }

        // генератор случайных строк
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {            
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 65)));
            }
            return builder.ToString();
        }
    }
}
