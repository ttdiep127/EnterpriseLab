using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Company
    {
        public List<Customer> ListCustomer;

        public Company()
        {
            ListCustomer = new List<Customer>();
        }

        // Format input data 
        public string FormatStr(string str)
        {
            string resuft = string.Empty ;

            string[] arr = str.Split(' ');

            foreach( var item in arr)
            {
                string s = item.Trim();
                if (s.Length > 0)
                    resuft += " " + s;
            }
            return resuft.TrimStart();
        } 
        public void Action(int chose)
        {
            switch (chose)
            {
                case 1:// add customer
                    Customer customer = new Customer();
                    customer.Init();
                    ListCustomer.Add(customer);
                    Console.WriteLine("Add successful!");
                    break;
                case 2:// edit customer
                    Console.WriteLine("Which Customer Id you want to edit ?");
                    int idEdit = Convert.ToInt16(Console.ReadLine());
                    if (ListCustomer.Exists( x => x.CusId == idEdit)){
                        ListCustomer.FirstOrDefault(x => x.CusId == idEdit).Edit();
                        Console.WriteLine("Edited successful!");
                    }
                    else
                    {
                        Console.WriteLine("Didn't find id!");
                    }
                     
                    break;
                case 3:// show customer
                    Console.WriteLine("Do you want to show all customers? Y/N");
                    var answer = Console.ReadLine();
                    if (answer == "Y" || answer == "y")
                    {
                        ListCustomer.ForEach(x => x.Dislay());
                    }
                    else if ( answer == "N" || answer == "n")
                    {
                        Console.WriteLine("Which Customer Id you want to show ?");
                        int idDisplay = Convert.ToInt16(Console.ReadLine());
                        if (ListCustomer.Exists(x => x.CusId == idDisplay))
                        {
                            int resutf = ListCustomer.FirstOrDefault(x => x.CusId == idDisplay).Dislay();
                            if ( resutf == 0)
                            {
                                Console.WriteLine("Customer was deleted!");
                            } 
                        }
                        else
                        {
                            Console.WriteLine("Didn't find id!");
                        }
                    }
                    break;
                case 4: // delete customer

                    Console.WriteLine("Which Customer Id you want to delete ?");
                    int idDel = Convert.ToInt16(Console.ReadLine());

                    if (ListCustomer.Exists(x => x.CusId == idDel))
                    {
                        ListCustomer.FirstOrDefault(x => x.CusId == idDel).Delete();
                        Console.WriteLine("Deleted succesful1");
                    }
                    else
                    {
                        Console.WriteLine("Didn't find id!");
                    }
                    
                    break;
            }
        }
    }
}
