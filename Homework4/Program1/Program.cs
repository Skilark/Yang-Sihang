using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//使用事件机制，模拟实现一个闹钟的定时功能，可以设置闹钟，在闹钟时间到了以后，在控制台显示提示信息

namespace Program1
{

    //定义一个委托，声明事件处理的格式
    public delegate void ClockEventHandler(object sender, EventArgs args);

    //定义事件源
    public class AlarmClock
    {
        int hour, minute, second;

        //声明事件
        public event ClockEventHandler OnStart;

        public AlarmClock(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public void SetTime(int hour, int minute,int second)
        {
            //设置闹钟时间
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        public void Start()
        {
            //触发事件
            EventArgs args = new EventArgs();
            OnStart(this, args);
        }


    }


    class Program
    {
        static void Main(string[] args)
        {
            AlarmClock clock = new AlarmClock(DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
    
            //输入闹钟时间
            Console.Write("Please set Hour: ");
            int hour = Int32.Parse(Console.ReadLine());
            Console.Write("Please set Minute: ");
            int minute = Int32.Parse(Console.ReadLine());
            Console.Write("Please set Second: ");
            int second = Int32.Parse(Console.ReadLine());

            clock.SetTime(hour, minute, second);



            //为clock的SetClock事件添加处理办法
            clock.OnStart += new ClockEventHandler(clock_SetClock);//添加委托实例

            clock.SetTime(hour, minute, second);

            //判断是否到达设定闹钟时间
            bool a = true;
            while (a)
            {
                if(DateTime.Now.Hour==hour && DateTime.Now.Minute == minute && DateTime.Now.Second == second)
                {
                    a = false;
                    clock.Start();
                }
            }


        }

        static void clock_SetClock(object sender, EventArgs args)
        {
            Console.WriteLine("时间到啦！！！");
        }



    }
}
