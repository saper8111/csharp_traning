﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
   public class NavigationHelper : HelperBase
    {

        public NavigationHelper(ApplicationManager manager) 
            : base(manager)
        {
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl("http://localhost/addressbook");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == "http://localhost/addressbook/group.php" 
                && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }
    }
}
