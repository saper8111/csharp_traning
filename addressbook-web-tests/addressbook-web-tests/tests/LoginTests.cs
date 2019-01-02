﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]

    public class LoginTests : TestBase
    {

        [Test]

        public void LoginWithInvalidCredentials()
        {
            // prepare
            app.Auth.logout();

            // action
            AccountData account = new AccountData("admin", "1");
            app.Auth.Login(account);

            // verification
            Assert.IsFalse(app.Auth.IsloggedIn(account));
        }

        [Test]

        public void LoginWithValidCredentials()
        {
            // prepare
            app.Auth.logout();

            // action
            AccountData account = new AccountData("admin", "secret");
            app.Auth.Login(account);

            // verification
            Assert.IsTrue(app.Auth.IsloggedIn(account));
        }

        
    }
}
