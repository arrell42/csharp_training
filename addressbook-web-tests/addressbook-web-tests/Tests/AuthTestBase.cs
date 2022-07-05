﻿using System;
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
    public class AuthTestBase : TestBase
    {
        [SetUp]

        public void SetupLogin()
        {
            appManager.LoginHelper.Login(new AccountData("admin", "secret"));
        }
    }
}
