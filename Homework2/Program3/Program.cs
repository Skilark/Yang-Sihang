using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[99];
            for (int i = 0; i < 99; i++)
            {
                array[i] = i + 2;
            }
            Console.Write("2-100以内的素数有：2, 3, 5, 7");
            for (int i = 0; i < 99; i++)
            {
                if (array[i] % 2 != 0 && array[i] % 3 != 0 && array[i] % 5 != 0 && array[i] % 7 != 0)
                {
                    Console.Write(" ," + array[i]);
                }
            }
            Console.WriteLine("");

        }
    }
}
