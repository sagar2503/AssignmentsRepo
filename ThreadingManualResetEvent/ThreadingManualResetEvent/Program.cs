using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadingUsingSignalling
{
    class Program
    {
        static ManualResetEvent objAuto = new ManualResetEvent(false);
        static void Main(string[] args)
        {
            //Console.WriteLine("Main 1...");

            new Thread(SomeMethod).Start();
            //Console.WriteLine("Main 2...");
            Console.ReadLine();

            objAuto.Set();
            Console.WriteLine("Main ...");

            //Console.ReadLine();
            objAuto.Set();
            Console.ReadLine();
            
        }

        static void SomeMethod()
        {
            Console.WriteLine("Starting 1...");
            // wait 1
            objAuto.WaitOne();
            Console.WriteLine("Ending 1 ...");

            Console.WriteLine("Starting 2...");
            // wait 2
            objAuto.WaitOne();
            Console.WriteLine("Ending 2 ...");

        }
    }
}
