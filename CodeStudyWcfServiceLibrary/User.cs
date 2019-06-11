using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudyWcfServiceLibrary
{
    public class User : IUser
    {
        public string ShowName(string name)
        {
            string wcfName = string.Format("WCF服务，显示姓名：{0}", name);
            return wcfName;
        }
    }
}
