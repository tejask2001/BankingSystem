using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_Abstraction.Model
{
    internal class CurrentAccount : BankAccount
    {
        const float overdraftLimit = 50000f;
        public CurrentAccount(int accountNumber, string customerName, float balance)
            : base(accountNumber, customerName, balance)
        {
            
        }
        public override void calculateInterest()
        {
            throw new NotImplementedException();
        }

        public override float Deposit(float amount)
        {
            Balance += amount;
            return Balance;
        }

        public override void Withdraw(float amount)
        {
            if (amount > Balance)
            {
                Console.WriteLine("insufficient balance");
            }
            else if (amount > overdraftLimit)
            {
                Console.WriteLine("Withdraw limit reached");
            }
            else
            {
                Balance -= amount;
            }
        }
    }
}
