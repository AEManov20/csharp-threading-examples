/// <summary>
/// This project demonstrates one of the main applications
/// of parallel programming (that is processing heaps of data).
/// 
/// The program takes a list of data and performs a specified
/// operation on each item in the list. The operation is
/// performed in parallel.
/// 
/// The program is designed to be run from the command line.
/// 
/// The program uses the System.Threading.Thread class.
/// </summary>

using System;
using System.Threading;

namespace ParallelDataProcessor;

/// <summary>
/// This enum represents the operations that can be performed
/// on the data.
/// </summary>
enum DataOperation {
    Add,
    Subtract,
    Multiply,
    Divide
};


/// <summary>
/// This class represents the data that will be processed.
/// </summary>
class Data {
    public int FirstOperand { get; set; }
    public int SecondOperand { get; set; }

    public DataOperation Operation { get; set; }

    public int Perform()
    {
        switch (Operation)
        {
            case DataOperation.Add:
                return FirstOperand + SecondOperand;
            case DataOperation.Subtract:
                return FirstOperand - SecondOperand;
            case DataOperation.Multiply:
                return FirstOperand * SecondOperand;
            case DataOperation.Divide:
                return FirstOperand / SecondOperand;
            default:
                throw new InvalidOperationException();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // If this variable is set to true, the program will
        // execute in parallel. Otherwise, the program will
        // execute sequentially.
        //
        // Use it to compare the speed difference
        bool executeInParallel = false;

        int numThreads = 4;
        int numItems = 10000000;

        // Create a list of data to process.
        List<Data> data = new List<Data>();
        for (int i = 0; i < numItems; i++)
        {
            data.Add(new Data()
            {
                FirstOperand = i,
                SecondOperand = i + 1,
                Operation = DataOperation.Add
            });
        }

        // Split the data into chunks for each thread.
        int chunkSize;

        if (executeInParallel)
            chunkSize = numItems / numThreads; // Divide the data evenly.
        else
            chunkSize = numItems; // All data will be processed by one thread.

        List<List<Data>> chunks = new List<List<Data>>();
        for (int i = 0; i < numItems; i += chunkSize)
        {
            // Get a chunk of data.
            List<Data> chunk = data.GetRange(i, chunkSize);
            chunks.Add(chunk);
        }

        // Create a thread for each chunk of data.
        List<Thread> threads = new List<Thread>();
        foreach (List<Data> chunk in chunks)
        {
            Thread thread = new Thread(() =>
            {
                foreach (Data item in chunk)
                {
                    item.Perform();
                }
            });
            threads.Add(thread);
        }

        // Start each thread.
        foreach (Thread thread in threads)
        {
            thread.Start();
        }

        // Wait for each thread to finish.
        int counter = 0;
        foreach (Thread thread in threads)
        {
            thread.Join();

            Console.WriteLine("Thread {0} finished.", counter);
            counter++;
        }
    }
}
