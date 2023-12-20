using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.model
{
    internal class Customer
    {
        int customerId;
        string firstName;
        string lastName;
        string dateOfBirth;
        string email;
        string phoneNumber;
        string address;

        public Customer() { }
        public Customer(int id, string firstName, string lastName,string dateOfBirth, string email, string phoneNumber, string address)
        {
            customerId = id;
            this.firstName = firstName;
            this.lastName = lastName;
            this.dateOfBirth = dateOfBirth;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.address = address;
        }

        public int CustomerId
        {
            get { return customerId; }
            set { customerId = value; }
        }
        public string FirstName
        {
            get { return firstName; }
            set { firstName = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public string Email
        {
            get { return email; }
            set { email = value; }
        }
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        public override string ToString()
        {
            return $"CustomerId : {customerId}\n" +
                $"FirstName : {firstName}\n" +
                $"LastName : {lastName}\n" +
                $"DOB : {dateOfBirth}" +
                $"Email :{email}\n" +
                $"PhoneNumber {phoneNumber}\n" +
                $"Address : {address}";
        }
    }
}
