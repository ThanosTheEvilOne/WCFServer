using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bankaccount
{
    class Program
    {
        public class Account
        {
            public double balance;

            public Account()
            {
                balance = 500.00;
            }

            public double deposit() // talletus
            {
                double NewBalance; // tallennus kohde
                double deposit;

                Console.WriteLine("Please entrer amount to deposit");
                deposit = Double.Parse(Console.ReadLine());
                NewBalance = balance + deposit;

                return NewBalance;
               
            }

            public double withdrawl()
            {
                double NewBalance;
                double withdrawl;

                Console.WriteLine("Please enter amount to withdrawl");
                withdrawl = double.Parse(Console.ReadLine());
                NewBalance = balance - withdrawl;

                return NewBalance;
            
            }

        }
        static void Main(string[] args)
        {
            double NewBalance;
            string balance;
            Account bank = new Account();
            int atm = 1000, a, current, pin = 4040, pin1, pin2;

            Console.WriteLine();
            Console.WriteLine(" ////////////////////////// ");
            Console.WriteLine(" ////////////////////////// ");
            Console.WriteLine("______  Welcome To _________");
            Console.WriteLine(" // Stratton Oakmon Bank // ");
            Console.WriteLine("______ Application's _______");
            Console.WriteLine("____________________________");
            Console.WriteLine("____________________________");


            Console.ReadKey();

            Console.WriteLine("Input pin-code___");
            pin1 = int.Parse(Console.ReadLine());

            if(pin1==pin)
            // Read pin
           
            


            Console.WriteLine("Your current balance is 500.00");
            Console.WriteLine("Press D for deposit or press W for withdrawl");

            balance = Console.ReadLine();

            if (balance == "D")
            {
                NewBalance = bank.deposit(); 
                Console.WriteLine("New Balance is {0}", NewBalance);
            }

            if (balance == "W")
            {
                NewBalance = bank.withdrawl();
                Console.WriteLine("New Balance is {0}", NewBalance);

            }

            Console.ReadKey();
        }
    }
}
