using Banking_system.model;
using E_Commerce_App.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banking_system.dao
{
    internal class BankServiceProviderImpl : IBankServiceProvider
    {
        public string connectionString = null;
        SqlCommand cmd = null;

        Customer customer = new Customer();
        Account account = new Account();

        public BankServiceProviderImpl()
        {
            connectionString = DBUtil.GetConnectionString();
            cmd = new SqlCommand();
        }
        public float calculateInterest()
        {
            throw new NotImplementedException();
        }

        public void createAccount(Customer customer, long accNo, string accountType, float balance)
        {
            int customerId = 0;
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
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
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                customerId = Convert.ToInt32(cmd.ExecuteScalar());
                sqlConnection.Close();

                cmd.CommandText = "insert into Accounts values(@customerId,@accountType,@balance)";
                cmd.Parameters.AddWithValue("@customerId", customerId);
                cmd.Parameters.AddWithValue("@accountType", accountType);
                cmd.Parameters.AddWithValue("@balance", balance);
                cmd.Connection = sqlConnection;
                sqlConnection.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Account created successfully......");
                }
            }

        }

        public List<Account> getAccountDetail(int accountNumber)
        {
            List<Account> accountDetail = new List<Account>();

            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    cmd.CommandText = "select * from Customer join Accounts on Customer.customer_id=Accounts.customer_id " +
                        "where Accounts.account_id=@accountNumber";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@accountNumber", accountNumber);
                    cmd.Connection = sqlConnection;
                    sqlConnection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Account account = new Account();
                        Customer customer = new Customer();

                        customer.CustomerId = (int)reader["customer_id"];
                        customer.FirstName = (string)reader["first_name"];
                        customer.LastName = (string)reader["last_name"];
                        customer.Email = (string)reader["email"];
                        customer.PhoneNumber = (string)reader["phone_number"];
                        customer.Address = (string)reader["address"];

                        account.AccountNumber = (int)reader["account_id"];
                        account.AccountType = (string)reader["account_type"];
                        decimal balance = (decimal)reader["balance"];
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

        public List<Account> listAccounts()
        {
            throw new NotImplementedException();
        }
    }
}
