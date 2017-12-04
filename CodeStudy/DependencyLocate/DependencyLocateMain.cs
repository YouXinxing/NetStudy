using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.DependencyLocate
{
    public class DependencyLocateMain
    {
        public DependencyLocateMain()
        {

            IWindow window = ReflectionFactory.MakeWindow();

            //IFactory factory = FactoryContainer.factory;
            //IWindow window = factory.MakeWindow();
            Console.WriteLine("创建 " + window.ShowInfo());
            //IButton button = factory.MakeButton();
            //Console.WriteLine("创建 " + button.ShowInfo());
            ////ITextBox textBox = factory.MakeTextBox();
            //Console.WriteLine("创建 " + textBox.ShowInfo());

            Console.ReadLine();
        }
    }
}
