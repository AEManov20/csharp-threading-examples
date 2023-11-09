namespace Simultaneous
{
    using System;
    using System.Threading;

    public class ExThread
    {
        public static void thread1()
        {
            for (int z = 0; z < 5; z++)
            {
                Console.WriteLine(z);
            }
        }

        public static void thread2()
        {
            for (int z = 0; z < 5; z++)
            {
                Console.WriteLine(z);
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            // Create and use threads
            Thread a = new Thread(ExThread.thread1);
            Thread b = new Thread(ExThread.thread2);
            a.Start();
            b.Start();
        }
    }
}