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
            Console.Write("请输入一个整数: ");
            string num = Console.ReadLine();
            int number = Int32.Parse(num);
            Console.Write(number + "的素数因子是: ");
            int i = 2;
            while (i < number)
            {
                if (number % i == 0)
                {
                    Console.Write(i + " ");
                    number = number / i;
                }
                else i++;
            }
            Console.WriteLine(number);

        }
    }
}
