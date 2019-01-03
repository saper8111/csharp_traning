using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            GroupData newData = new GroupData("qwe");
            newData.Header = "qwerty";
            newData.Footer = "qwerty3076910";
            app.Groups.Remove(1, newData);
        }

    }
}
