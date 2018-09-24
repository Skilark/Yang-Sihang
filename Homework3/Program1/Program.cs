using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Program1
{
    public abstract class Shape
    {
        private string myShape;

        public Shape(string s)
        {
            Shapes = s;
        }

        public string Shapes                //图形类型
        {
            get
            {
                return myShape;
            }
            set
            {
                myShape = value;
            }
        }

        public abstract double Area         //面积,抽象属性
        {
            get;
        }

        public virtual void Draw()          //绘制，虚方法
        {
            Console.WriteLine("Draw Shape Icon");
        }

        public override string ToString()                                   //覆盖object的虚方法
        {
            return Shapes + "面积 = " + string.Format("{0:F2}", Area);
        }
    }

    //三角形
    public class Triangle : Shape
    {
        private int myBottom;         //底
        private int myHight;          //高
        public Triangle(int bottom,int hight,string shapes) : base(shapes)
        {
            myBottom = bottom;
            myHight = hight;
        }
        public override double Area         //计算面积
        {
            get
            {
                return myBottom * myHight * 1 / 2;
            }
        }
        public override void Draw()         //覆盖绘制方法
        {
            Console.WriteLine("Draw Triangle");
        }
    }

    //圆形
    public class Circle : Shape
    {
        private int myRadius;                //半径
        public Circle(int radius,string shapes) : base(shapes)
        {
            myRadius = radius;
        }
        public override double Area         //计算面积
        {
            get
            {
                return myRadius * myRadius * System.Math.PI;
            }
        }
        public override void Draw()         //覆盖绘制方法
        {
            Console.WriteLine("Draw Circle:" + myRadius);
        }
    }

    //正方形
    public class Square : Shape
    {
        private int mySide;                //半径
        public Square(int side, string shapes) : base(shapes)
        {
            mySide = side;
        }
        public override double Area         //计算面积
        {
            get
            {
                return mySide * mySide;
            }
        }
        public override void Draw()         //覆盖绘制方法
        {
            Console.WriteLine("Draw Square:" + mySide);
        }
    }

    //长方形
    public class Rectangle : Shape
    {
        private int myLength;                //长
        private int myWidth;                 //宽
        public Rectangle(int length,int width, string shapes) : base(shapes)
        {
            myLength = length;
            myWidth = width;
        }
        public override double Area         //计算面积
        {
            get
            {
                return myLength * myWidth;
            }
        }
        public override void Draw()         //覆盖绘制方法
        {
            Console.WriteLine("Draw Rectangle");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Shape[] shapes =
            {
                new Triangle(4,3,"三角形 "),
                new Circle(2, "圆形 "),
                new Square(4, "正方形 "),
                new Rectangle(3, 4, "长方形 ")
            };
            System.Console.WriteLine("使用简单工厂模式创建4个图形：");
            foreach(Shape s in shapes)
            {
                System.Console.WriteLine(s);
            }
        }
    }
}

