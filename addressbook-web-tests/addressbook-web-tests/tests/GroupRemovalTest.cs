using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
      

        [Test]
        public void GroupRemovalTest()
        {
            app.NavigationHelper.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.NavigationHelper.GoToGroupsPage();
            app.GroupHelper.SelectGroup(1);
            app.GroupHelper.RemoveGroup();
            app.GroupHelper.ReturnToGroupsPage();
        }

    }
}
