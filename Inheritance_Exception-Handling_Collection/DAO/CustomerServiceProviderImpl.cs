﻿using Banking_system.dao;
using Banking_system.model;
using Inheritance_Exception_Handling_Collection.User_Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.dao
{
    internal class CustomerServiceProviderImpl : ICustomerServiceProvider
    {
        List<Customer> customerList = new List<Customer>();
        List<Account> accountList = new List<Account>();

        public CustomerServiceProviderImpl()
        {
            Customer customer = null;
        }
        int accountNumber = 1001;
        public bool CreateAccount(Customer customer, string accountType, float balance)
        {
            customer = new Customer();
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

        public float Deposit(int accountNumber, float amount)
        {
            float balance = 0;
            foreach (var item in accountList)
            {
                if (item.AccountNumber == accountNumber)
                {
                    item.AccountBalance += amount;
                    balance = item.AccountBalance;
                }
                else
                {
                    throw new InvalidAccountException("Account not found.");
                }
            }

            return balance;
        }

        public float GetAccountBalance(int accountNumber)
        {
            float balance = 0;
            foreach (var item in accountList)
            {
                if (item.AccountNumber == accountNumber)
                {
                    balance = item.AccountBalance;
                    break;
                }
                else
                {
                    throw new InvalidAccountException("Account not found.");
                }
            }
            return balance;
        }

        public List<Account> GetAccountDetail(int accountNumber)
        {
            List<Account> accountList = new List<Account>();
            foreach (var item in accountList)
            {
                if (accountNumber == item.AccountNumber)
                {
                    accountList.Add(item);
                }
                else
                {
                    throw new InvalidAccountException("Account not found.");
                }
            }
            return accountList;
        }

        public List<Transaction> GetTransaction(int accountNumber, DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }

        public List<Account> ListAccount()
        {
            List<Account> accountList = new List<Account>();
            foreach (Account item in accountList)
            {                
                    accountList.Add(item);                
            }
            return accountList;
        }

        public void Transfer(int fromAccountNumber, int toAccountNumber, float amount)
        {
            float balance = 0;
            foreach (var item in accountList)
            {
                if (item.AccountNumber == fromAccountNumber)
                {
                    balance = item.AccountBalance;
                    if (balance > amount)
                    {
                        item.AccountBalance -= amount;
                        foreach (var items in accountList)
                        {
                            if (items.AccountNumber == toAccountNumber)
                            {
                                items.AccountBalance += amount;
                            }
                            else
                            {
                                throw new InvalidAccountException("Receiver's account not found.");
                            }
                        }
                    }
                }
                else
                {
                    throw new InvalidAccountException("Sender's account not found.");
                }
            }
        }

        public float Withdraw(int accountNumber, float amount)
        {
            float balance = GetAccountBalance(accountNumber);
            if (balance > amount)
            {
                foreach (var item in accountList)
                {
                    if (item.AccountNumber == accountNumber)
                    {
                        item.AccountBalance -= amount;
                        balance = item.AccountBalance;
                    }
                    else
                    {
                        throw new InvalidAccountException("Account not found.");
                    }
                }
            }
            else
            {
                throw new InsufficientFundException("Insufficient Balance.");
            }           

            return balance;
        }
        
    }
}
