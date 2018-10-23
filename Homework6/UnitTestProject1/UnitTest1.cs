using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ordertest;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        public List<Order> order = new List<Order>();
        public Dictionary<uint,Order> orderDict = new Dictionary<uint, Order>();

        //测试AddOrder
        [TestMethod]
        public void TestMethod1()
        {

            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            Assert.IsTrue(os.orderDict.Count() == 2);
        }

        //测试RemoveOrder
        [TestMethod]
        public void TestMethod2()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.RemoveOrder(2);
            Assert.IsTrue(os.orderDict.Count() == 1);
        }

        //测试GetById
        [TestMethod]
        public void TestMethod3()
        {
            Order orderget;
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");
            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            orderget = os.GetById(1);
            Assert.AreEqual(orderget, order1);
        }

        //测试QueryByGoodsName   非法的输出数据
        [TestMethod]
        public void TestMethod4()
        {

            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            Goods apple = new Goods(3, "apple", 5.59);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer2);
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);

            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);

            List<Order> orderget = new List<Order>();
            orderget = os.QueryByGoodsName("apple");

            Assert.AreEqual(orderget, order1);
        }

        //测试QueryByCustomerName   非法的输出数据
        [TestMethod]
        public void TestMethod5()
        {
            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            Goods apple = new Goods(3, "apple", 5.59);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer2);
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);

            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);

            List<Order> orderget = new List<Order>();
            orderget = os.QueryByCustomerName("Customer1");

            Assert.AreEqual(orderget, order1);
        }
    }
}
