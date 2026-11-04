using System;
using System.Collections.Generic;

namespace ConsoleProApp
{
    public class CustomerService
    {
        private CustomerRepository repository;

        public CustomerService()
        {
            repository = new CustomerRepository();
            repository.LoadCustomers();
            repository.LoadAccounts();
        }

        public bool RegisterCustomer(Customer customer)
        {
            if (repository.AccountExists(customer.AccountNumber))
            {
                return false;
            }

            repository.AddCustomer(customer);
            repository.SaveCustomers();
            return true;
        }

        public List<Customer> FindCustomersByLastName(string lastName)
        {
            return repository.FindCustomersByLastName(lastName);
        }

        public List<Customer> GetAllCustomers()
        {
            return repository.GetAllCustomers();
        }

        public string Authenticate(string username, string password)
        {
            Account account = repository.FindAccount(username);
            if (account != null && account.Password == password)
            {
                return account.Role;
            }
            return "";
        }

        public Account GetAccount(string username)
        {
            return repository.FindAccount(username);
        }

        public void UpdateCustomer(Customer oldCustomer, Customer newCustomer)
        {
            repository.UpdateCustomer(oldCustomer, newCustomer);
        }

        public void UpdateCustomerBalance(Customer customer, decimal newBalance)
        {
            customer.Balance = newBalance;
            repository.SaveCustomers();
        }

        public bool DeleteCustomer(Customer customer)
        {
            return repository.DeleteCustomer(customer);
        }

        public Customer GetCustomerProfile(string accountNumber)
        {
            return repository.FindCustomerByAccountNumber(accountNumber);
        }

        public bool ChangeAccountPassword(string userName, string currentPassword, string newPassword)
        {
            Account account = repository.FindAccountByUserName(userName);
            if (account == null)
            {
                return false;
            }
            if (account.Password != currentPassword)
            {
                return false;
            }
            return repository.UpdateAccountPassword(userName, newPassword);
        }
    }
}
