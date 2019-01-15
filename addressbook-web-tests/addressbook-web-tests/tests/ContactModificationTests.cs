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

   public class ContactModificationTests : AuthTestBase
    {
        [Test]

        public void ContactModificationTest()
        {
            if (app.Contact.ContactIsNotCreated())
            {
                Assert.IsFalse(app.Contact.ContactIsNotCreated());
            }
            
            ContactData contact = new ContactData("ContactModify");
            contact.Middlename = "ContactModify";
            contact.Lastname = null;
            contact.Nickname = null;
            contact.Address = null;
            contact.Home = null;
            contact.Mobile = null;
            contact.Work = null;
            contact.Fax = null;
            contact.Email = null;
            contact.Bday = "1";
            contact.Bmonth = "April";
            contact.Byear = "1900";
            contact.Aday = "2";
            contact.Amonth = "November";
            contact.Ayear = "1111";
            app.Contact.Modify(contact);
        }
    }
}
