using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()

        {

                app.Navigation.GoToGroupsPage();

                if (app.Groups.GroupIsNotCreated())
                {
                
                GroupData newgroup = new GroupData("123");
                newgroup.Header = "123";
                newgroup.Footer = "new group2";
                app.Groups.Create(newgroup);
                
                }

               Assert.IsFalse(app.Groups.GroupIsNotCreated());

               List<GroupData> oldGroups = app.Groups.GetGroupList();

               app.Groups.Remove();

               List<GroupData> newGroups = app.Groups.GetGroupList();

               oldGroups.RemoveAt(0);
               oldGroups.Sort();
               oldGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

        }  
               

          
           
           


           

            
           
         

        
    }
}
