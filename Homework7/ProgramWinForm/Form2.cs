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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //获取订单信息
            int orderId = Int32.Parse(textBox1.Text);
            string goodName = textBox2.Text;
            string clientName = textBox3.Text;
            int goodCount = Int32.Parse(textBox4.Text);
            double goodPrice = Double.Parse(textBox5.Text);

            //添加订单信息
            Customer customer1 = new Customer(1, clientName);
            Goods good1 = new Goods(1, goodName, goodPrice);
            OrderDetail orderDetail1 = new OrderDetail(1, good1, (uint)goodCount);
            Order order1 = new Order((uint)orderId, customer1);

            order1.AddDetails(orderDetail1);

            OrderService os = new OrderService();
            os.AddOrder(order1);

            //数据绑定
            textBox1.DataBindings.Add("Text", order1, "Id");
            textBox3.DataBindings.Add("Text", order1, "Customer");
            textBox2.DataBindings.Add("Text", good1, "Name");
            textBox5.DataBindings.Add("Text", good1, "Price");
            textBox4.DataBindings.Add("Text", orderDetail1, "Quantity");

        }
    }
}
