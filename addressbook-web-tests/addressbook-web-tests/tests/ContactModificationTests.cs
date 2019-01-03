using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

   public class ContactModificationTests : AuthTestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            ContactData modifyData = new ContactData("900");
            modifyData.Middlename = "111111111";
            modifyData.Lastname = null;
            modifyData.Nickname = null;
            modifyData.Address = null;
            modifyData.Home = null;
            modifyData.Mobile = null;
            modifyData.Work = null;
            modifyData.Fax = null;
            modifyData.Email = null;
            modifyData.Bday = "1";
            modifyData.Bmonth = "April";
            modifyData.Byear = "1900";
            modifyData.Aday = "2";
            modifyData.Amonth = "November";
            modifyData.Ayear = "1111";
            app.Contact.Modify(1, modifyData);
        }
    }
}
