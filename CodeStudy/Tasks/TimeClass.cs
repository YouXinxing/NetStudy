using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Tasks
{
    class TimeClass
    {
        public TimeClass()
        {
            //定义一个对象
            System.Threading.Timer timer = new System.Threading.Timer(
                new System.Threading.TimerCallback(Say), null,
                0, 1000*60);//这里是以秒计时的
        }
        //这里的参数必须是object开头的
        public void Say(object a)
        {
            Console.WriteLine("你好");
        }
    }

}
