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
          
            ContactData newData = new ContactData("900");
            newData.Middlename = null;
            newData.Lastname = null;
            newData.Nickname = null;
            newData.Address = null;
            newData.Home = null;
            newData.Mobile = null;
            newData.Work = null;
            newData.Fax = null;
            newData.Email = null;
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
