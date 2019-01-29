using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Threading;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        public ContactHelper(ApplicationManager manager)
                : base(manager)
        {
        }

        public ContactHelper Create(ContactData newcontact)
        {
            manager.Navigation.OpenHomePage();
            InitContactCreation();
            FillContactForm(newcontact);
            SubmitContactCreation();
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Modify(int p, ContactData modifycontact)
        {
            manager.Navigation.OpenHomePage();
            SelectContact(p);
            InitContactModification();
            FillContactForm(modifycontact);
            SubmitContactModification();
            ReturnToContactPage();
            return this;
        }

        
        

        public ContactHelper Remove(int p)
        {
            manager.Navigation.OpenHomePage();
            SelectContact(p);
            RemoveContact();
            ReturnToContactPage();
            return this;

        }

        internal List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigation.OpenHomePage();
            ICollection<IWebElement>elements = driver.FindElements(By.CssSelector("tr[name = 'entry']"));
            foreach (IWebElement element in elements)
            {
                ContactData contact = new ContactData(element.Text);
                element.FindElements(By.XPath(".//td"));
                contact.Firstname = element.FindElement(By.XPath(".//td[3]")).Text;
                contact.Lastname = element.FindElement(By.XPath(".//td[2]")).Text;

                contacts.Add(contact);
            }
            return contacts;
        }

        public bool ContactIsNotCreated()
        {
            return !IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//div[4]/form[1]/input[1]")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//tr[@name='entry']//td[8]")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            Thread.Sleep(1000);
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index +1) + "]")).Click();
            return this;
        }


        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            return this;
        }

        public ContactHelper InitContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }

        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            Type(By.Name("address"), contact.Address);
            Type(By.Name("home"), contact.Home);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.Work);
            Type(By.Name("fax"), contact.Fax);
            Type(By.Name("email"), contact.Email);
            Type(By.Name("fax"), contact.Fax);
            driver.FindElement(By.Name("bday")).Click();
            new SelectElement(driver.FindElement(By.Name("bday"))).SelectByText(contact.Bday);
            driver.FindElement(By.XPath("//option[@value='9']")).Click();
            driver.FindElement(By.Name("bmonth")).Click();
            new SelectElement(driver.FindElement(By.Name("bmonth"))).SelectByText(contact.Bmonth);
            driver.FindElement(By.XPath("//option[@value='January']")).Click();
            Type(By.Name("byear"), contact.Byear);
            new SelectElement(driver.FindElement(By.Name("aday"))).SelectByText(contact.Aday);
            driver.FindElement(By.XPath("(//option[@value='17'])[2]")).Click();
            new SelectElement(driver.FindElement(By.Name("amonth"))).SelectByText(contact.Amonth);
            driver.FindElement(By.XPath("(//option[@value='November'])[2]")).Click();
            Type(By.Name("ayear"), contact.Ayear);
            return this;
        }

        public ContactHelper Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
            return this;
        }


    }
}
