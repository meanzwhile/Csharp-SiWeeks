using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            const string name = "RUNMEONLYONCE";
            Mutex mutex = null;
            while (true)
            {
                try
                {
                    mutex = Mutex.OpenExisting(name);
                    Console.WriteLine("found mutex");
                    mutex.Close();
                    break;
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    mutex = new Mutex(true, name);
                    Console.WriteLine("mutex not found so created one, hahh");
                }
            }

            Console.ReadKey();
        }
    }
}
