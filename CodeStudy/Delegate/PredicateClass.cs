using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    public  class PredicateClass
    {
        public PredicateClass()
        {
            Point[] points = { new Point(1001, 200),
            new Point(150, 250), new Point(250, 375),
            new Point(275, 395), new Point(2952, 450) };
            Point first = Array.Find(points, ProductGT10);
            Console.WriteLine("Found: X = {0}, Y = {1}", first.X, first.Y);
            Console.ReadKey();
        }
        //使用带有 Array.Find 方法的 Predicate 委托搜索 Point 结构的数组。如果 X 和 Y 字段的乘积大于 100,000，此委托表示的方法 ProductGT10 将返回 true。Find 方法为数组的每个元素调用此委托，在符合测试条件的第一个点处停止。
        private static bool ProductGT10(Point p)
        {
            if (p.X * p.Y > 100000)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public class Point
        {
            public Point(int x,int y)
            {
                X = x;
                Y = y;

            }
            public int X { get; set; }
            public int Y { get; set; }
        }
    }
}
