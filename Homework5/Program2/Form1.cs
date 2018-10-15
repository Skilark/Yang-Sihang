using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Program2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string[] colors = { "金色", "棕色", "绿色" };                       //添加颜色选择
            for (int i = 0; i < colors.Length; i++)
            {
                this.listBox1.Items.Add(colors[i]);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(10, 200, 310, 100, -Math.PI / 2);
        }

        private Graphics graphics;
        //double th1 = 30 * Math.PI / 180;           //右树杈的角度为30°
        //double th2 = 60 * Math.PI / 180;           //左树杈的角度为20°
        //double per1 = 0.6;                         //右树杈每个分支长度为上一个分支的0.6倍
        //double per2 = 0.7;                         //右树杈每个分支长度为上一个分支的0.7倍

        // n 代表每个分叉上分支数目（包括主干）；x0和y0代表树根部坐标（锚点在左上角）；leng表示初始树枝的长度
        void drawCayleyTree(int n, double x0, double y0, double leng, double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);                            //分叉点，x不变，修改y
            double y1 = y0 + leng * Math.Sin(th);
            double y2 = y0 + leng * 0.7 * Math.Sin(th);

            //颜色
            string color1 = listBox1.SelectedItem.ToString();
            if (color1 == "金色")
            {
                drawLine(x0, y0, x1, y1);
                drawLine(x0, y0, x1, y2);
            }
            if (color1 == "棕色")
            {
                drawLine1(x0, y0, x1, y1);
                drawLine1(x0, y0, x1, y2);
            }
            if (color1 == "绿色")
            {
                drawLine2(x0, y0, x1, y1);
                drawLine2(x0, y0, x1, y2);
            }

            changeRightAngle();
            changeLeftAngle();
            changeRightLength();
            changeLeftLength();

            double th1 = changeRightAngle() * Math.PI / 180;
            double th2 = changeLeftAngle() * Math.PI / 180;

            drawCayleyTree(n - 1, x1, y2, changeRightLength() * leng, th + th1);           //递归 画右边分支
            drawCayleyTree(n - 1, x1, y1, changeLeftLength() * leng, th - th2);           //递归 画左边分支
        }

        //画不同颜色的树
        void drawLine(double x0, double y0, double x1, double y1)
        {
            float width = float.Parse(textBox5.Text);
            Pen myPen = new Pen(Color.Gold, width);
            graphics.DrawLine(myPen, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        void drawLine1(double x0, double y0, double x1, double y1)
        {
            float width = float.Parse(textBox5.Text);
            Pen myPen = new Pen(Color.Brown, width);
            graphics.DrawLine(myPen, (int)x0, (int)y0, (int)x1, (int)y1);
        }
        void drawLine2(double x0, double y0, double x1, double y1)
        {
            float width = float.Parse(textBox5.Text);
            Pen myPen = new Pen(Color.Green, width);
            graphics.DrawLine(myPen, (int)x0, (int)y0, (int)x1, (int)y1);
        }


        private void textBox1_TextChanged(object sender, EventArgs e)              //用来修改右分支角度
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)              //用来修改左分支角度
        {

        }
        double changeRightAngle()
        {
            string angleRightString = textBox1.Text;
            double angleRight = Double.Parse(angleRightString);
            return angleRight;
        }
        double changeLeftAngle()
        {
            string angleLeftString = textBox2.Text;
            double angleLeft = Double.Parse(angleLeftString);
            return angleLeft;
        }


        private void textBox3_TextChanged(object sender, EventArgs e)              //用来修改右分支长度
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)              //用来修改左分支长度
        {

        }
        double changeRightLength()
        {
            string lengthRightString = textBox3.Text;
            double lengthRight = Double.Parse(lengthRightString);
            return lengthRight;
        }
        double changeLeftLength()
        {
            string lengthLeftString = textBox4.Text;
            double lengthLeft = Double.Parse(lengthLeftString);
            return lengthLeft;
        }


        private void textBox5_TextChanged(object sender, EventArgs e)              //用来修改树宽
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)     //用来选择颜色
        {

        }
    }
}
