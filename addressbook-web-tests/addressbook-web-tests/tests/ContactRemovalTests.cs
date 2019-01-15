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
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            if (app.Contact.ContactIsNotCreated())
            {
                Assert.IsFalse(app.Contact.ContactIsNotCreated());

            }

            ContactData contact = new ContactData("1000");
            contact.Middlename = "1000";
            contact.Lastname = "dfdfdgf";
            contact.Nickname = "eretgfgff";
            contact.Address = "dsfdgfdg";
            contact.Home = "dfdfdfggd";
            contact.Mobile = "111111";
            contact.Work = "4554546";
            contact.Fax = "fdgfgfgfg";
            contact.Email = "fdgfgfg";
            contact.Bday = "1";
            contact.Bmonth = "April";
            contact.Byear = "1900";
            contact.Aday = "2";
            contact.Amonth = "November";
            contact.Ayear = "1111";
            app.Contact.Remove(contact);
           
        }

        
    }
}
