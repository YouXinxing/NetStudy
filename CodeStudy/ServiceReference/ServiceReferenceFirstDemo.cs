using CodeStudy.ServiceReferenceFirst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace CodeStudy.ServiceReference
{
    public class ServiceReferenceFirstDemo
    {
        public ServiceReferenceFirstDemo()
        {
            var obj = new ServiceReferenceFirst.FisrtWebServiceImplClient();
            var content = obj.getAddressByPhoneNo("15000815726");
            Console.WriteLine(content);
        }
    }
}
