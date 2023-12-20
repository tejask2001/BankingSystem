using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Part2_Abstraction.Model
{
    internal class SavingsAccount : BankAccount
    {
        float interestRate = 4.5f;

        public SavingsAccount() { }

        public SavingsAccount(int accountNumber, string customerName, float balance, float interestRate)
            : base(accountNumber, customerName, balance)
        {
            this.interestRate= interestRate;
        }
        public override void calculateInterest()
        {
            Balance = Balance * interestRate;
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
            else
            {
                Balance -= amount;
            }
        }
    }
}
