using Banking_system.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.dao
{
    internal interface IBankServiceProvider
    {
        void createAccount(Customer customer, long accNo, String accType, float balance);

        List<Account> listAccounts();

        void getAccountDetail(int accountNumber);
        float calculateInterest();
    }
}
