using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.DependencyLocate
{
    internal sealed class WindowsTextBox : ITextBox
    {
        public String Description { get; private set; }

        public WindowsTextBox()
        {
            this.Description = " Windows风格文本";
        }

        public String ShowInfo()
        {
            return this.Description;
        }
    }
}
