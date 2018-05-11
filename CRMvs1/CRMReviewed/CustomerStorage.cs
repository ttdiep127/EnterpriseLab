using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMReviewed
{
    internal class CustomerStorage
    {
        public List<Customer> Customers { get; internal set; }
        public CustomerStorage()
        {
            Customers = new List<Customer>();
        }
        
        internal void AddCustomer(Customer customer)
        {
            if (IsValidCustomer(customer,Customers))
            {
                Customers.Add(customer);
                
                Console.WriteLine("Added successfully!");
            }else
            {
                Console.WriteLine("Add unsucceffully!");
            }
                
        }

        private bool IsValidCustomer(Customer customer, List<Customer> listOfCustomer)
        {

            var customers = listOfCustomer.FirstOrDefault(x => x.CustomerID == customer.CustomerID);
            if (customers != null)
            {
                Console.WriteLine("Id is exist!");
                return false;
            }
            foreach (var cus in listOfCustomer)
            {
                foreach (var add in cus.Addresses)
                {
                    foreach (var item in customer.Addresses)
                    {
                        if (item.Email == add.Email)
                        {
                            Console.WriteLine("Email is exist!");
                            return false;
                        }
                    }
                }
            }
            return true;
        }

        internal void DeleteCustomer(Customer customerDelete)
        {
            var customer = Customers.FirstOrDefault(x => x.CustomerID == customerDelete.CustomerID);
            Customers.Remove(customer);
            Console.WriteLine("Customer with id {0} is deleted successfully!", customerDelete.CustomerID);
        }

        internal void UpdateCustomer(Customer updatedCustomer)
        {
            var customer = Customers.FirstOrDefault(x => x.CustomerID == updatedCustomer.CustomerID);

            var listOfCustomerNotEdit = Customers.Where(x => x.CustomerID != updatedCustomer.CustomerID).ToList();

            foreach( var item in listOfCustomerNotEdit)
            {
                item.DisplayDetail();
            }
            if (listOfCustomerNotEdit != null)
            {
                if (IsValidCustomer(updatedCustomer, listOfCustomerNotEdit)){
                    customer.EditTo(updatedCustomer);
                    Console.WriteLine("Edit successfully!");
                }
                else
                {
                    Console.WriteLine("Edit unsuccessfully!");
                }
            }
            else
            {
                customer.EditTo(updatedCustomer);
            }
        }

        internal void ShowCustomerDetail(Customer selectedShow)
        {
            Console.WriteLine(selectedShow.CustomerID);
            var customer = Customers.FirstOrDefault(x => x.CustomerID == selectedShow.CustomerID);
            Console.WriteLine(customer.CustomerID);
            customer.DisplayDetail();
        }

        internal bool IsEmpty()
        {
            return !Customers.Any();
        }
    }
}