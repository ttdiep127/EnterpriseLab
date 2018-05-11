using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CRMV2
{
    internal class CustomerStorage
    {
        public List<Customer> Customers { get; private set; }
        private UIManager _ui;
           
        public CustomerStorage()
        {
            Customers = new List<Customer>();
            _ui = new UIManager();
        }

        /// <summary>
        /// Determine that a customer is not exist in List of customers.
        /// Determine that a email of customer is not exist in List of customers.
        /// </summary>
        /// <param name="customer"></param>
        /// <param name="listOfCustomer"></param>
        /// <returns></returns>
        private bool IsValidCustomer(Customer customer, IEnumerable<Customer> existingCustomers) // Signature
        {
            var isIdDuplicated = existingCustomers.Any(x => x.CustomerID == customer.CustomerID);
            if (isIdDuplicated)
            {
                _ui.ShowMessage(Strings.DuplicateId);
                return false;
            }
            // TODO: Learn about LINQ to optimize the below foreach to have better performance
            var emailsOfCustomer = customer.Addresses.Select(x => x.Email);
            var emailsOfCustomers = existingCustomers.SelectMany(x => x.Addresses.Select(y => y.Email));
            var IsEmailDuplicate = emailsOfCustomer.Intersect(emailsOfCustomers).Any();

            if (IsEmailDuplicate)
            {
                _ui.ShowMessage(Strings.DuplicateEmail);
                return false;
            }

            return true;
        }

        internal bool AddCustomer(Customer newCustomer)
        {
            if (IsValidCustomer(newCustomer, Customers))
            {
                Customers.Add(newCustomer);
                _ui.ShowMessage(Strings.AddSuccessfully);
                return true;
            }

            return false;
        }

        internal void UpdateCustomer(Customer updatedCustomer)
        {
            // Customers: [c1][c2]...[c100]
            // list = Customers.ToList(): [c1][c2]....[c99]
            var customer = Customers.FirstOrDefault(_ => _.CustomerID == updatedCustomer.CustomerID);
            var CustomersNotChosenToEdit = Customers.Where(x => x.CustomerID != updatedCustomer.CustomerID);

            // Edit success when email of update customer is not like any customers in list.
            if (IsValidCustomer(updatedCustomer, CustomersNotChosenToEdit))
            {
                customer.EditTo(updatedCustomer);
            }
        }

        internal void DeleteCustomer(Customer customerDelete)
        {
            // Delete customer was chosen.
            Customers.Remove(customerDelete);
            _ui.ShowMessage(Strings.CustomerWasDeleted);
        }

        internal void ShowCustomerDetail(Customer customerShow)
        {
            _ui.DisplayDetailCustomer(customerShow);
        }
    }
}