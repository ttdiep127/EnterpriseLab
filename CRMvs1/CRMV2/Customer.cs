using System.Collections.Generic;

namespace CRMV2
{
    internal class Customer
    {
        public uint CustomerID { get; private set; }
        public string CustomerName { get; private set; }
        public List<Address> Addresses { get; private set; }

        public Customer(uint id, string name, List<Address> addresses)
        {
            CustomerID = id;
            CustomerName = name;
            Addresses = addresses;
        }

        internal void EditTo(Customer updatedCustomer)
        {
            CustomerName = updatedCustomer.CustomerName;
            Addresses = updatedCustomer.Addresses;
        }
    }
}