using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMReviewed
{
    public class Customer
    {
        public uint CustomerID { get; private set; }
        public string CustomerName { get; private set; }
        public List<Address> Addresses { get; private set; }

        public Customer()
        {
            Addresses = new List<Address>();
        }

        public Customer(string name, List<Address> addresses)
        {
            CustomerName = name;
            Addresses = addresses;
        }

        internal void Init()
        {
            Console.WriteLine("Fill customer infomation:");
            Console.Write("Customer ID: ");
            CustomerID = EnterID(Console.ReadLine());

            Console.Write("Customer Name: ");
            CustomerName = EnterName(Console.ReadLine());

            Console.WriteLine("Add Address: ");
            AddAddresses();
        }

        private uint EnterID(string id)
        {
            id = id.Trim();
            while ((!IsValidID(id)))
            {
                Console.Write("Customer ID: ");
                id = Console.ReadLine();
            }
            return uint.Parse(id);
        }

        private bool IsValidID(string id)
        {
            if (id == string.Empty)
            {
                Console.WriteLine("Can not blank!");
                return false;
            }
            if (id.Length > 10)
            {
                Console.WriteLine("Id is too long!");
                return false;
            }
            if (!id.All(Char.IsDigit))
            {
                Console.WriteLine("Please enter a number!");
                return false;
            }
            return id.All(Char.IsDigit);
        }

        internal void GetValue(Customer ortherCustomer)
        {
            CustomerID = ortherCustomer.CustomerID;
            CustomerName = ortherCustomer.CustomerName;
            Addresses = ortherCustomer.Addresses;
        }

        internal void Edit()
        {
            //Console.Write("Old ID: {0} - New ID: ", CustomerID);
            //CustomerID = EnterID(Console.ReadLine());
            if (DoContinue("Do you want to edit name?"))
            {
                Console.Write("Old Name: {0} - New Name: ", CustomerName);
                CustomerName = EnterName(Console.ReadLine());
            }
            
            Console.WriteLine("Edit Adreess: ");
            EditAddress();
            
        }

        internal void EditTo(Customer updatedCustomer)
        {
            CustomerName = updatedCustomer.CustomerName;
            Addresses = updatedCustomer.Addresses;
        }

        private void EditAddress()
        {
            
            if (DoContinue("Edit list of addrees?"))
            {
                var deleteCustomerList = new List<string>();
                foreach (var address in Addresses)
                {
                    Console.WriteLine("Place: " + address.Place);
                    if(DoContinue("Do you want to delete this address?"))
                    {
                        deleteCustomerList.Add(address.Email);
                    }
                    else
                    {
                        if (DoContinue("Edit this address?"))
                        {
                            address.Edit();
                        }
                    }
                }
                foreach( var email in deleteCustomerList)
                {
                    Addresses.RemoveAll(x => x.Email == email);
                }                
            }
            if(DoContinue("Do you want to add new address?"))
            {
                AddAddresses();
            }
        }

        internal void Display()
        {
            Console.WriteLine("Id: {0} - Name: {1}", CustomerID, CustomerName);
        }

        internal void InitID()
        {
            Console.Write("Customer ID: ");
            CustomerID = EnterID(Console.ReadLine());
        }

        private string EnterName(string name)
        {
            name = name.Trim();
            while (!IsValidName(name))
            {
                Console.Write("Customer Name: ");
                name = Console.ReadLine().Trim();
            }
            return name;
        }

        private bool IsValidName(string name)
        {
            if (name == string.Empty)
            {
                Console.WriteLine("Please enter Name!");
                return false;
            }
            if (name.Length > 50)
            {
                Console.WriteLine("Name is too long!");
                return false;
            }

            return true;
        }

        internal void DisplayDetail()
        {
            Console.WriteLine("ID: "+ CustomerID);
            Console.WriteLine("Name: " + CustomerName);
            foreach( var item in Addresses)
            {
                item.Display();
            } 
        }

        private void AddAddresses()
        {
            
            var address = new Address();
            address.Init();
            Addresses.Add(address);
            while(DoContinue("Do you want add new address?"))
            {
                address = new Address();
                address.Init();
                Addresses.Add(address);
            }
        }

        private bool DoContinue(string str)
        {
            Console.Write("{0}Y/N: ", str);
            var answer = Console.ReadLine();
            if (answer == "y" || answer == "Y")
            {
                return true;
            }
            return false;
        }
    }
}