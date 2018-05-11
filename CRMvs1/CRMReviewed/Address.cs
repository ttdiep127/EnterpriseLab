using System;
using System.Linq;

namespace CRMReviewed
{
    public class Address
    {
        public string Email { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string Place { get; private set; }

        internal void Init()
        {
            Console.Write("Place:");
            Place = EnterPlace(Console.ReadLine());

            Console.Write("Email:");
            Email = EnterEmail(Console.ReadLine());

            Console.Write("Phone Number:");
            PhoneNumber = EnterPhoneNumber(Console.ReadLine());

        }

        private string EnterPlace(string place)
        {
            place = place.Trim();
           while (!IsValidPlace(place))
            {
                Console.Write("Place: ");
                place = Console.ReadLine().Trim();
            }
            return place;
        }

        private bool IsValidPlace(string place)
        {
            if (place == string.Empty)
            {
                Console.WriteLine("Please enter Place!");
                return false;
            }
            return true;
        }

        
        internal void Display()
        {
            Console.WriteLine("Place:"+ Place);
            
            Console.WriteLine("Email:"+ Email);
            
            Console.WriteLine("Phone Number:" + PhoneNumber);
           

        }


        private string EnterPhoneNumber(string str)
        {
            var phoneNumber = str.Trim();
            while (!IsValidNumberPhone(phoneNumber))
            {
                Console.WriteLine("Phone number is invalid!");
                Console.Write("Phone number: ");
                phoneNumber = Console.ReadLine().Trim();
            }
            return phoneNumber;
        }

      

        private bool IsValidNumberPhone(string str)
        {
            //Delete blank
            string phoneNumber = string.Empty;

            string[] arr = str.Split(' ');

            foreach (var item in arr)
            {
                string s = item.Trim();
                phoneNumber += s;
            }
            // Valid Phone Number
            if (phoneNumber.All(char.IsDigit) && phoneNumber.Length >= 6 && phoneNumber.Length <= 11)
            {
                return true;
            }
            return false;
        }

        internal void Edit()
        {
            Console.Write("Old Place: {0} - New Place: ", Place);
            Place = EnterPlace(Console.ReadLine());

            Console.Write("Old Email: {0} - New Email: ", Email);
            Email = EnterEmail(Console.ReadLine());

            Console.Write("Old Phone Number: {0} - New Phone Number: ", PhoneNumber);
            PhoneNumber = EnterPhoneNumber(Console.ReadLine());
        }

        private string EnterEmail(string email)
        {
            email = email.Trim();
            while (!IsValidEmail(email))
            {
                Console.WriteLine("Email is invalid!");
                Console.Write("Email: ");
                email = Console.ReadLine().Trim();
            }
            return email;   
                
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
    }
}