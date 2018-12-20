using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       

        [Test]
        public void GroupCreationTest()
        {
            app.NavigationHelper.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.NavigationHelper.GoToGroupsPage();
            app.GroupHelper.InitGroupCreation();
            GroupData group = new GroupData("aaa");
            group.Header = "sss";
            group.Footer = "ddd";
            app.GroupHelper.FillGroupForm(group);
            app.GroupHelper.SubmitGroupCreation();
            app.GroupHelper.ReturnToGroupsPage();
            app.GroupHelper.Logout();
        }

    }
}
