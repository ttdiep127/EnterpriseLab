using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRM
{
    class Program
    {
        static void Main(string[] args)
        {
            Company company = new Company();
            int isContinue = 0;
            do
            {
                int choose = Menu();
                if (choose > 0 && choose < 5)
                {
                    company.Action(choose);
                    Console.WriteLine("Continue? Y/N:");
                    var answer = Console.ReadLine();
                    if (answer == "Y" || answer == "y")
                    {
                        isContinue = 1;
                    }
                    else isContinue = 0;
                }
                if (choose == 5) isContinue = 0;
            } while (isContinue == 1);
           
            //Console.ReadLine();
            
        }
        static int Menu()
        {
            int resuft;
            Console.Write("-----------------------MENU-------------------\n"+
                "(1) Create Customer\n" +
                "(2) Edit Customer\n" +
                "(3) Show Customer\n" +
                "(4) Delete Customer\n" +
                "(5) Exit\n" +
                "Enter your choose:");
            resuft = Convert.ToInt16(Console.ReadLine());
            if (resuft>0 && resuft<6) return resuft;
            return 5;
        }
        
    }
}
