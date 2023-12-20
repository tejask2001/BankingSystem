using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.model
{
    internal class Account
    {
        int accountNumber;
        string accountType;
        float accountBalance;

        public Account() { }
        public Account(int accountNumber, string accountType, float accountBalance)
        {
            this.accountNumber = accountNumber;
            this.accountType = accountType;
            this.accountBalance = accountBalance;
        }
        public int AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }
        public string AccountType
        {
            get { return accountType; }
            set { accountType = value; }
        }
        public float AccountBalance
        {
            get { return accountBalance; }
            set { accountBalance = value; }
        }

        public override string ToString()
        {
            return $"accountNumber :{accountBalance}, accountType :{accountType},accountBalance :{accountBalance}";
        }

        public bool deposit(float amount)
        {
            accountBalance += amount;
            return true;
        }
        public virtual bool withdraw(float amount)
        {
            if (amount > accountBalance)
            {
                Console.WriteLine("insufficient balance");
                return false;
            }
            else
            {
                accountBalance -= amount;
            }
            return true;
        }
        public virtual double calculateInterest()
        {
            return accountBalance * 4.5;
        }

        //Overloading deposit and withdraw methods for Assignment-8
        public bool deposit(int amount)
        {
            accountBalance += amount;
            return true;
        }
        public bool withdraw(int amount)
        {
            if (amount > accountBalance)
            {
                Console.WriteLine("insufficient balance");
                return false;
            }
            else
            {
                accountBalance -= amount;
            }
            return true;
        }
        public bool deposit(double amount)
        {
            accountBalance += (float) amount;
            return true;
        }
        public bool withdraw(double amount)
        {
            if (amount > accountBalance)
            {
                Console.WriteLine("insufficient balance");
                return false;
            }
            else
            {
                accountBalance -= (float) amount;
            }
            return true;
        }
    }
}
