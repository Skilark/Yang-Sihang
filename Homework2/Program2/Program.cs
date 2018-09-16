using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("你要输入的一组整数包含几个数：");            string get = Console.ReadLine();            int number = Int32.Parse(get);            int[] createArray;            createArray = new int[number];            for (int i = 0; i < number; i++)            {                Console.Write("数组的第 " + i + "个元素是：");                string get2 = Console.ReadLine();                int getNumber = Int32.Parse(get2);                createArray[i] = getNumber;            }
            //求整数数组的最大值
            int max = createArray[0];            for (int i = 0; i < number; i++)            {                if (createArray[i] > max) max = createArray[i];            }            Console.WriteLine("整数数组的最大值为：" + max);
            //求整数数组的最小值
            int min = createArray[0];            for (int i = 0; i < number; i++)            {                if (createArray[i] < min) min = createArray[i];            }            Console.WriteLine("整数数组的最小值为：" + min);
            //求整数数组所有元素的平均值和所有元素的和
            int add = 0;            for (int i = 0; i < number; i++)            {                add += createArray[i];            }            double average = add / number;            Console.WriteLine("整数数组所有元素的和为：" + add);            Console.WriteLine("整数数组所有元素的平均值为：" + average);
        }
    }
}
