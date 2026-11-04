using System;

namespace ConsoleProApp
{
    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string PhoneNumber { get; set; }
        public string GovernmentID { get; set; }
        public string EmailAddress { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string ResidentialAddress { get; set; }
        public string AccountType { get; set; }
        public string AccountNumber { get; set; }
        public string BranchCode { get; set; }
        public decimal Balance { get; set; }

        public Customer(string firstName, string lastName, int age, string phoneNumber, string governmentID, string emailAddress, string gender, string nationality, string residentialAddress, string accountType, string accountNumber, string branchCode, decimal balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            PhoneNumber = phoneNumber;
            GovernmentID = governmentID;
            EmailAddress = emailAddress;
            Gender = gender;
            Nationality = nationality;
            ResidentialAddress = residentialAddress;
            AccountType = accountType;
            AccountNumber = accountNumber;
            BranchCode = branchCode;
            Balance = balance;
        }

        public void DisplayInfo()
        {
            Console.WriteLine("First Name: " + FirstName);
            Console.WriteLine("Last Name: " + LastName);
            Console.WriteLine("Age: " + Age);
            Console.WriteLine("Phone Number: " + PhoneNumber);
            Console.WriteLine("Government ID: " + GovernmentID);
            Console.WriteLine("Email Address: " + EmailAddress);
            Console.WriteLine("Gender: " + Gender);
            Console.WriteLine("Nationality: " + Nationality);
            Console.WriteLine("Residential Address: " + ResidentialAddress);
            Console.WriteLine("Account Type: " + AccountType);
            Console.WriteLine("Account Number: " + AccountNumber);
            Console.WriteLine("Branch Code: " + BranchCode);
            Console.WriteLine("Balance: " + Balance);
        }
    }

    public class Account
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string CustomerAccountNumber { get; set; }

        public Account(string username, string password, string role, string customerAccountNumber)
        {
            UserName = username;
            Password = password;
            Role = role;
            CustomerAccountNumber = customerAccountNumber;
        }
    }
}
