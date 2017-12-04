using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeStudy
{
    public  class CmdConsole
    {
        public CmdConsole()
        {
            //CmdCole();
            //GifChangeTpWibp();
            GifResize();
        }

        /// <summary>
        /// 文献参考 
        /// https://developers.google.com/speed/webp/docs/gif2webp?hl=zh-CN
        /// https://developers.google.com/speed/webp/download?hl=zh-CN
        /// </summary>
        public void GifChangeTpWibp()
        {
            // 输入命令 {.exe执行文件路径} {gif文件物理路径} -o {webp文件生成路径} -mixed
            
            string str = @"D:\Sources\Code\CodeStudy\CodeStudy\gif-resizer\gif2webp.exe D:\temp\1mmeYvG0hvaEg.gif -o D:\temp\1mmeYvG0hvaEg.webp -mixed";

            Process p = new Process();

            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = false;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();


            Console.WriteLine(output);
        }


        /// <summary>
        /// 参考文献 https://github.com/JesseE/gif-resizer
        /// 需要安装node环境 
        /// </summary>
        public void GifResize()
        {
            ///输入命令 node {js调用文件} -s {gif原图地址} -o {gif生成地址} -w {生成gif的宽度（等比缩小）} 
            ///业务需要 缩小gif 生成480 和 200 的两种尺寸 
            ///先判断原图宽度是否大于目标生成的尺寸 小于的话 工具不生成目标图片
            ///业务逻辑 原来的gif图 源地址填充DownUrl字段 200尺寸填充ICON字段 480尺寸填充PreviewUrl字段 没有缩略图填充原图地址
            /// webp原图大小填充 DownUrl2字段 生成两种小预览图webp格式的填充ExtStr1字段 中间以 | 隔开，480在前面，200在后面 没有对应的缩略图 填充原图webp的地址
            string str = @"node D:\Sources\Code\CodeStudy\CodeStudy\gif-resizer\resizeone.js -s D:\temp\3o6Zt9e3I5cNiF4yoU.gif -o D:\temp\3o6Zt9e3I5cNiF4yoU_200.gif -w 200";
            Process p = new Process();

            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = false;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();


        }


        public void CmdCole()
        {
            string str = @"node D:\Sources\Code\CodeStudy\CodeStudy\gif-resizer\main.js";

            Process p = new Process();

            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = false;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(str + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令
            
            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();


            Console.WriteLine(output);
        }
        
    }
}
