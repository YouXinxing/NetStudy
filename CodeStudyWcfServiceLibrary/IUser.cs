using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudyWcfServiceLibrary
{
    [ServiceContract]
    public interface IUser
    {
        [OperationContract]
        string ShowName(string name);
    }
}
