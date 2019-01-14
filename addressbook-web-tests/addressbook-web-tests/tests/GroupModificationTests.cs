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
            if (app.Groups.GroupIsNotCreated())
            {
                Assert.IsFalse(app.Groups.IsElementPresent(By.Name("selected[]")));

            }
            GroupData group = new GroupData("mod");
            group.Header = "modify1";
            group.Footer = "modify1";
            app.Groups.Modify(1, group);
        }

    }
}
