using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeekAndArchive
{
    class Program
    {
        static void Main(string[] args)
        {
            //string DirPath = args[1];
            //string FileToSearch = args[0];

            SeekerMethod(args[1], args[0]);

            Console.ReadKey();
        }

        private static void SeekerMethod(string DirPath, string FileToSearch)
        {
            FileInfo fi = new FileInfo(DirPath + "\\");
            DirectoryInfo di = fi.Directory;

            FileSystemInfo[] fsi = di.GetFileSystemInfos();
            
            foreach (FileSystemInfo file in fsi)
            {
                if (File.Exists(file.FullName) && file.Name.Equals(FileToSearch))
                {
                    Console.WriteLine(di + " " + file.Name);
                }
                else if (Directory.Exists(file.FullName))
                {
                    SeekerMethod(file.FullName, FileToSearch);
                }
            }
        }
    }
}
