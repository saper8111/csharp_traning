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
            ContactData newContact = new ContactData("200");
            newContact.Middlename = null;
            newContact.Lastname = null;
            newContact.Nickname = null;
            newContact.Address = null;
            newContact.Home = null;
            newContact.Mobile = null;
            newContact.Work = null;
            newContact.Fax = null;
            newContact.Email = null;
            newContact.Bday = "1";
            newContact.Bmonth = "April";
            newContact.Byear = "1900";
            newContact.Aday = "2";
            newContact.Amonth = "November";
            newContact.Ayear = "1111";

            app.Contact.Remove(7, newContact);
        }

    }
}
