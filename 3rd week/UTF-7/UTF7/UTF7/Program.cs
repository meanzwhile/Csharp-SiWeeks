using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UTF7
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader streamReader = new StreamReader(@"C:\C#\0000\asd.txt"))
            {
                using (StreamWriter streamWriter = new StreamWriter("boot-utf7.txt", false, Encoding.UTF7))
                {
                    streamWriter.WriteLine(streamReader.ReadToEnd());
                }
            }
        }
    }
}
