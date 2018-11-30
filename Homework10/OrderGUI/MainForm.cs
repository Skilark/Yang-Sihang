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

namespace OrderGUI
{
    public partial class MainForm : Form
    {
        OrderService orderService = new OrderService();
        public MainForm()
        {
            InitializeComponent();

            //Customer customer1 = new Customer(1, "Customer1", "13512345678");
            //Customer customer2 = new Customer(2, "Customer2", "15912345678");

            //OrderDetail orderDetails1 = new OrderDetail("1", "apple", 800, 5.59);
            //OrderDetail orderDetails2 = new OrderDetail("2", "eggs", 2, 4.99);
            //// OrderDetail orderDetails3 = new OrderDetail("3", "milk", 1, 69.9);
            //List<OrderDetail> od1 = new List<OrderDetail>();
            //od1.Add(orderDetails1);
            //List<OrderDetail> od2 = new List<OrderDetail>();
            //od1.Add(orderDetails2);
            //Order order1 = new Order("20180728001", customer1, od1);
            //Order order2 = new Order("20180501007", customer2, od2);
            ////order1.AddDetails(new OrderDetail("1", "apple", 800, 5.59));
            ////order2.AddDetails(new OrderDetail("2", "eggs", 2, 4.99));

            //orderService.AddOrder(order1);
            //orderService.AddOrder(order2);

            orderBindingSource.DataSource = orderService.QueryAllOrders();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            queryOrder();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            EditForm editForm = new EditForm(null);
            editForm.ShowDialog();
            queryOrder();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current != null)
            {
                EditForm editForm = new EditForm((Order)orderBindingSource.Current);
                editForm.ShowDialog();
                queryOrder();
            }
            else
            {
                MessageBox.Show("No Order is selected!");
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current != null)
            {
                Order order = (Order)orderBindingSource.Current;
                orderService.RemoveOrder(order.Id);
                queryOrder();
            }
            else
            {
                MessageBox.Show("No Order is selected!");
            }
        }

        private void queryOrder()
        {
            switch (comboBox1.SelectedIndex)
            {

                case 1:
                    orderBindingSource.DataSource =
                      orderService.GetById(textBox1.Text);
                    break;
                case 2:
                    orderBindingSource.DataSource =
                      orderService.QueryByCustomerName(textBox1.Text);
                    break;
                case 3:
                    orderBindingSource.DataSource =
                      orderService.QueryByGoodsName(textBox1.Text);
                    break;
                default:
                    orderBindingSource.DataSource = orderService.QueryAllOrders();
                    break;
            }
            orderBindingSource.ResetBindings(false);
            itemsBindingSource.ResetBindings(false);
        }


    }
}
