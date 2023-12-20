// See https://aka.ms/new-console-template for more information
using Banking_system.dao;
using Banking_system.model;

//Console.WriteLine("Hello, World!");

//ICustomerServiceProvider customerServiceProvider = new CustomerServiceProviderImpl();
//List<Account> account=new List<Account>();
//account = customerServiceProvider.ListAccount();
//foreach(var v in account)
//{
//    Console.WriteLine(v+"\n");
//}

int i = 1;
int choice = 0;
int accountNumber = 0;

CustomerServiceProviderImpl impl=new CustomerServiceProviderImpl();




do
{

    Console.WriteLine(".....Welcome to the Bank.....\n" +
        "\nPress 1 : Create Account\n" +
        "Press 2 : Deposit\n" +
        "Press 3 : Withdraw\n" +
        "Press 4 : Get Balance\n" +
        "Press 5 : Transfer\n" +
        "Press 6 : Get Account Details\n" +
        "Press 7 : List Account\n" +
        "Press 8 : Get Transaction\n" +
        "Press 0 : Exit\n");

    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            try
            {
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
                customer.DateOfBirth = dob;
                customer.Email = email;
                customer.PhoneNumber = mobileNumber;
                customer.Address = address;
                impl.createAccount(customer, accountType, amount);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            break;
        case 2:
            try
            {
                Console.WriteLine("Enter your account number :");
                accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter amount to deposit");
                float depositAmount = float.Parse(Console.ReadLine());
                float balance = impl.Deposit(accountNumber, depositAmount);
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
                impl.Withdraw(accountNumber, withdrawAmount);
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
                Console.WriteLine("Your account balance is " + impl.GetAccountBalance(accountNumber));
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
                int fromAccountNumber=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter account number to transfer amount:");
                int toAccountNumber=Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter amount to transfer:");
                float amount=Convert.ToSingle(Console.ReadLine());
                impl.Transfer(fromAccountNumber, toAccountNumber, amount);
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
                impl.GetAccountDetail(accountNumber);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            break;
        case 7:
            try
            {
                impl.ListAccount();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            
            break;
        case 8:
            try
            {
                List<Transaction> transactionList = new List<Transaction>();
                Console.WriteLine("Enter Account number :");
                accountNumber = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the start date");
                string sDate = Console.ReadLine();
                DateTime startDate = DateTime.Parse(sDate);
                Console.WriteLine("Enter the end date");
                string eDate = Console.ReadLine();
                DateTime endDate = DateTime.Parse(eDate);
                transactionList = impl.GetTransaction(accountNumber, startDate, endDate);
                foreach (var transaction in transactionList)
                {
                    Console.WriteLine(transaction);
                }
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