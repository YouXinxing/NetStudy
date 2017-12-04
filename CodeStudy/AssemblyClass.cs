using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NamespaceRef
{
    //public class AssemblyClass
    //{
    //    public AssemblyClass()
    //    {
           
    //    }
    //}

    class Country
    {
        public string name;
     }

    class Chinese : Country
    {
        public Chinese()
        {
             name = "你好";
         }
     }

    class America : Country
    {
        public America()
       {
            name = "Hello";
         }
     }
}
