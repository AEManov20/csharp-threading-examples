namespace ImplementThread
{
    using System;
    using System.Threading;

    public class ExThread
    {
        public void mythread1()
        {
            for (int z = 0; z < 3; z++)
            {
                Console.WriteLine("First Thread");
            }
        }
    }

    // Driver Class
    public class Program
    {

        // Main Method
        public static void Main()
        {
            // object of the class
            ExThread obj = new ExThread();

            // Create and use of Thread
           
            Thread thr = new Thread(new ThreadStart(obj.mythread1));
            thr.Start();
        }
    }

}