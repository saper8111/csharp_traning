using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class LoginHelper : HelperBase
    {

        public LoginHelper(ApplicationManager manager) 
            : base(manager)
        {
        } 
        public void Login(AccountData account)
        {
            if (IsloggedIn())
            {
                if (IsloggedIn(account))
                {
                    return;
                }

                logout();
            }
            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }


        public void logout()
        {
            if (IsloggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }
           
        }

        public bool IsloggedIn()
        {
            return IsElementPresent(By.Name("logout"));
        }

        public bool IsloggedIn(AccountData account)
        {
            return IsloggedIn()
                && GetLoggetUserName() == account.Username;
        }

        private string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
            
        }
    }
}
