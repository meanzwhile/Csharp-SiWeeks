using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.IO;
using System.IO.Compression;
using System.Threading;

namespace SeekAndArchiveReal
{
    class Program
    {
        static List<FileInfo> FoundFiles;
        static List<FileSystemWatcher> watchers;
        static List<DirectoryInfo> archiveDirs;
        
        static void Main(string[] args)
        {
            string fileName = args[0];
            string directoryName = args[1];
            FoundFiles = new List<FileInfo>();
            watchers = new List<FileSystemWatcher>();
            archiveDirs = new List<DirectoryInfo>();

            DirectoryInfo rootDir = new DirectoryInfo(directoryName);
            if (!rootDir.Exists)
            {
                Console.WriteLine("The specified directory doesn't exist");
                return;
            }

            RecursiveSearch(FoundFiles, fileName, rootDir);

            Console.WriteLine("Found {0} files.", FoundFiles.Count);
            foreach (FileInfo fil in FoundFiles)
            {
                Console.WriteLine("{0}", fil.FullName);
            }

            AddFileWatchers(FoundFiles);

            for (int i = 0; i < FoundFiles.Count; i++)
            {
                archiveDirs.Add(Directory.CreateDirectory("archive" + i.ToString()));
            }

            Console.ReadKey();

        }

        static void ArchiveFile(DirectoryInfo archiveDir, FileInfo fileToArchive)
        {
            //FileStream input = fileToArchive.OpenRead();
            //FileStream output = File.Create(archiveDir.FullName + @"\" + fileToArchive.Name + ".gz");
            //GZipStream Compressor = new GZipStream(output, CompressionMode.Compress);
            //int b = input.ReadByte();
            //while (b != -1)
            //{
            //    Compressor.WriteByte((byte)b);
            //    b = input.ReadByte();
            //}
            //Compressor.Close();
            //input.Close();
            //output.Close();

            using (FileStream input = fileToArchive.OpenRead())
            {
                using (FileStream output = File.Create(archiveDir.FullName + @"\" + fileToArchive.Name + ".gz"))
                {
                    using (GZipStream Compressor = new GZipStream(output, CompressionMode.Compress))
                    {
                        int b = input.ReadByte();
                        while (b != -1)
                        {
                            Compressor.WriteByte((byte)b);
                            b = input.ReadByte();
                        }
                    }
                }
            }
        }

        private static void AddFileWatchers(List<FileInfo> FoundFiles)
        {
            foreach (FileInfo file in FoundFiles)
            {
                FileSystemWatcher newWatcher = new FileSystemWatcher(file.DirectoryName, file.Name);
                newWatcher.Changed += new FileSystemEventHandler(WatcherChanged);
                newWatcher.EnableRaisingEvents = true;
                watchers.Add(newWatcher);
            }
        }
        
        static void WatcherChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Changed)
            {
                Thread.Sleep(250);
                Console.WriteLine("{0} has been changed!", e.FullPath);
                FileSystemWatcher senderWatcher = (FileSystemWatcher)sender;
                int index = watchers.IndexOf(senderWatcher, 0);
                ArchiveFile(archiveDirs[index], FoundFiles[index]);
            }
        }

        static void RecursiveSearch(List<FileInfo> foundFiles, string fileName, DirectoryInfo currentDirectory)
        {
            foreach (FileInfo file in currentDirectory.GetFiles())
            {
                if (file.Name == fileName)
                {
                    foundFiles.Add(file);
                }
            }
            foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
            {
                RecursiveSearch(foundFiles, fileName, dir);
            }
        }
    }
}
