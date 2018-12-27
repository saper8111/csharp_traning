using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

   public class ContactModificationTests : TestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            ContactData newData = new ContactData("900");
            newData.Middlename = "222";
            newData.Lastname = "333";
            newData.Nickname = "444";
            newData.Address = "ghhjhhnbm";
            newData.Home = "ghghghgh";
            newData.Mobile = "ghghghf";
            newData.Work = "fgfgfgfg";
            newData.Fax = "fgfgfgg";
            newData.Email = "fgghhghgh";
            newData.Bday = "1";
            newData.Bmonth = "April";
            newData.Byear = "1900";
            newData.Aday = "2";
            newData.Amonth = "November";
            newData.Ayear = "1111";
            app.Contact.Modify(1, newData);
        }
    }
}
