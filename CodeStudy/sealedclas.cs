
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    public class sealedclas
    {
        class A
        {
            public virtual void F()
            {
                Console.WriteLine("A.F");
            }
            public virtual void G()
            {
                Console.WriteLine("A.G");
            }
        }
        class B : A
        {
            public sealed override void F()
            {
                Console.WriteLine("B.F");
            }
            public override void G()
            {
                Console.WriteLine("B.G");
            }
        }
        class C : B
        {
            public override void G()
            {
                Console.WriteLine("C.G");
            }
        }
        static sealedclas()
        {
            new A().F();
            new A().G();
            new B().F();
            new B().G();

            new C().F();

            new C().G();
            Console.ReadLine();
        }
    }
}
