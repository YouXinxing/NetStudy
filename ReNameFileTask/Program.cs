using net91com.Core.Extensions;
using net91com.Core.Util;
using RReNameFileTask;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReNameFileTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("开始执行文件名替换任务！");

            string RanameFilePath = ConfigHelper.GetSetting("RanameFilePath");
            string NeedDeletedPartFileName = ConfigHelper.GetSetting("NeedDeletedPartFileName"); 

            if(RanameFilePath.IsNullOrEmpty() || NeedDeletedPartFileName.IsNullOrEmpty())
            {
                Console.WriteLine("RanameFilePath 或者 NeedDeletedPartFileName 配置文件不能为空！");
                Console.WriteLine("请关闭任务重启！");
                Console.ReadKey();
                System.Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(string.Format("请确认需要替换的文件夹路径：{0}", RanameFilePath));
                Console.WriteLine(string.Format("请确认需要删除的部分文件名：{0}", NeedDeletedPartFileName));
                Console.Write(string.Format("请输入确认（ Y or N）："));
                var deletepart = NeedDeletedPartFileName.Split(',', '，').ToList();
                var key = Console.ReadLine();
                if(key.ToLower().Equals("y"))
                {
                    var filelist = new DirFileHelper().Getfilelsit(RanameFilePath).Distinct().ToList();
                    foreach(var item in filelist)
                    {
                        Console.WriteLine(string.Format("文件夹路径：{0}", item));

                        foreach (var deleteditem in deletepart)
                        {
                            if (item.Contains(deleteditem))
                            {
                                if(!Path.GetFileName(item).Replace(deleteditem, "").IsNullOrEmpty())
                                {
                                    var newname = string.Format(@"{0}\{1}", Path.GetDirectoryName(item), Path.GetFileName(item).Replace(deleteditem, ""));

                                    if (File.Exists(item))
                                    {
                                        if(File.Exists(newname))
                                        {
                                            Console.WriteLine(string.Format("新文件名：{0}已经存在！不予覆盖！", newname));
                                        }
                                        else
                                        {
                                            File.Move(item, newname);
                                            Console.WriteLine(string.Format("旧文件名：{0}替换成功 新文件名：{1}", item, newname));
                                        }

                                       
                                    }
                                    else
                                    {
                                        Console.WriteLine(string.Format("旧文件名：{0}不存在！", item));
                                    }
                                }
                                else
                                {
                                    Console.WriteLine(string.Format("旧文件名：{0}替换失败 因为文件名删除后为空！", item));
                                }
                                
                            }
                        }
                        
                    }
                    Console.WriteLine("所有文件替换成功！请关闭程序！");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.WriteLine("请关闭程序！");
                    Console.ReadKey();
                    System.Environment.Exit(0);
                }

            }



        }
    }
}
