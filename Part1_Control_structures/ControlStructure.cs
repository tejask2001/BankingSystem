using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
namespace Banking_system.dao
{
    internal class ControlStructure
    {
        #region Eligible for loan
        public void eligibleForLoan()
        {
            Console.WriteLine("Enter your Credit Score :");
            int creditScore = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter your Income :");
            float income = float.Parse(Console.ReadLine());
            if (creditScore > 700 && income >= 50000)
            {
                Console.WriteLine("Eligible for loan");
            }
            else
            {
                Console.WriteLine("Not Eligible for Loan");
            }
        }
        #endregion

        #region ATM Transaction
        public void AtmTransaction()
        {
            Console.WriteLine("Press 1:Check Balance\n" +
                "Press 2:Withdraw\n" +
                "Press 3:Deosit\n");
            int choice = 0;
            choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    {
                        float balance = 0;
                        Console.WriteLine("Enter your current balance:");
                        balance = float.Parse(Console.ReadLine());
                        Console.WriteLine($"Your balance is {balance}.");
                        break;
                    }
                case 2:
                    {
                        float balance = 0;
                        Console.WriteLine("Enter your current balance:");
                        balance = float.Parse(Console.ReadLine());
                        Console.WriteLine("Enter amount you want to withdraw:");
                        float withdrawAmount = float.Parse(Console.ReadLine());
                        if (withdrawAmount < balance)
                        {
                            Console.WriteLine($"Amount Withdraw successfully, Remaining balance is {balance - withdrawAmount}.");
                        }
                        else
                        {
                            Console.WriteLine("Insufficient balance");
                        }
                        break;
                    }
                case 3:
                    {
                        float balance = 0;
                        Console.WriteLine("Enter your current balance:");
                        balance = float.Parse(Console.ReadLine());
                        Console.WriteLine("Enter amount you want to deposit:");
                        float depositAmount = float.Parse(Console.ReadLine());
                        Console.WriteLine($"Amount deposited successfully, Updated balance is {balance + depositAmount}");
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid input");
                        break;
                    }
            }
        }
        #endregion

        #region Interest
        public void Interest()
        {
            int a = 0;
            for (int i = 0; i < 5; i++)
            {
                if (a == 1)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Enter your Balance");
                    int balance = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter annual interest rates");
                    float interest = float.Parse(Console.ReadLine());
                    Console.WriteLine("Enter number of years");
                    int years = Convert.ToInt32(Console.ReadLine());

                    double futureBalance = balance * Math.Pow((1 + interest / 100), years);
                    Console.WriteLine(futureBalance);
                }
                Console.WriteLine("Press 1 to exit");
                a = Convert.ToInt32(Console.ReadLine());
            }
        }
        #endregion

        #region Data Validation
        public void dataValidation()
        {
            string[] password = { "abc@123", "aaa@111", "bbb@222", "ccc@333" };
            int a = 1;
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Enter your password :");
                String pass = Console.ReadLine();
                if (password.Contains(pass) && a == 1)
                {
                    Console.WriteLine("Enter your balance:");
                    double balance = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine($"Your account balance is {balance}");
                    break;
                }
                Console.WriteLine("Press 1 to retry");
                a = Convert.ToInt32(Console.ReadLine());
            }

        }
        #endregion

        #region
        public void transactionHistory()
        {
            ArrayList list = new ArrayList();
            int choice = 0;
            
            int i = 1;
            do
            {                
                Console.WriteLine("Press 1: Deposit\n" +
                    "Press 2: Withdraw");

                choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter amount to deposit:");
                        float depositAmount = float.Parse(Console.ReadLine());
                        list.Add($"Deposit \t\t {depositAmount}");
                        break;
                    case 2:
                        Console.WriteLine("Enter amount to withraw:");
                        float withdrawAmount = float.Parse(Console.ReadLine());
                        list.Add($"Withdraw \t\t {withdrawAmount}");
                        break;
                    default:
                        break;
                }
                Console.WriteLine("Press 0 to exit or any key to continue");
                i=Convert.ToInt32(Console.ReadLine());
            } while (i!=0);
            Console.WriteLine("Your transaction history");
            foreach(var j in list)
            {
                Console.WriteLine(j);
            }
        }
        #endregion

    }
}
