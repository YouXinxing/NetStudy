﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy.DependencyLocate
{
    internal sealed class WindowsWindow : IWindow
    {
        public String Description { get; private set; }

        public WindowsWindow()
        {
            this.Description = "Windows风格窗口";
        }

        public String ShowInfo()
        {
            return this.Description;
        }
    }
}
