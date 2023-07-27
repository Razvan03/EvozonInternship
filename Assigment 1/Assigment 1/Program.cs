using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assigment_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
            Console.WriteLine("Razvan");
            
            Console.WriteLine("5 + 3 = " + (5 + 3));
            
            Console.WriteLine("10 / 3 = " + ((double)10 / 3));

            Console.WriteLine("-5 + 8 * 6 = " + (-5 + 8 * 6));

            Console.WriteLine("(55 + 9)%9 = " + ((55 + 9) % 9));

            Console.WriteLine("20 + -3 * 5 / 8 = " + (20 + (double)-3 * 5 / 8));

            Console.WriteLine("5 + 15 / 3 * 2 - 8 % 3 = " + (5 + (double)15 / 3 * 2 - 8 % 3));
            Console.ReadKey();
        }
    }
}
