using System;
using System.Threading;

namespace ThreadingSync1
{
    //---------------------------------------------------------------------------------
    //OPGAVE 1 
    //
    //class Program
    //{
    //    static object _lock = new object();
    //    static int i = 0;
    //    static void Main(string[] args)
    //    {
    //        Thread t1 = new Thread(AddTwo);
    //        Thread t2 = new Thread(SubOne);

    //        t1.Start();
    //        t2.Start();
    //    }

    //    static void AddTwo()
    //    {
    //        while (true)
    //        {
    //            Monitor.Enter(_lock);
    //            i += 2;
    //            Console.WriteLine("{0} - i has been set to = {1}", Thread.CurrentThread.ManagedThreadId, i);
    //            Thread.Sleep(1000);
    //            Monitor.Exit(_lock); 
    //        }
    //    }

    //    static void SubOne()
    //    {
    //        while (true)
    //        {
    //            Monitor.Enter(_lock);
    //            i--;
    //            Console.WriteLine("{0} - i has been set to = {1}", Thread.CurrentThread.ManagedThreadId, i);
    //            Thread.Sleep(1000);
    //            Monitor.Exit(_lock); 
    //        }
    //    }
    //}
    //---------------------------------------------------------------------------------



    //---------------------------------------------------------------------------------
    // OPGAVE 2-3
    //
    class Program
    {
        static object _lock = new object();
        static int count = 0;
        static void Main(string[] args)
        {
            Thread t1 = new Thread(WriteSign);
            Thread t2 = new Thread(WriteSign);

            t1.Start("*");
            t2.Start("#");
        }

        static void WriteSign(object sign)
        {
            string s = sign as string;
            while (true)
            {
                lock (_lock)
                {
                    for (int i = 0; i < 60; i++)
                    {
                        Console.Write(s);
                        count++;
                    }
                    Console.Write(count);
                    Console.WriteLine();
                    Thread.Sleep(1000);
                }   
            }
        }
    }

    //---------------------------------------------------------------------------------
}
