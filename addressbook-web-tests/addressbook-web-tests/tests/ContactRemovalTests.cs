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
            app.Navigation.OpenHomePage();

            if (app.Contact.ContactIsNotCreated())
            {
                ContactData newcontact = new ContactData("new contact");
                newcontact.Middlename = "new contact";
                newcontact.Lastname = "new contact";
                newcontact.Nickname = "new contact";
                newcontact.Address = "new contact";
                newcontact.Home = "new contact";
                newcontact.Mobile = "new contact";
                newcontact.Work = "new contact";
                newcontact.Fax = "new contact";
                newcontact.Email = "new contact";
                newcontact.Bday = "1";
                newcontact.Bmonth = "April";
                newcontact.Byear = "1900";
                newcontact.Aday = "2";
                newcontact.Amonth = "November";
                newcontact.Ayear = "1111";
                app.Contact.Create(newcontact);

            }

            Assert.IsFalse(app.Contact.ContactIsNotCreated());

            app.Contact.Remove();
           
        }
    }
}
