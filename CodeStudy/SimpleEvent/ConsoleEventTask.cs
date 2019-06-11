using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.SimpleEvent
{
    public class ConsoleEventTask
    {
        static ConsoleEventTask()
        {
            //CheckReflection();
            //ExecuteRectangle();
            MainEvent();
        }


        public static void MainEvent()
        {
            BoilerInfoLogger filelog = new BoilerInfoLogger("e:\\boiler.txt");
            DelegateBoilerEvent boilerEvent = new DelegateBoilerEvent();
            boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(RecordBoilerInfo.Logger);
            boilerEvent.BoilerEventLog += new DelegateBoilerEvent.BoilerLogHandler(filelog.Logger);
            boilerEvent.LogProcess();
            Console.ReadLine();
            filelog.Close();
        }
         
    }
}
