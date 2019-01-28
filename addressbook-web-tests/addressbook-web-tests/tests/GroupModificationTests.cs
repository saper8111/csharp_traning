using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;


namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
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

               GroupData modifygroup = new GroupData("modifygroup");
               modifygroup.Header = "modifygroup";
               modifygroup.Footer = "modifygroup";

               List<GroupData> oldGroups = app.Groups.GetGroupList();
            GroupData oldData = oldGroups[0];

               app.Groups.Modify(0, modifygroup);

            Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount());


            List<GroupData> newGroups = app.Groups.GetGroupList();
               Assert.AreEqual(oldGroups.Count, newGroups.Count);
               oldGroups[0].Name = modifygroup.Name;
               oldGroups.Sort();
               newGroups.Sort();
               Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if(group.Id == oldData.Id)
                {
                    Assert.AreEqual(modifygroup.Name, group.Name );
                }
            }
        }
    }
}
