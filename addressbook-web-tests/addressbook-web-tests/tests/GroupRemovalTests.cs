using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

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
                Assert.IsFalse(app.Groups.GroupIsNotCreated());

            }

            GroupData group = new GroupData("qwerty");
            group.Header = "qwerty1";
            group.Footer = "qwerty2";
            
            app.Groups.Remove(group);

            
           
        }

    }
}
