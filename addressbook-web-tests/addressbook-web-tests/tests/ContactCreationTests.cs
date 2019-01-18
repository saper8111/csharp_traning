using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using System.Collections.Generic;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : AuthTestBase
    {
        [Test]
        public void ContactCreationTests()
        {
            ContactData contact = new ContactData("789");
            contact.Middlename = "433";
            contact.Lastname = "456";
            contact.Nickname = "87878";
            contact.Address = "ghhjhhnbm";
            contact.Home = "ghghghgh";
            contact.Mobile = "ghghghf";
            contact.Work = "fgfgfgfg";
            contact.Fax = "fgfgfgg";
            contact.Email = "fgghhghgh";
            contact.Bday = "1";
            contact.Bmonth = "April";
            contact.Byear = "1900";
            contact.Aday = "2";
            contact.Amonth = "November";
            contact.Ayear = "1111";

            //List<ContactData> oldContact = app.Contact.GetContactList();

            //app.Contact.Create(contact);

            //List<ContactData> newContact = app.Contact.GetContactList();
            //Assert.AreEqual(oldContact.Count + 1, newContact.Count);


        }



        [Test]
        public void EmptyContactCreationTests()
        {
            ContactData contact = new ContactData("");
            contact.Middlename = "";
            contact.Lastname = "";
            contact.Nickname = "";
            contact.Address = "";
            contact.Home = "";
            contact.Mobile = "";
            contact.Work = "";
            contact.Fax = "";
            contact.Email = "";
            contact.Bday = "1";
            contact.Bmonth = "April";
            contact.Byear = "1900";
            contact.Aday = "2";
            contact.Amonth = "November";
            contact.Ayear = "1111";

            //List<ContactData> oldContact = app.Contact.GetContactList();

            //app.Contact.Create(contact);

            //List<ContactData> newContact = app.Contact.GetContactList();
            //Assert.AreEqual(oldContact.Count + 1, newContact.Count);
        }

    }
}
