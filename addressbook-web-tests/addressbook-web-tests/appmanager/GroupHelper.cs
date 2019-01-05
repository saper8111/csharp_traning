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
   public class GroupHelper : HelperBase
    {

        public GroupHelper(ApplicationManager manager) 
           : base(manager)
        {
        }


        public GroupHelper Create(GroupData group)
        {
            manager.Navigation.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            //Logout();
            return this;
        }

        public List<GroupData> GetGroupList()
        {
            List<GroupData> groups = new List<GroupData>();
            manager.Navigation.GoToGroupsPage();
            ICollection<IWebElement>elements = driver.FindElements(By.CssSelector("span.group"));
            foreach (IWebElement element in elements)
            {
                groups.Add(new GroupData(element.Text));
            }

            return groups;
        }

        public GroupHelper Modify(int v, GroupData newModifyData)
        {
            manager.Navigation.GoToGroupsPage();

            if (driver.Url == "http://localhost/addressbook/group.php"
                && !IsElementPresent(By.Name("selected[]")))

            {
            InitGroupCreation();
            FillGroupForm(newModifyData);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            }

            SelectGroup(v);
            InitGroupModification();
            FillGroupForm(newModifyData);
            SubmitGroupModification();
            ReturnToGroupsPage();
            //Logout();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper Remove(int v, GroupData newRemoveData)
        {
            manager.Navigation.GoToGroupsPage();

            if (driver.Url == "http://localhost/addressbook/group.php"
                && !IsElementPresent(By.Name("selected[]")))
            {

            InitGroupCreation();
            FillGroupForm(newRemoveData);
            SubmitGroupCreation();
            ReturnToGroupsPage();
            }

            SelectGroup(v);
            RemoveGroup();
            ReturnToGroupsPage();
            Logout();
            return this;



        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }

        

        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        
    }
}
