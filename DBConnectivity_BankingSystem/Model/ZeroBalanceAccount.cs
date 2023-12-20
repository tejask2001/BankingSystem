using Banking_system.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBConnectivity_BankingSystem.Model
{
    internal class ZeroBalanceAccount:Account
    {
        public ZeroBalanceAccount(int accountNumber, string accountType, float accountBalance, Customer customer)
            : base(accountNumber, accountType, accountBalance, customer)
        {

        }
    }
}
