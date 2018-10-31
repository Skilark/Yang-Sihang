using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ordertest;

namespace ProgramWinForm
{
    public partial class Form1 : Form
    {


        public Form1()
        {
            InitializeComponent();
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
            //order1.AddOrderDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);

            OrderService os = new OrderService();
            os.AddOrder(order1);
            os.AddOrder(order2);
            os.AddOrder(order3);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        //添加订单
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 addform = new Form2();
            addform.Show();
        }

        //按订单号查询
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        //按商品名查询
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            
        }

        //按订单号查询
        private void button3_Click(object sender, EventArgs e)
        {
            //int number = Int32.Parse(textBox2.Text);
            //List<Order> orders = os.GetById(number);
        }

        //按商品名查询
        private void button4_Click(object sender, EventArgs e)
        {
            string goodsname = textBox3.Text;
            
        }

        //按客户名查询
        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            
        }
        //按客户名查询
        private void button5_Click(object sender, EventArgs e)
        {

            string clientname = textBox4.Text;

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void orderBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        //修改订单
        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.Show();
        }
    }
}
 