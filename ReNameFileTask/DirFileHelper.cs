using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace RReNameFileTask
{
    public class DirFileHelper
    {
        public List<string> filelsit = new List<string>();

        public List<string> Getfilelsit(string directory)
        {
            getAllFiles(directory);
            return filelsit;
        }
        #region 
        public void getAllFiles(string directory) //获取指定的目录中的所有文件（包括文件夹）
        {
            getFiles(directory);//获取指定的目录中的所有文件（不包括文件夹）
            getDirectory(directory);//获取指定的目录中的所有目录（文件夹）
        }

        public List<string> getFiles(string directory) //获取指定的目录中的所有文件（不包括文件夹）
        {
            string[] path = System.IO.Directory.GetFiles(directory);
            for (int i = 0; i < path.Length; i++)
                filelsit.Add(path[i]);
            return filelsit;
        }

        public void getDirectory(string directory) //获取指定的目录中的所有目录（文件夹）
        {
            string[] directorys = System.IO.Directory.GetDirectories(directory);
            if (directorys.Length <= 0) //如果该目录总没有其他文件夹
                return;
            else
            {
                for (int i = 0; i < directorys.Length; i++)
                    getAllFiles(directorys[i]);
            }
        }
        #endregion


        /// <summary>
        /// 拷贝文件夹
        /// </summary>
        /// <param name="srcdir"></param>
        /// <param name="desdir"></param>
        public static void CopyDirectory(string srcdir, string desdir)
        {
            string folderName = srcdir.Substring(srcdir.LastIndexOf("\\") + 1);

            string desfolderdir = desdir + "\\" + folderName;

            if (desdir.LastIndexOf("\\") == (desdir.Length - 1))
            {
                desfolderdir = desdir + folderName;
            }
            string[] filenames = Directory.GetFileSystemEntries(srcdir);

            foreach (string file in filenames)// 遍历所有的文件和目录
            {
                if (Directory.Exists(file))// 先当作目录处理如果存在这个目录就递归Copy该目录下面的文件
                {

                    string currentdir = desfolderdir + "\\" + file.Substring(file.LastIndexOf("\\") + 1);
                    if (!Directory.Exists(currentdir))
                    {
                        Directory.CreateDirectory(currentdir);
                    }

                    CopyDirectory(file, desfolderdir);
                }

                else // 否则直接copy文件
                {
                    string srcfileName = file.Substring(file.LastIndexOf("\\") + 1);

                    srcfileName = desfolderdir + "\\" + srcfileName;


                    if (!Directory.Exists(desfolderdir))
                    {
                        Directory.CreateDirectory(desfolderdir);
                    }


                    File.Copy(file, srcfileName);
                }
            }//foreach 
        }//function end 
    }
}
