using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]

   public class ContactModificationTests : AuthTestBase
    {
        [Test]

        public void ContactModificationTest()
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

            ContactData Modifycontact = new ContactData("qqq");
            Modifycontact.Middlename = "1";
            Modifycontact.Lastname = "2";
            Modifycontact.Nickname = "3";
            Modifycontact.Address = "55555";
            Modifycontact.Home = "5444";
            Modifycontact.Mobile = "4";
            Modifycontact.Work = "fr";
            Modifycontact.Fax = "new modifycontact";
            Modifycontact.Email = "new modifycontact";
            Modifycontact.Bday = "1";
            Modifycontact.Bmonth = "April";
            Modifycontact.Byear = "1900";
            Modifycontact.Aday = "2";
            Modifycontact.Amonth = "November";
            Modifycontact.Ayear = "1111";

            List<ContactData> oldContact = app.Contact.GetContactList();

            app.Contact.Modify(0, Modifycontact);

            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact[0].Firstname = Modifycontact.Firstname;
            oldContact[0].Lastname = Modifycontact.Lastname;
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);


        }
    }
}
