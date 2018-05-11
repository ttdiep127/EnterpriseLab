using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Customer :Company
    {
        public int CusId { get; set; }
        public string CusName { get; set; }
        public List<Address> ListAddress { get; set; }
        public bool IsDeleted = false; 

        //Constructor 
        public Customer()
        {
            ListAddress = new List<Address>();
        }
        public Customer(int cusId, string cusName, List<Address> listAddress )
        {
            CusId = cusId;
            CusName = cusName;
            ListAddress = listAddress;
        }
        // Base Funtion
        public void Init()
        {
            bool isValid = false;
            do
            {
                Console.Write("Customer Id: ");
                string id = Console.ReadLine().Trim();
                isValid = id.All(Char.IsDigit);
                if (isValid)
                {
                    CusId = Convert.ToInt16(id);
                }
                else
                {
                    Console.WriteLine("Please input a number!");
                }

            } while (!isValid); 
            
           
            

            Console.Write("Customer Name: ");
            CusName = FormatStr(Console.ReadLine());

            bool isContinue = true;
            
            while (isContinue)
            {
                Address address = new Address();
                address.Init();
                ListAddress.Add(address);

                Console.Write("Do you want to add other address? Y/N");
                var answer = Console.ReadLine();

                if (answer == "Y" || answer == "y")
                {
                    isContinue = true;
                }
                else isContinue = false;
               
            }
        }

        

        public int Dislay()
        {
            if (IsDeleted == false)
            {
                Console.WriteLine("Customer Id: " + CusId);
                Console.WriteLine("Customer Name: " + CusName);
                foreach (var address in ListAddress)
                {
                    address.Display();
                }
                return 1;
            }
            else
            {
                return 0;
            }
            
        }

        public void Edit()
        {
            Console.WriteLine("Edit info Customer with Id: " + CusId);
            Console.Write("Customer Name: ");
            CusName = Console.ReadLine();

            foreach (var address in ListAddress)
            {
                address.Init();
            }

        }

        public void Delete()
        {
            IsDeleted = true;
        }
    }
}
