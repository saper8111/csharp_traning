using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
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

        public ContactHelper Create(ContactData contact)
        {
            manager.Navigation.OpenHomePage();
            InitContactCreation();
            FillContactForm(contact);
            SubmitContactCreation();
            ReturnToContactPage();
            //Logout();
            return this;
        }

        public ContactHelper Modify(int v, ContactData modifyData)
        {
                manager.Navigation.OpenHomePage();
                SelectContact(v);
                InitContactModification();
                FillContactForm(modifyData);
                SubmitContactModification();
                ReturnToContactPage();
            //Logout();
            return this;
        }

        public List<ContactData> GetContactList()
        {
            List<ContactData> contacts = new List<ContactData>();
            manager.Navigation.OpenHomePage();
            ICollection<IWebElement>elements = driver.FindElements(By.XPath("//td[1]/input[1]"));
            foreach (IWebElement element in elements)
            {
                contacts.Add(new ContactData(element.Text));
            }
            return contacts;
        }

        public ContactHelper Remove(int v, ContactData newContact)
        {
                manager.Navigation.OpenHomePage();
                SelectContact(v);
                RemoveContact();
                ReturnToContactPage();
                //Logout();
            return this;

        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.XPath("//div[4]/form[1]/input[1]")).Click();
            return this;
        }

        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//a[@href='edit.php?id=178']")).Click();

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
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + index + "]")).Click();
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
