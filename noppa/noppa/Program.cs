using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace noppa
{
    class Program
    {
        static void Main(string[] args)
        {
            int noppa1;
            int noppa2;
            int sum = 0;
            Random rand1 = new Random(); // Satunnais kehittäjä
            Console.WriteLine("Let's heitetään noppaa! ");


            for (int i = 1; i < 6; i++)
            {
                noppa1 = rand1.Next(1, 7);
                noppa2 = rand1.Next(1, 7);

                Console.WriteLine();

                Console.WriteLine("Noppa1 heitetty summa on " + noppa1);
                sum = sum + (noppa1 + noppa2);
                Console.WriteLine("noppa2 heitetty summa on " + noppa2);



            }

            Console.WriteLine("Yhteissumma on " + sum);
            Console.WriteLine("Pres any key to continue ");

            Console.ReadKey();
        }
    }
}
