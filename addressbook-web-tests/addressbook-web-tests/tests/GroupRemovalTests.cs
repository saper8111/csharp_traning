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
                
                GroupData newgroup = new GroupData("new group");
                newgroup.Header = "new group1";
                newgroup.Footer = "new group2";
                app.Groups.Create(newgroup);
                
                }

               Assert.IsFalse(app.Groups.GroupIsNotCreated());

               List<GroupData> oldGroups = app.Groups.GetGroupList();

               app.Groups.Remove();

               List<GroupData> newGroups = app.Groups.GetGroupList();

               oldGroups.RemoveAt(0);
               Assert.AreEqual(oldGroups, newGroups);

        }  
               

          
           
           


           

            
           
         

        
    }
}
