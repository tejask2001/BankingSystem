using Banking_system.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Part2_Association.Model
{
    internal class Bank
    {
        List<Customer> customerList= new List<Customer>();
        List<Account> accountList= new List<Account>();

        public Bank()
        {
            Customer customer = null;
        }
        int accountNumber = 1001;

        public bool CreateAccount(Customer customer,string accountType,float balance)
        {
            customer=new Customer();
            Account accounts = new Account();

            customerList.Add(customer);
            accounts.AccountNumber = accountNumber;
            accounts.AccountBalance = balance;
            accounts.AccountType = accountType;
            accounts.Cust = customer;
            accountList.Add(accounts);
            Console.WriteLine("Account created successfully.");
            accountNumber++;    

            return true;
        }

        public float GetBalance(int accountNumber)
        {
            float balance = 0;
            foreach(var item in accountList)
            {
                if(item.AccountNumber == accountNumber)
                {
                    balance = item.AccountBalance;
                    break;
                }
            }
            return balance;
        }

        public float Deposit(int accountNumber, float amount)
        {
            float balance = 0;
            foreach(var item in accountList)
            {
                if (item.AccountNumber==accountNumber)
                {
                    item.AccountBalance+=amount;
                    balance=item.AccountBalance;
                }
            }

            return balance;
        }
        public float Withdraw(int accountNumber, float amount)
        {
            float balance = 0;
            foreach (var item in accountList)
            {
                if (item.AccountNumber == accountNumber)
                {
                    item.AccountBalance -= amount;
                    balance = item.AccountBalance;
                }
            }

            return balance;
        }
        public void Transfer(int fromAccountNumber,int toAccountNumber,float amount)
        {
            float balance = 0;
            foreach(var item in accountList)
            {
                if( item.AccountNumber == fromAccountNumber)
                {
                    balance=item.AccountBalance;
                    if (balance > amount)
                    {
                        item.AccountBalance -= amount;
                        foreach(var items in accountList)
                        {
                            if(items.AccountNumber == toAccountNumber)
                            {
                                items.AccountBalance+=amount;
                            }
                        }
                    }
                }
            }
        }
        public void GetAccountDetails(int accountNumber)
        {
            foreach(var item in accountList)
            {
                if(accountNumber == item.AccountNumber)
                {
                    Console.WriteLine(item);
                }
            }
        }
    }
}
