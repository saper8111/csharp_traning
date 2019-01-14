using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {

            if (app.Groups.GroupIsNotCreated())
            {
                Assert.IsFalse(app.Groups.IsElementPresent(By.Name("selected[]")));

            }

            GroupData group = new GroupData("qwerty");
            group.Header = "qwerty1";
            group.Footer = "qwerty2";
            //Assert.IsFalse(app.Groups.IsElementPresent(By.Name("selected[]")));
            
            app.Groups.Remove(1, group);

            
           
        }

    }
}
