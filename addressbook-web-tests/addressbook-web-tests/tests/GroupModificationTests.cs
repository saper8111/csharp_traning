using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {
            GroupData newModifyData = new GroupData("mod");
            newModifyData.Header = "modify";
            newModifyData.Footer = "modify";
            app.Groups.Modify(1, newModifyData);
        }

    }
}
