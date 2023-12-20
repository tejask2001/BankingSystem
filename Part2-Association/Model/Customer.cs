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
        string email;
        string phoneNumber;
        string address;

        public Customer() { }
        public Customer(int id, string firstName, string lastName, string email, string phoneNumber, string address)
        {
            customerId = id;
            this.firstName = firstName;
            this.lastName = lastName;
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
            return $"customerId : {customerId}, firstName : {firstName}, lastName : {lastName}, email :{email}, phoneNumber {phoneNumber}, address : {address} ";
        }
    }
}
