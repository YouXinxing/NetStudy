﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.DependencyLocate
{
    internal sealed class WindowsFactory : IFactory
    {
        public IWindow MakeWindow()
        {
            return new WindowsWindow();
        }

        public IButton MakeButton()
        {
            return new WindowsButton();
        }

        public ITextBox MakeTextBox()
        {
            return new WindowsTextBox();
        }
    }
}
