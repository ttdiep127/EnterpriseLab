using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Address :Customer
    {
        private string Place { get; set; }
        private string Email { get; set; }
        private string PhoneNumber { get; set; }

        //Constructor 
        public Address() { }

        public Address(string place, string email, string phoneNumber)
        {
            Place = place;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        public void Init()
        {
            Console.Write("Place: ");
            Place = Console.ReadLine();
            bool isValidEmail = false;
            do
            {
                Console.Write("Email: ");
                string email = FormatStr(Console.ReadLine());
                isValidEmail = IsValidEmail(email);
                if (isValidEmail)
                {
                    Email = email;
                }else
                {
                    Console.WriteLine("Email is incorrect!");
                }

            } while (!isValidEmail);

            bool isValidPhoneNumber = false;
            do
            {
                Console.Write("Phone Number: ");
                string phoneNumber = Console.ReadLine();
                isValidPhoneNumber = IsValidPhoneNumber(ref phoneNumber);
                if (isValidPhoneNumber)
                {
                    PhoneNumber = phoneNumber;
                }
                else
                {
                    Console.WriteLine("Number is correct");
                }

            } while (!isValidPhoneNumber);
            
        }

        public void Display()
        {
            Console.WriteLine("Place: "+ Place);
            Console.WriteLine("Email: "+ Email);
            Console.WriteLine("Phone Number: "+ PhoneNumber);
        }


        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }

        private bool IsValidPhoneNumber(ref string str)
        {
            string phoneNumber = string.Empty;

            string[] arr = str.Split(' ');

            foreach (var item in arr)
            {
                string s = item.Trim();
                phoneNumber += s;
            }
            if (phoneNumber.All(char.IsDigit)&& phoneNumber.Length >= 6 && phoneNumber.Length <= 11)
            {
                return true;
            }
            return false;
            
        }
    }
}
