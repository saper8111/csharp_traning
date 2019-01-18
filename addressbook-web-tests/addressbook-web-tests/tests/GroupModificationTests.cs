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
               app.Groups.Modify(modifygroup);
        }
    }
}
