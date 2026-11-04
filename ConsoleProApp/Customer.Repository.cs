using System;
using System.Collections.Generic;
using System.IO;

namespace ConsoleProApp
{
    public class CustomerRepository
    {
        private List<Customer> customers = new List<Customer>();
        private List<Account> accounts = new List<Account>();

        public void AddCustomer(Customer customer)
        {
            customers.Add(customer);
        }

        public void SaveCustomers()
        {
            using (StreamWriter writer = new StreamWriter("Customers.txt"))
            {
                foreach (Customer customer in customers)
                {
                    writer.WriteLine(customer.FirstName + "|" + customer.LastName + "|" + customer.Age + "|" + customer.PhoneNumber + "|" + customer.GovernmentID + "|" + customer.EmailAddress + "|" + customer.Gender + "|" + customer.Nationality + "|" + customer.ResidentialAddress + "|" + customer.AccountType + "|" + customer.AccountNumber + "|" + customer.BranchCode + "|" + customer.Balance);
                }
            }
        }

        public bool AccountExists(string accountNumber)
        {
            foreach (Customer customer in customers)
            {
                if (customer.AccountNumber == accountNumber)
                {
                    return true;
                }
            }
            return false;
        }

        public List<Customer> FindCustomersByLastName(string lastName)
        {
            List<Customer> matches = new List<Customer>();
            foreach (Customer customer in customers)
            {
                if (customer.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase))
                {
                    matches.Add(customer);
                }
            }
            return matches;
        }

        public void LoadCustomers()
        {
            if (!File.Exists("Customers.txt"))
            {
                return;
            }
            customers.Clear();
            using (StreamReader reader = new StreamReader("Customers.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 13)
                    {
                        int age = int.Parse(parts[2]);
                        decimal balance = decimal.Parse(parts[12]);
                        Customer customer = new Customer(parts[0], parts[1], age, parts[3], parts[4], parts[5], parts[6], parts[7], parts[8], parts[9], parts[10], parts[11], balance);
                        customers.Add(customer);
                    }
                }
            }
        }

        public void AddAccount(Account account)
        {
            accounts.Add(account);
        }

        public void SaveAccounts()
        {
            using (StreamWriter writer = new StreamWriter("Accounts.txt"))
            {
                foreach (Account account in accounts)
                {
                    writer.WriteLine(account.UserName + "|" + account.Password + "|" + account.Role + "|" + account.CustomerAccountNumber);
                }
            }
        }

        public Account FindAccount(string username)
        {
            foreach (Account account in accounts)
            {
                if (account.UserName.Equals(username, StringComparison.OrdinalIgnoreCase))
                {
                    return account;
                }
            }
            return null;
        }

        public void LoadAccounts()
        {
            if (!File.Exists("Accounts.txt"))
            {
                return;
            }
            accounts.Clear();
            using (StreamReader reader = new StreamReader("Accounts.txt"))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length >= 4)
                    {
                        Account account = new Account(parts[0], parts[1], parts[2], parts[3]);
                        accounts.Add(account);
                    }
                }
            }
        }

        public List<Customer> GetAllCustomers()
        {
            return customers;
        }

        public void UpdateCustomer(Customer oldCustomer, Customer newCustomer)
        {
            int index = customers.IndexOf(oldCustomer);
            if (index != -1)
            {
                customers[index] = newCustomer;
                SaveCustomers();
            }
        }

        public Customer FindCustomerByAccountNumber(string accountNumber)
        {
            foreach (Customer customer in customers)
            {
                if (customer.AccountNumber == accountNumber)
                {
                    return customer;
                }
            }
            return null;
        }

        public Account FindAccountByUserName(string userName)
        {
            return FindAccount(userName);
        }

        public bool UpdateAccountPassword(string userName, string newPassword)
        {
            Account account = FindAccountByUserName(userName);
            if (account == null)
            {
                return false;
            }
            account.Password = newPassword;
            SaveAccounts();
            return true;
        }

        public bool DeleteCustomer(Customer customer)
        {
            bool result = customers.Remove(customer);
            if (result)
            {
                SaveCustomers();
            }
            return result;
        }
    }
}
