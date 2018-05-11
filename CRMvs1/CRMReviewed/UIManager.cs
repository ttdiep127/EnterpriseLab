using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMReviewed
{
    internal class UIManager
    {
        public UIManager()
        {
        }

        internal UserAction AskForAction()
        {
            Console.WriteLine("=== MENU ===");
            Console.WriteLine("1. Add a customer");
            Console.WriteLine("2. Edit a customer");
            Console.WriteLine("3. Delete a customer");
            Console.WriteLine("4. View a customer");
            Console.WriteLine("5. Exit program");

            do
            {
                var action = Console.ReadLine();
                if (action == "1")
                    return UserAction.AddCustomer;
                else if (action == "2")
                    return UserAction.EditCustomer;
                else if (action == "3")
                    return UserAction.DeleteCustomer;
                else if (action == "4")
                    return UserAction.ViewCustomer;
                else if (action == "5")
                    return UserAction.Exit;
            }
            while (true);
        }

        internal Customer ModifyACustomer(Customer customer)
        {
            customer.Edit();
            return customer;
        }

        internal Customer SelectCustomer(CustomerStorage storage)
        {
            Customer customer = new Customer();
            customer.InitID();
            var IsExist =  storage.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);
            while (IsExist == null)
            {
                Console.WriteLine("Customer is not exist!");
                customer.InitID();
                IsExist = storage.Customers.FirstOrDefault(x => x.CustomerID == customer.CustomerID);
            }
            customer.GetValue(IsExist);
            return customer;
        }
        

        internal bool ShowCustomers(CustomerStorage storage)
        {
            if (!storage.IsEmpty())
            {
                foreach (var customer in storage.Customers)
                {
                    customer.Display();
                }
                return true;
            }
            else
            {
                Console.WriteLine("List of customer is empty!");
                return false;
            }

        }
        
        internal Customer InputNewCustomer()
        {
            Customer customer = new Customer();
            customer.Init();
            
            return customer;
        }

        internal bool AskShowCustomerDetail()
        {
            Console.Write("Do you want view a customer detail?Y/N: ");
            var answer = Console.ReadLine().Trim();
            if (answer == "Y" || answer == "y")
            {
                return true;
            }
            return false;
        }
        
        //private bool ValidCustomer(Customer customer, List<Customer> storage)
        //{
        //    var customers = storage.Find(x => x.CustomerID == customer.CustomerID);
        //    if (customers != null)
        //    {
        //        return true;
        //    }
        //    return false;
        //}
    }
}