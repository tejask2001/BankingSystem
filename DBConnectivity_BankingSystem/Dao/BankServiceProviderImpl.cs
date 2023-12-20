using Banking_system.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.dao
{
    internal class BankServiceProviderImpl : IBankServiceProvider
    {
        public float calculateInterest()
        {
            throw new NotImplementedException();
        }

        public void createAccount(Customer customer, long accNo, string accType, float balance)
        {
            throw new NotImplementedException();
        }

        public void getAccountDetail(int accountNumber)
        {
            throw new NotImplementedException();
        }

        public List<Account> listAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
