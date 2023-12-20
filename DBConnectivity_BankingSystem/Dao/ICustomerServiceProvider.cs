using Banking_system.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.dao
{
    internal interface ICustomerServiceProvider
    {
        float GetAccountBalance(int accountNumber);

        float Deposit(int accountNumber,float amount);

        bool Withdraw(int accountNumber,float amount);

        void Transfer(int fromAccountNumber,int toAccountNumber,float amount);

        List<Account> GetAccountDetail(int accountNumber);


        List<Account> ListAccount();

        void createAccount(Customer customer,string accountType,float balance);

        List<Transaction> GetTransaction(int accountNumber,DateTime fromDate,DateTime toDate);
    }
}
