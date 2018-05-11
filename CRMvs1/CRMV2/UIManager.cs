using System;
using System.Collections.Generic;
using System.Linq;

namespace CRMV2
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
                Console.Write("Your choose: ");
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
            Console.WriteLine("Edit customer:");

            var newName = EnterNewName(customer.CustomerName);
            var newAddresses = ModifyAddresses(customer.Addresses);

            return new Customer(customer.CustomerID, newName, newAddresses);
        }

        private List<Address> ModifyAddresses(List<Address> addresses)
        {
            var newAddresses = new List<Address>();

            if (AskDoOrNot(Strings.AskToEditAddresses))
            {
                // Each address can be deleted, be modified or not.
                foreach (var address in addresses)
                {
                    Console.WriteLine("Place: " + address.Place);
                    if (!AskDoOrNot(Strings.AskToDeleteAddress))
                    {
                        if (AskDoOrNot(Strings.AskToEditAddress))
                        {
                            newAddresses.Add(ModifyAddress(address));
                        }
                        else
                        {
                            newAddresses.Add(address);
                        }
                    }
                    else
                    {
                        newAddresses.Add(address);
                    }
                }
                while (AskDoOrNot(Strings.AskToAddNewAddress))
                {
                    newAddresses.Add(EnterAddress());
                }
            }
            else
            {
                newAddresses = addresses;
            }

            return newAddresses;
        }

        internal void DisplayDetailCustomer(Customer customer)
        {
            // Display basic informations of a customer.
            DisplayCustomer(customer);

            // Display address informations of a customer.
            foreach (var address in customer.Addresses)
            {
                DisplayAddress(address);
            }
        }

        private void DisplayAddress(Address address)
        {
            Console.WriteLine("Place:{0}\t\t\t - Email: {1}\t\t\t - Phone Number: {2}\t\t\t", address.Place, address.Email, address.PhoneNumber);
        }

        internal bool AskShowCustomerDetail()
        {
            if (AskDoOrNot(Strings.AskToViewCustomerDetail))
            {
                return true;
            }

            return false;
        }

        private Address ModifyAddress(Address address)
        {
            Console.Write("Old Place: {0} - ", address.Place);
            var place = EnterPlace();

            Console.Write("Old Email: {0} - ", address.Email);
            var email = EnterEmail();

            Console.Write("Old Phone: {0} - ", address.PhoneNumber);
            var phoneNumber = EnterPhoneNumber();

            return new Address(place, email, phoneNumber);
        }

        private string EnterNewName(string oldName)
        {
            Console.Write("Old Name:{0} - ", oldName);

            return EnterName();
        }

        internal Customer SelectCustomer(CustomerStorage storage)
        {
            // Enter ID want to select.
            var id = EnterID();

            // Find Customer in List of Customer when customer ID = ID was selected.
            var customer = storage.Customers.FirstOrDefault(x => x.CustomerID == id);

            // Sure that Customer is exist.
            while (customer == null)
            {
                Console.WriteLine("Customer is not exist!");
                id = EnterID();
                customer = storage.Customers.FirstOrDefault(x => x.CustomerID == id);
            }

            return customer;
        }

        internal bool ShowCustomers(CustomerStorage storage)
        {
            if (storage.Customers.Any())
            {
                foreach (var customer in storage.Customers)
                {
                    DisplayCustomer(customer);
                }
                return true;
            }
            Console.WriteLine("List of customer is empty!");

            return false;
        }

        private void DisplayCustomer(Customer customer)
        {
            Console.WriteLine("ID: {0}\t - Name: {1}\t", customer.CustomerID, customer.CustomerName);
        }

        internal void ShowMessage(string str)
        {
            Console.WriteLine(str);
        }

        internal Customer InputNewCustomer()
        {
            var id = EnterID();
            var name = EnterName();
            var addresses = EnterAddresses();

            return new Customer(id, name, addresses);
        }

        private List<Address> EnterAddresses()
        {
            var addresses = new List<Address>();
            do
            {
                var address = EnterAddress();
                addresses.Add(address);
            } while (AskDoOrNot(Strings.AskToAddNewAddress));

            return addresses;
        }

        private bool AskDoOrNot(string str)
        {
            Console.Write(str + "Y/N: ");
            string answer = Console.ReadLine();
            if (answer == "N" || answer == "n")
            {
                return false;
            }

            return true;
        }

        private Address EnterAddress()
        {
            var place = EnterPlace();
            var email = EnterEmail();
            var phoneNumber = EnterPhoneNumber();

            return new Address(place, email, phoneNumber);
        }

        private string EnterPhoneNumber()
        {
            var phoneNumber = string.Empty;
            do
            {
                Console.Write("Number Phone: ");
                phoneNumber = Console.ReadLine();
            } while (!InputValidation.ValidatePhoneNumber(phoneNumber));

            return phoneNumber;
        }

        private string EnterEmail()
        {
            var email = string.Empty;
            do
            {
                Console.Write("Email: ");
                email = Console.ReadLine();
            } while (!InputValidation.ValidateEmail(email));

            return email;
        }

        private string EnterPlace()
        {
            var place = string.Empty;
            do
            {
                Console.Write("Place: ");
                place = Console.ReadLine();
            }
            while (!InputValidation.ValidatePlace(place));

            return place;
        }

        private string EnterName()
        {
            var name = string.Empty;
            do
            {
                Console.Write("Customer Name: ");
                name = Console.ReadLine();
            }
            while (!InputValidation.ValidateName(name));

            return name;
        }

        private uint EnterID()
        {
            var id = string.Empty;
            do
            {
                Console.Write("Customer ID: ");
                id = Console.ReadLine();
            }
            while (!InputValidation.ValidateID(id));

            return uint.Parse(id);
        }
    }
}