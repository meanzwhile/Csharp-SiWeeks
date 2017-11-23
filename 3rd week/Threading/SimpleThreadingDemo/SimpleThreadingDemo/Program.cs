using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SimpleThreadingDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart counter = new ThreadStart(Counting);
            Console.WriteLine("Creating the first child-thread");
            Thread first = new Thread(counter);
            Console.WriteLine("Creating the second child-thread");
            Thread second = new Thread(counter);
            first.Start();
            second.Start();

            first.Join();
            second.Join();
            Console.ReadKey();
        }

        public static void Counting()
        {
            for (int i = 1; i < 10; i++)
            {
                Console.WriteLine("Number {0} | Current thread: {1}", i, Thread.CurrentThread.ManagedThreadId);
                Thread.Sleep(10);
            }
        }
    }
}
