﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        public string allPhones;

        public ContactData(string firstname)
        {
            Firstname = firstname;
        }

        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return Lastname + Firstname == other.Lastname + other.Firstname;
        }

        public override int GetHashCode()
        {
            return Lastname.GetHashCode() + Firstname.GetHashCode();
        }

        public override string ToString()
        {
            return "Lastname = " + Lastname + "\n Firstname = " + Firstname;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            if (Lastname.CompareTo(other.Lastname) == 0)
            {
                if (Firstname.CompareTo(other.Firstname) == 0)
                {
                    return Firstname.CompareTo(other.Firstname);
                }
            }
            return Lastname.CompareTo(other.Lastname);
        }


        public string Firstname { get; set; }

        public string Middlename { get; set; }


        public string Lastname { get; set; }


        public string Nickname { get; set; }


        public string Address { get; set; }


        public string Home { get; set; }


        public string Mobile { get; set; }


        public string Work { get; set; }


        public string Fax { get; set; }


        public string Email { get; set; }


        public string Bday { get; set; }


        public string Bmonth { get; set; }


        public string Byear { get; set; }


        public string Aday { get; set; }


        public string Amonth { get; set; }


        public string Ayear { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return CleanUp(Home) + CleanUp(Mobile) + CleanUp(Work);
                }

            }
            set
            {
                AllPhones = value;
            }
        }

        private string CleanUp(string home)
        {
            if(home == null)
            {
                return "";
            }
            return home.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "");
        }
    }
}