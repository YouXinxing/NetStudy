using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    class ForeachTest: IEnumerable
    {
        private string[] elements;  //装载字符串的数组  
        private int ctr = 0;  //数组的下标计数器  

        /// <summary>  
        /// 初始化的字符串  
        /// </summary>  
        /// <param name="initialStrings"></param>  
        ForeachTest(params string[] initialStrings)
        {
            //为字符串分配内存空间  
            elements = new String[8];
            //复制传递给构造方法的字符串  
            foreach (string s in initialStrings)
            {
                elements[ctr++] = s;
            }
        }

        /// <summary>  
        ///  构造函数  
        /// </summary>  
        /// <param name="source">初始化的字符串</param>  
        /// <param name="delimiters">分隔符，可以是一个或多个字符分隔</param>  
        ForeachTest(string initialStrings, char[] delimiters)
        {
            elements = initialStrings.Split(delimiters);
        }

        //实现接口中得方法  
        public IEnumerator GetEnumerator()
        {
            return new ForeachTestEnumerator(this);
        }

        private class ForeachTestEnumerator : IEnumerator
        {
            private int position = -1;
            private ForeachTest t;
            public ForeachTestEnumerator(ForeachTest t)
            {
                this.t = t;
            }

            #region 实现接口  

            public object Current
            {
                get
                {
                    return t.elements[position];
                }
            }

            public bool MoveNext()
            {
                if (position < t.elements.Length - 1)
                {
                    position++;
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public void Reset()
            {
                position = -1;
            }

            #endregion
        }
        //static void Main(string[] args)
        //{
        //    // ForeachTest f = new ForeachTest("This is a sample sentence.", new char[] { ' ', '-' });  
        //    ForeachTest f = new ForeachTest("This", "is", "a", "sample", "sentence.");
        //    foreach (string item in f)
        //    {
        //        System.Console.WriteLine(item);
        //    }
        //    Console.ReadKey();
        //}
    }
}
