using System;
using System.Collections.Generic;

namespace ConsoleProApp
{
    public class CustomerUI
    {
        private CustomerService service;
        private Account loggedInAccount;

        public CustomerUI()
        {
            service = new CustomerService();
        }

        public void ShowMainMenu()
        {
            while (true)
            {
                Console.WriteLine("===========================================");
                Console.WriteLine("=========== ConsoleProApp SYSTEM ==========");
                Console.WriteLine("===========================================");

                Console.WriteLine("User Menu:");
                Console.WriteLine("1. Admin");
                Console.WriteLine("2. Customer");
                Console.WriteLine("3. Exit");
                Console.Write("Choose any option(1-3): ");
                string userOption = Console.ReadLine();

                if (userOption == "1")
                {
                    Console.WriteLine("Admin Menu selected");
                    Login("Admin");
                }
                else if (userOption == "2")
                {
                    Console.WriteLine("Customer Menu selected");
                    Login("Customer");
                }
                else if (userOption == "3")
                {
                    Console.WriteLine("Exiting ConsoleProApp..");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
            Console.WriteLine("Thanks for using ConsoleProApp");
        }

        public void Login(string expectedRole)
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            string role = service.Authenticate(username, password);

            if (role == expectedRole)
            {
                loggedInAccount = service.GetAccount(username);
                if (role == "Admin")
                {
                    Console.WriteLine("Admin Login successful!");
                    ShowAdminMenu();
                }
                else if (role == "Customer")
                {
                    Console.WriteLine("Customer Login successful!");
                    ShowCustomerMenu();
                }
            }
            else
            {
                Console.WriteLine("Invalid username or password!");
            }
        }

        public void ShowAdminMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- ADMIN MENU ---");
                Console.WriteLine("1. Register customer");
                Console.WriteLine("2. Show all customers");
                Console.WriteLine("3. Search customer by name");
                Console.WriteLine("4. Upgrade customer record");
                Console.WriteLine("5. Generate balance");
                Console.WriteLine("6. Update customer balance");
                Console.WriteLine("7. Show customers net worth");
                Console.WriteLine("8. Delete record by name");
                Console.WriteLine("9. Logout");

                Console.Write("Choose any option(1-9): ");
                string adminOption = Console.ReadLine();

                if (adminOption == "1")
                {
                    RegisterCustomer();
                }
                else if (adminOption == "2")
                {
                    ShowAllCustomers();
                }
                else if (adminOption == "3")
                {
                    SearchCustomerByName();
                }
                else if (adminOption == "4")
                {
                    UpgradeCustomerRecord();
                }
                else if (adminOption == "5")
                {
                    GenerateBalance();
                }
                else if (adminOption == "6")
                {
                    UpgradeBalance();
                }
                else if (adminOption == "7")
                {
                    ShowCustomersNetWorth();
                }
                else if (adminOption == "8")
                {
                    DeleteRecord();
                }
                else if (adminOption == "9")
                {
                    Console.WriteLine("Logging out of Admin Menu..");
                    loggedInAccount = null;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid option!");
                }
            }
        }

