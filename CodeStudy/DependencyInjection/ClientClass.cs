using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.DependencyInjection
{
    internal class ClientClass
    {
        private IServiceClass _serviceImpl;

        /// <summary>
        /// Setter注入
        /// </summary>
        /// <param name="serviceImpl"></param>
        public void Set_ServiceImpl(IServiceClass serviceImpl)
        {
            this._serviceImpl = serviceImpl;
        }

        public void ShowInfo()
        {
            Console.WriteLine(_serviceImpl.ServiceInfo());
        }

        //// 构造注入
        /// <summary>
        /// 唯一的变化就是构造函数取代了Set_ServiceImpl方法
        /// </summary>
        /// <param name="serviceImpl"></param>
        public ClientClass(IServiceClass serviceImpl)
        {
            this._serviceImpl = serviceImpl;
        }

     
    }
}
