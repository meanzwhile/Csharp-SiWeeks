using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback wait = new WaitCallback(ShowMyText);

            ThreadPool.QueueUserWorkItem(wait, "blabla");
            ThreadPool.QueueUserWorkItem(wait, "egyketto");
            ThreadPool.QueueUserWorkItem(wait, "haromnegy");
            ThreadPool.QueueUserWorkItem(wait, "villamos");
            ThreadPool.QueueUserWorkItem(wait, "csillagos");

            Console.ReadKey();
        }

        static private void ShowMyText(object state)
        {
            string someText = (string)state;

            Console.WriteLine("State -> " + someText + " Thread ID -> " + Thread.CurrentThread.ManagedThreadId);
        }
    }
}
