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

            GroupData newRemoveData = new GroupData("qwe");
            newRemoveData.Header = "qwerty";
            newRemoveData.Footer = "qwerty3076910";
            app.Groups.Remove(1, newRemoveData);
        }

    }
}
