using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.DependencyLocate
{
    internal sealed class MacFactory : IFactory
    {
        public IWindow MakeWindow()
        {
            return new MacWindow();
        }

        public IButton MakeButton()
        {
            return new MacButton();
        }

        public ITextBox MakeTextBox()
        {
            return new MacTextBox();
        }
    }
}
