using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
//在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
//提示：需要写Order（订单）、OrderDetails（订单明细），OrderService（订单服务）几个类，订单数据可以保存在OrderService中一个List中。

namespace Program2
{
    public class Order
    {

    }

    public class OrderDetails
    {

        public string Name
        {
            set;get;
        }
        public int Number
        {
            set;get;
        }
        public string Client
        {
            set;get;
        }
        public int Amount
        {
            set; get;
        }
        public double Price
        {
            set; get;
        }
    }

    public class OrderService
    {
        //保存订单数据
        static public List<OrderDetails> list = new List<OrderDetails>();

        //添加订单
        public void AddOrder()
        {

            string name;
            int number;
            string client;
            int amount;
            double price;

            string a = "";
            while (a != "NO")
            {
                //添加订单
                Console.Write("输入商品名称：");
                name = Console.ReadLine();
                Console.Write("输入订单号（如：001）：");
                number = Int32.Parse(Console.ReadLine());
                Console.Write("输入客户名：");
                client = Console.ReadLine();
                Console.Write("输入商品数量：");
                amount = Int32.Parse(Console.ReadLine());
                Console.Write("输入商品价格：");
                price = Double.Parse(Console.ReadLine());

                OrderDetails os = new OrderDetails();

                os.Name = name;
                os.Number = number;
                os.Client = client;
                os.Amount = amount;
                os.Price = price;

                OrderService.list.Add(os);

                Console.WriteLine("是否继续添加订单？YES or NO");
                a = Console.ReadLine();
            }

        }

        //删除订单
        public void DeleteOrder()
        {
            Console.WriteLine("您要删除哪个订单？（请输入订单号）");
            int number = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < list.Count; i++)
            {
                if (list.os.Number == number)
                {
                    list.Remove(list[i]);
                }
            }
        }

        //修改订单
        public void ModifyOrder()
        {
            Console.WriteLine("您要修改哪个订单？（请输入订单号）");
            int number = Int32.Parse(Console.ReadLine());
            for (int i = 0; i < list.Count; i++)
            {
                if (list.os.Number == number)
                {
                    //删除该订单
                    list.Remove(list[i]);

                    string name;
                    string client;
                    int amount;
                    double price;

                    //添加修改后的订单属性
                    Console.Write("输入商品名称：");
                    name = Console.ReadLine();
                    Console.Write("输入客户名：");
                    client = Console.ReadLine();
                    Console.Write("输入商品数量：");
                    amount = Int32.Parse(Console.ReadLine());
                    Console.Write("输入商品价格：");
                    price = Double.Parse(Console.ReadLine());

                    OrderDetails os = new OrderDetails();

                    os.Name = name;
                    os.Client = client;
                    os.Amount = amount;
                    os.Price = price;

                    list[i] = os;
                }
            }

            
        } 

        //查询订单
        public void SearchOrder()
        {
            Console.Write("按订单号查询请输入1；按商品名称查询请输入2；按客户查询请输入3.");
            int choose = Int32.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    {
                        Console.WriteLine("请输入订单号：");
                        int number = Int32.Parse(Console.ReadLine());
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list.os.Number == number)
                            {
                                Console.WriteLine(list[i]);
                            }
                        }    
                        break;
                    }
                case 2:
                    {
                        Console.WriteLine("请输入商品名称：");
                        string name = Console.ReadLine();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list.os.Name == name)
                            {
                                Console.WriteLine(list[i]);
                            }
                        }
                        break;
                    }
                case 3:
                    {
                        Console.WriteLine("请输入客户名称：");
                        string client = Console.ReadLine();
                        for (int i = 0; i < list.Count; i++)
                        {
                            if (list.os.Client == client)
                            {
                                Console.WriteLine(list[i]);
                            }
                        }
                        break;
                    }
            }
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
            OrderService os = new OrderService();
            Console.Write("添加订单请输入1；删除订单请输入2；修改订单请输入3；查询订单请输入4.");
            int choose = Int32.Parse(Console.ReadLine());
            switch (choose)
            {
                case 1:
                    {
                        os.AddOrder();
                        break;
                    }
                case 2:
                    {
                        os.DeleteOrder();
                        break;
                    }
                case 3:
                    {
                        os.ModifyOrder();
                        break;
                    }
                case 4:
                    {
                        os.SearchOrder();
                        break;
                    }
            }
                     
        }
    }
}
