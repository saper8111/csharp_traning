﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTest : TestBase
    {
        [Test]
        public void ContactCreationTests()
        {
            app.Navigation.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contact.InitContactCreation();
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
            app.Contact.FillContactForm(contact);
            app.Contact.SubmitContactCreation();
            app.Contact.ReturnToContactPage();
            app.Contact.Logout();
        }

    }
}
