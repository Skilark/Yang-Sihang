using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    class Program
    {
        static void Main(string[] args)
        {
            string A = "";
            string B = "";
            Console.Write("Please input a number: ");
            A = Console.ReadLine();
            double a = Double.Parse(A);
            Console.Write("Please input another number: ");
            B = Console.ReadLine();
            double b = Double.Parse(B);
            Console.WriteLine("The product of the numbers is: " + (a * b));
        }
    }
}
