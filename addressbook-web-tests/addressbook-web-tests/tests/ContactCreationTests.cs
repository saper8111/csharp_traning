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
            ContactData contact = new ContactData("test");
            contact.Middlename = "test 1";
            contact.Lastname = "test 2";
            contact.Nickname = "test 3";
            contact.Address = "1-ya Nasha street, app.2";
            contact.Home = "+7(977)111-11-11";
            contact.Mobile = "+7(012)010-54-77";
            contact.Work = "+7(234)567-89-01";
            contact.Fax = "";
            contact.Email = "123@gmail.com";
            contact.Bday = "1";
            contact.Bmonth = "April";
            contact.Byear = "1900";
            contact.Aday = "2";
            contact.Amonth = "November";
            contact.Ayear = "1111";

            List<ContactData> oldContact = app.Contact.GetContactList();

            app.Contact.Create(contact);
        
            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);
           
            


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

            List<ContactData> oldContact = app.Contact.GetContactList();

            app.Contact.Create(contact);

            List<ContactData> newContact = app.Contact.GetContactList();
            oldContact.Add(contact);
            oldContact.Sort();
            newContact.Sort();
            Assert.AreEqual(oldContact, newContact);


        }

    }
}