        public void RegisterCustomer()
        {
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter Government ID: ");
            string governmentID = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            string emailAddress = Console.ReadLine();
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter Nationality: ");
            string nationality = Console.ReadLine();
            Console.Write("Enter Residential Address: ");
            string residentialAddress = Console.ReadLine();
            Console.Write("Enter Account Type: ");
            string accountType = Console.ReadLine();
            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Enter Branch Code: ");
            string branchCode = Console.ReadLine();
            Console.Write("Enter Balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            Customer customer = new Customer(firstName, lastName, age, phoneNumber, governmentID, emailAddress, gender, nationality, residentialAddress, accountType, accountNumber, branchCode, balance);
            bool result = service.RegisterCustomer(customer);

            if (result)
            {
                Console.WriteLine("Customer Registered successfully!");
            }
            else
            {
                Console.WriteLine("Account Number already exists!");
            }
        }

        public void ShowAllCustomers()
        {
            List<Customer> customers = service.GetAllCustomers();
            if (customers.Count == 0)
            {
                Console.WriteLine("No customers found.");
                return;
            }

            foreach (Customer customer in customers)
            {
                customer.DisplayInfo();
                Console.WriteLine("--------------------------------------");
            }
        }

        public void SearchCustomerByName()
        {
            Console.Write("Enter customer's Last Name: ");
            string lastName = Console.ReadLine();
            List<Customer> customers = service.FindCustomersByLastName(lastName);
            if (customers.Count > 0)
            {
                foreach (Customer customer in customers)
                {
                    customer.DisplayInfo();
                    Console.WriteLine("--------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("No customer found!");
            }
        }

        public void UpgradeCustomerRecord()
        {
            Console.Write("Enter the last name of the customer: ");
            string lastName = Console.ReadLine();

            List<Customer> customers = service.FindCustomersByLastName(lastName);

            if (customers.Count == 0)
            {
                Console.WriteLine("Customer not found!");
                return;
            }

            Customer selectedCustomer = customers[0];

            Console.WriteLine("============= Old Record =============");
            selectedCustomer.DisplayInfo();

            Console.WriteLine("Enter new record to update:");
            Console.Write("Enter First Name: ");
            string firstName = Console.ReadLine();
            Console.Write("Enter Last Name: ");
            string newLastName = Console.ReadLine();
            Console.Write("Enter Age: ");
            int age = int.Parse(Console.ReadLine());
            Console.Write("Enter Phone Number: ");
            string phoneNumber = Console.ReadLine();
            Console.Write("Enter Government ID: ");
            string governmentID = Console.ReadLine();
            Console.Write("Enter Email Address: ");
            string emailAddress = Console.ReadLine();
            Console.Write("Enter Gender: ");
            string gender = Console.ReadLine();
            Console.Write("Enter Nationality: ");
            string nationality = Console.ReadLine();
            Console.Write("Enter Residential Address: ");
            string residentialAddress = Console.ReadLine();
            Console.Write("Enter Account Type: ");
            string accountType = Console.ReadLine();
            Console.Write("Enter Account Number: ");
            string accountNumber = Console.ReadLine();
            Console.Write("Enter Branch Code: ");
            string branchCode = Console.ReadLine();
            Console.Write("Enter Balance: ");
            decimal balance = decimal.Parse(Console.ReadLine());

            Customer updatedCustomer = new Customer(firstName, newLastName, age, phoneNumber, governmentID, emailAddress, gender, nationality, residentialAddress, accountType, accountNumber, branchCode, balance);
            service.UpdateCustomer(selectedCustomer, updatedCustomer);
            Console.WriteLine("Customer record updated successfully!");
        }

        public void GenerateBalance()
        {
            List<Customer> customers = service.GetAllCustomers();

            if (customers.Count == 0)
            {
                Console.WriteLine("No customer records found!");
                return;
            }

            customers.Sort((x, y) => y.Balance.CompareTo(x.Balance));

            Console.WriteLine("Customer balances sorted successfully!");

            foreach (Customer customer in customers)
            {
                customer.DisplayInfo();
                Console.WriteLine("--------------------------------------");
            }
        }

        public void UpgradeBalance()
        {
            Console.Write("Enter the customer's last name: ");
            string lastName = Console.ReadLine();
            List<Customer> customers = service.FindCustomersByLastName(lastName);

            if (customers.Count == 0)
            {
                Console.WriteLine("Customer not found!");
                return;
            }

            Customer selectedCustomer = customers[0];

            Console.WriteLine("============= Old Record =============");
            selectedCustomer.DisplayInfo();

            Console.Write("Enter new balance: ");
            decimal newBalance = decimal.Parse(Console.ReadLine());

            service.UpdateCustomerBalance(selectedCustomer, newBalance);

            Console.WriteLine("Customer balance upgraded successfully!");
        }

        public void ShowCustomersNetWorth()
        {
            Console.Write("Enter the last name you want to find net worth of: ");
            string lastName = Console.ReadLine();

            List<Customer> customers = service.FindCustomersByLastName(lastName);

            if (customers.Count == 0)
            {
                Console.WriteLine("Customer not found!");
                return;
            }

            Customer selectedCustomer = customers[0];
            Console.WriteLine("========CUSTOMER RECORD==========");
            selectedCustomer.DisplayInfo();
            Console.WriteLine("Customer's Net Worth: " + selectedCustomer.Balance);
        }

        public void DeleteRecord()
        {
            Console.Write("Enter the last name you want to delete record of: ");
            string lastName = Console.ReadLine();

            List<Customer> customers = service.FindCustomersByLastName(lastName);

            if (customers.Count == 0)
            {
                Console.WriteLine("Customer not found!");
                return;
            }

            Customer selectedCustomer = customers[0];
            Console.WriteLine("========CUSTOMER RECORD==========");
            selectedCustomer.DisplayInfo();

            Console.Write("Are you sure you want to delete this record? (Y/N): ");
            string choice = Console.ReadLine();
            if (choice.Equals("Y", StringComparison.OrdinalIgnoreCase))
            {
                if (service.DeleteCustomer(selectedCustomer))
                {
                    Console.WriteLine("Customer record deleted successfully!");
                }
                else
                {
                    Console.WriteLine("Deletion failed!");
                }
            }
            else
            {
                Console.WriteLine("Deletion cancelled!");
            }
        }

        public void ShowCustomerMenu()
        {
            while (true)
            {
                Console.WriteLine("\n--- CUSTOMER MENU ---");
                Console.WriteLine("1. View your Profile");
                Console.WriteLine("2. Check Name Status");
                Console.WriteLine("3. Change Password");
                Console.WriteLine("4. Logout");

                Console.Write("Choose any option(1-4): ");
                string customerOption = Console.ReadLine();

                if (customerOption == "1")
                {
                    ViewYourProfile();
                }
                else if (customerOption == "2")
                {
                    CheckNameStatus();
                }
                else if (customerOption == "3")
                {
                    ChangePassword();
                }
                else if (customerOption == "4")
                {
                    Console.WriteLine("Logging out of Customer Menu..");
                    loggedInAccount = null;
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice!");
                }
            }
        }

        public void ViewYourProfile()
        {
            if (loggedInAccount == null)
            {
                Console.WriteLine("Please login first!");
                return;
            }
            Customer customer = service.GetCustomerProfile(loggedInAccount.CustomerAccountNumber);
            if (customer == null)
            {
                Console.WriteLine("Customer profile not found!");
                return;
            }
            Console.WriteLine("-------YOUR PROFILE-------");
            customer.DisplayInfo();
        }

        public void CheckNameStatus()
        {
            if (loggedInAccount == null)
            {
                Console.WriteLine("Please login first!");
                return;
            }
            Customer customer = service.GetCustomerProfile(loggedInAccount.CustomerAccountNumber);
            if (customer == null)
            {
                Console.WriteLine("Your customer record has been deleted!");
            }
            else
            {
                Console.WriteLine("Your name is active!");
            }
        }

        public void ChangePassword()
        {
            if (loggedInAccount == null)
            {
                Console.WriteLine("Please login first!");
                return;
            }
            Console.Write("Enter your current password: ");
            string currentPassword = Console.ReadLine();
            Console.Write("Enter your new password: ");
            string newPassword = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(newPassword))
            {
                Console.WriteLine("Password cannot be empty!");
                return;
            }

            bool updatedPassword = service.ChangeAccountPassword(loggedInAccount.UserName, currentPassword, newPassword);
            if (updatedPassword)
            {
                Console.WriteLine("Password changed successfully!");
            }
            else
            {
                Console.WriteLine("Current password is incorrect!");
            }
        }
    }
}
