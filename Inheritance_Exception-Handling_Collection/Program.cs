// See https://aka.ms/new-console-template for more information

using Banking_system.dao;
using Banking_system.model;

ICustomerServiceProvider customerServiceProvider=new CustomerServiceProviderImpl();


int i = 1;
int choice = 0;
int accountNumber = 0;

do
{

    Console.WriteLine(".....Welcome to the Bank.....\n" +
        "\nPress 1 : Create Account\n" +
        "Press 2 : Deposit\n" +
        "Press 3 : Withdraw\n" +
        "Press 4 : Get Balance\n" +
        "Press 5 : Transfer\n" +
        "Press 6 : Get Account Details\n" +
        "Press 0 : Exit\n");

    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            Customer customer = new Customer();
            Console.WriteLine("Enter your first name :");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter your last name :");
            string lastName = Console.ReadLine();
            Console.WriteLine("Enter your DOB in YYYY-MM-DD format :");
            string dob = Console.ReadLine();
            Console.WriteLine("Enter your email :");
            string email = Console.ReadLine();
            Console.WriteLine("Enter your mobile number :");
            string mobileNumber = Console.ReadLine();
            Console.WriteLine("Enter your address :");
            string address = Console.ReadLine();
            Console.WriteLine("Enter account type (savings or current");
            string accountType = Console.ReadLine();
            Console.WriteLine("Enter amount to deposit :");
            float amount = float.Parse(Console.ReadLine());

            customer.FirstName = firstName;
            customer.LastName = lastName;
            customer.Email = email;
            customer.PhoneNumber = mobileNumber;
            customer.Address = address;
            customerServiceProvider.CreateAccount(customer, accountType, amount);
            break;
        case 2:
            try
            {
                Console.WriteLine("Enter your account number :");
                accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter amount to deposit");
                float depositAmount = float.Parse(Console.ReadLine());
                float balance = customerServiceProvider.Deposit(accountNumber, depositAmount);
                Console.WriteLine($"Your balance after deposit is {balance}");
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            break;
        case 3:
            try
            {
                Console.WriteLine("Enter your account number :");
                accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter amount to withdraw :");
                float withdrawAmount = float.Parse(Console.ReadLine());
                customerServiceProvider.Withdraw(accountNumber, withdrawAmount);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            break;
        case 4:
            try
            {
                Console.WriteLine("Enter Account number :");
                accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Your account balance is " + customerServiceProvider.GetAccountBalance(accountNumber));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            break;
        case 5:
            try
            {
                Console.WriteLine("Enter your account number:");
                int fromAccountNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter account number to transfer amount:");
                int toAccountNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter amount to transfer:");
                float amounts = Convert.ToSingle(Console.ReadLine());
                customerServiceProvider.Transfer(fromAccountNumber, toAccountNumber, amounts);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            break;
        case 6:
            try
            {
                Console.WriteLine("Enter your account number ");
                accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("\nYour account details are\n");
                customerServiceProvider.GetAccountDetail(accountNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            break;

        default:
            Console.WriteLine("Invalid input received");
            break;
    }
    Console.WriteLine("Press 0 to exit or any key to continue");
    i = Convert.ToInt32(Console.ReadLine());
} while (i != 0);

