using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.Unity
{
    class urlTest
    {
        public urlTest()
        {

            InitTask7();
            Console.ReadLine();
        }

        public void InitTask7()
        {
            Uri url = new Uri("http://pic.ifjing.com/rbpiczy/rbpiczy/sj91/upload/user/2017/05/09/41fa04212ba842d28693e17262dfadf5.jpeg");

            var temp = Path.GetFileNameWithoutExtension(url.AbsolutePath);
            var temp2 = Path.GetDirectoryName(url.AbsolutePath);
            Console.ReadLine();
        }
       
    }
}
