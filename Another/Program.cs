using System.Collections.Specialized;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;
using System.Threading;

namespace Another
{
    class Program
    {
        static void Main()
        {
            // Create a new thread and start it
            Thread thread = new Thread(new ThreadStart(Worker));
            thread.Start();

            // Do some work in the main thread
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Main thread: {0}", i);
                Thread.Sleep(100);
            }

            // Wait for the worker thread to finish
            thread.Join();
        }
        static void Worker()
        {
            // Do some work in the worker thread
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Worker thread: {0}", i);
                Thread.Sleep(100);
            }
        }

    }

}