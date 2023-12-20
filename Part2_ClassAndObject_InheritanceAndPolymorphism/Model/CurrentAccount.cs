using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.model
{
    internal class CurrentAccount:Account
    {
        const float overdraftLimit = 50000.00f;
        public CurrentAccount() { }

        public CurrentAccount(int accountNumber, string accountType, float accountBalance)
            : base(accountNumber, accountType, accountBalance)
        {

        }

        public override bool withdraw(float amount)
        {
            if(overdraftLimit > amount)
            {
                AccountBalance -= amount;
                return true;
            }
            else
            {
                Console.WriteLine("Limit excedded...");
            }
            return false;
        }
    }
}
