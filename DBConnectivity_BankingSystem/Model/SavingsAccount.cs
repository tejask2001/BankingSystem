using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.model
{
    internal class SavingsAccount:Account
    {
        float interestRate = 5.5f;
        public SavingsAccount() { }

        public SavingsAccount (int accountNumber, string accountType, float accountBalance,Customer customer,float interestRate)
            : base(accountNumber, accountType, accountBalance,customer)
        {
            this.interestRate = interestRate;
        }

        public override double calculateInterest()
        {
           return AccountBalance*interestRate;
        } 
    }
}
