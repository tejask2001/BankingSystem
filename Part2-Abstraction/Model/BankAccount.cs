using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_Abstraction.Model
{
    internal abstract class BankAccount
    {
        int accountNumber;
        string customerName;
        float balance;

        public BankAccount() { }

        public BankAccount(int accountNumber,string customerName, float balance)
        {
            this.accountNumber = accountNumber;
            this.customerName = customerName;
            this.balance = balance;
        }
        public int AccountNumber 
        { 
            get {  return accountNumber; } 
            set { accountNumber = value; }
        }
        public string CustomerName
        {
            get { return customerName; }
            set { customerName = value; }
        }
        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        public override string ToString()
        {
            return $"accountNumber :{customerName}, customerName :{customerName},accountBalance :{balance}";
        }

        public abstract float Deposit(float amount);
        public abstract void Withdraw(float amount);
        public abstract void calculateInterest();


    }
}
