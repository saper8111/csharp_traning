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

        private List<ContactData> contactCach = null;

        public List<ContactData> GetContactList()
        {
            if(contactCach == null)
            {
                contactCach = new List<ContactData>();
                manager.Navigation.OpenHomePage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name = 'entry']"));
                foreach (IWebElement element in elements)
                {
                    ContactData contact = new ContactData(element.Text);
                    element.FindElements(By.XPath(".//td"));
                    contact.Firstname = element.FindElement(By.XPath(".//td[3]")).Text;
                    contact.Lastname = element.FindElement(By.XPath(".//td[2]")).Text;

                    contactCach.Add(contact);
                }
            }
            
            return new List<ContactData> (contactCach);
        }

        public bool ContactIsNotCreated()
        {
            return !IsElementPresent(By.Name("selected[]"));
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//div[4]/form[1]/input[1]")).Click();
            contactCach = null;
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
            contactCach = null;
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
            contactCach = null;
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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigation.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));
            string lastname = cells[1].Text;
            string firstname = cells[2].Text;
            string address = cells[3].Text;
            string allPhones = cells[5].Text;

            return new ContactData(firstname)
            {
                Address = address,
                AllPhones = allPhones

            };



        }

        public ContactData GetContactInformationFromEditForm(int index)
        {
            manager.Navigation.OpenHomePage();
            InitContactModification(0);
            string firstname = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string lastname = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string home = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobile = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string work = driver.FindElement(By.Name("work")).GetAttribute("value");

            return new ContactData(firstname)
            {
                Address = address,
                Home = home,
                Mobile = mobile,
                Work = work

            };

            

        }

        public void  InitContactModification(int index)
        {
            driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();
        }
    }
}
