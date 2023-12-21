using Banking_system.model;
using E_Commerce_App.Utility;
using Inheritance_Exception_Handling_Collection.User_Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.dao
{    
    internal class CustomerServiceProviderImpl : ICustomerServiceProvider
    {
        public string connectionString = null;
        SqlCommand cmd = null;

        Customer customer=new Customer();
        Account account = new Account();

        public CustomerServiceProviderImpl()
        {
            connectionString = DBUtil.GetConnectionString();
            cmd = new SqlCommand();
        }

        public float Deposit(int accountNumber, float amount)
        {
            float balance = 0;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "update Accounts set balance=balance+@amount output inserted.balance where " +
                        "account_id=@accountNumber";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@amount", amount);
                    cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    balance = Convert.ToSingle(cmd.ExecuteScalar());
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return balance;
        }

        public float GetAccountBalance(int accountNumber)
        {
            float balance = 0;
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select balance from Accounts where account_id=@accountNumber";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    balance = Convert.ToSingle(cmd.ExecuteScalar());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }            
            return balance;
        }

        public List<Account> GetAccountDetail(int accountNumber)
        {
            List<Account> accountDetail = new List<Account>();

            try
            {
                using(SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Customer join Accounts on Customer.customer_id=Accounts.customer_id " +
                        "where Accounts.account_id=@accountNumber";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                    cmd.Connection= sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader=cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Account account = new Account();
                        Customer customer= new Customer();

                        customer.CustomerId = (int)reader["customer_id"];
                        customer.FirstName = (string)reader["first_name"];
                        customer.LastName = (string)reader["last_name"];
                        customer.Email = (string)reader["email"];
                        customer.PhoneNumber = (string)reader["phone_number"];
                        customer.Address= (string)reader["address"];

                        account.AccountNumber = (int)reader["account_id"];
                        account.AccountType = (string)reader["account_type"];
                        decimal balance= (decimal)reader["balance"];
                        account.AccountBalance = (float)balance;
                        account.Cust = customer;
                        accountDetail.Add(account);
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return accountDetail;
        }

        public List<Account> ListAccount()
        {
            List<Account> accountList= new List<Account>();
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from accounts";
                    cmd.Connection=sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Account account=new Account();
                        Customer customer=new Customer();
                        account.AccountNumber = (int)reader["account_id"];
                        account.AccountType = (string)reader["account_type"];
                        decimal balance = (decimal)reader["balance"];
                        account.AccountBalance = (float)balance;                        
                        accountList.Add(account);
                    }

                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }

            return accountList;
        }

        public void Transfer(int fromAccountNumber, int toAccountNumber, float amount)
        {
            float balance = GetAccountBalance(fromAccountNumber);
            if(balance> amount)
            {
                try
                {
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {

                        cmd.CommandText = "update Accounts set balance=balance-@amount output inserted.balance where " +
                                            "account_id=@fromAccountNumber";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("fromAccountNumber", fromAccountNumber);
                        cmd.Connection = sqlConnection;
                        sqlConnection.Open();
                        balance = Convert.ToSingle(cmd.ExecuteScalar());
                        sqlConnection.Close();

                        cmd.CommandText = "update Accounts set balance=balance+@amount output inserted.balance where " +
                        "account_id=@toAccountNumber";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@toAccountNumber", toAccountNumber);
                        cmd.Connection = sqlConnection;
                        sqlConnection.Open();
                        cmd.ExecuteScalar();

                        Console.WriteLine($"\nUpdated balance after transfer is {balance}\n");

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else 
            {
                throw new InsufficientFundException("Insufficient balance");
            }          
                        
        }

        public bool Withdraw(int accountNumber, float amount)
        {
            float balance;

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select balance from accounts where account_id=@accountNumber";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    balance = Convert.ToSingle(cmd.ExecuteScalar());
                    sqlConnection.Close();

                    if (balance > amount)
                    {
                        cmd.CommandText = "update Accounts set balance=balance-@amount output inserted.balance where " +
                                            "account_id=@accountNumber";
                        cmd.Parameters.Clear();
                        cmd.Parameters.AddWithValue("@amount", amount);
                        cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                        cmd.Connection = sqlConnection;
                        sqlConnection.Open();
                        balance = Convert.ToSingle(cmd.ExecuteScalar());
                        Console.WriteLine($"Your updated balance is {balance}");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance");
                        return false;
                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            return true;
        }

        public void createAccount(Customer customer, string accountType, float balance)
        {
            int customerId = 0;
            using(SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "insert into Customer output inserted.customer_id values(@firstName,@lastName," +
                    "@dob,@email,@mobileNumber,@address)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@firstName", customer.FirstName);
                cmd.Parameters.AddWithValue("@lastName", customer.LastName);
                cmd.Parameters.AddWithValue("@dob", customer.DateOfBirth);
                cmd.Parameters.AddWithValue("@email", customer.Email);
                cmd.Parameters.AddWithValue("@mobileNumber", customer.PhoneNumber);
                cmd.Parameters.AddWithValue("@address", customer.Address);
                cmd.Connection=sqlConnection;
                sqlConnection.Open();
                customerId = Convert.ToInt32(cmd.ExecuteScalar());
                sqlConnection.Close();

                cmd.CommandText = "insert into Accounts values(@customerId,@accountType,@balance)";
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@accountType", accountType);
                cmd.Parameters.AddWithValue("@balance", balance);
                cmd.Connection= sqlConnection;
                sqlConnection.Open();
                int rowsAffected=cmd.ExecuteNonQuery();
                if(rowsAffected > 0)
                {
                    Console.WriteLine("Account created successfully......");
                }
            }            
        }
        public List<Transaction> GetTransaction(int accountNumber, DateTime fromDate, DateTime toDate)
        {
            List<Transaction> transactionList = new List<Transaction>();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                cmd.CommandText = "select * from Transactions where transaction_date between @fromDate and @toDate " +
                    "and account_id=@accountNumber";
                cmd.Parameters.AddWithValue("@fromDate", fromDate);
                cmd.Parameters.AddWithValue("@toDate", toDate);
                cmd.Parameters.AddWithValue("accountNumber", accountNumber);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                SqlDataReader reader=cmd.ExecuteReader();

                while(reader.Read())
                {
                    Transaction transaction = new Transaction();
                    transaction.Account = (int)reader["account_id"];
                    transaction.TransactionType = (string)reader["transaction_type"];
                    decimal amount = (decimal)reader["amount"];
                    transaction.TransactionAmount =(float) amount;
                    transaction.DateAndTime = (DateTime)reader["transaction_date"];
                    transactionList.Add(transaction);

                }
            }
            return transactionList;
        }
    }
}
