using NUnit.Framework;
using System;
using System.Text;

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

        // генератор случайных строк
        public static Random rnd = new Random();
        public static string GenerateRandomString(int max)
        {            
            int l = Convert.ToInt32(rnd.NextDouble() * max);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(32 + Convert.ToInt32(rnd.NextDouble() * 223)));
            }
            return builder.ToString();
        }
    }
}
