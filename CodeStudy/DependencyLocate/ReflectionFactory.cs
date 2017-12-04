using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace CodeStudy.DependencyLocate
{
    internal static class ReflectionFactory
    {
        private static String _windowType;
        private static String _buttonType;
        private static String _textBoxType;

        static ReflectionFactory()
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load("Config.xml");
            XmlNode xmlNode = xmlDoc.ChildNodes[1];

            _windowType = xmlNode.ChildNodes[0].InnerText;
            _buttonType = xmlNode.ChildNodes[1].InnerText;
            _textBoxType = xmlNode.ChildNodes[2].InnerText;
        }

        public static IWindow MakeWindow()
        {
            //Assembly.Load("命名空间").CreateInstance("命名空间.子文件名." + _windowType) as IWindow;
            IWindow iIWindow = Assembly.Load("CodeStudy").CreateInstance("CodeStudy.DependencyLocate." + _windowType) as IWindow;
            return iIWindow;
        }

        public static IButton MakeButton()
        {
            return Assembly.Load("CodeStudy").CreateInstance("CodeStudy.DependencyLocate." + _buttonType) as IButton;
        }

        public static ITextBox MakeTextBox()
        {
            return Assembly.Load("CodeStudy").CreateInstance("CodeStudy.DependencyLocate." + _textBoxType) as ITextBox;
        }
    }
}
