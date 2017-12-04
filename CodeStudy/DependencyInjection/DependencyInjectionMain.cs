using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.DependencyInjection
{
    public class DependencyInjectionMain
    {
        public DependencyInjectionMain()
        {
            IServiceClass serviceA = new ServiceClassA();
            IServiceClass serviceB = new ServiceClassB();
            ClientClass client = new ClientClass(serviceB);

            client.Set_ServiceImpl(serviceA);
            client.ShowInfo();
            client.Set_ServiceImpl(serviceB);
            client.ShowInfo();
        }
    }
}
