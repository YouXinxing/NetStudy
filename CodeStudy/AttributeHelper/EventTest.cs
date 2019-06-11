using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.AttributeHelper
{
    public class EventTest
    {
        private int value;

        public delegate void NumManipulationHandler();


        public event NumManipulationHandler ChangeNum;
        protected virtual void OnNumChanged()
        {
            if (ChangeNum != null)
            {
                ChangeNum(); /* 事件被触发 */
            }
            else
            {
                Console.WriteLine("event not fire");
                Console.ReadKey(); /* 回车继续 */
            }
        }


        public EventTest()
        {
            int n = 5;
            SetValue(n);
        }


        public void SetValue(int n)
        {
            if (value != n)
            {
                value = n;
                OnNumChanged();
            }
        }
    }
}
