using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressBookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstname;
        private string middlename;
        private string lastname;
        private string nickname;
        private string title;
        private string company;
        private string address;
        private string homePhone;
        private string mobilePhone;
        private string workPhone;
        private string fax;
        private string email;
        private string email2;
        private string email3;
        private string homepagePhone;
        private string address2;
        private string phone2;
        private string notes;

        public ContactData(string firstname, string lastname)
        {
            this.firstname = firstname;
            this.lastname = lastname;
        }

        public bool Equals(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {                
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname;
        }

        public override int GetHashCode()
        {
            return Firstname.GetHashCode();
        }        

        public override string ToString()
        {
            return Firstname;            
        }

        public int CompareTo(ContactData other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }
            return Firstname.CompareTo(other.Firstname);
        }



        public string Firstname { get { return firstname; } set { firstname = value; } }
        public string Middlename { get { return middlename; } set {middlename = value; } }
        public string Lastname { get { return lastname; } set {lastname = value; } }
        public string Nickname { get { return nickname; } set { nickname = value; } }
        public string Title { get { return title; } set { title = value; } }
        public string Company { get { return company; } set { company = value; } }
        public string Address { get { return address; } set { address = value; } }
        public string HomePhone { get { return homePhone; } set { homePhone = value; } }
        public string MobilePhone { get { return mobilePhone; } set { mobilePhone = value; } }
        public string WorkPhone { get { return workPhone; } set { workPhone = value; } }
        public string Fax { get { return fax; } set { fax = value; } }
        public string Email { get { return email; } set { email = value; } }
        public string Email2 { get { return email2; } set { email2 = value; } }
        public string Email3 { get { return email3; } set { email3 = value; } }
        public string HomePagePhone { get { return homepagePhone; } set { homepagePhone = value; } }
        public string Address2 { get { return address2; } set { address2 = value; } }
        public string Phone2 { get { return phone2; } set { phone2 = value; } }
        public string Notes { get { return notes; } set { notes = value; } }


    }
}
