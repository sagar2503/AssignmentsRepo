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
        static AutoResetEvent objAuto = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("Main 1...");
            
            new Thread(SomeMethod).Start();
            Console.WriteLine("Main 2...");
            Console.ReadLine();
            
            objAuto.Set();
            Console.WriteLine("Main 3...");
            
            Console.ReadLine();
            
        }

        static void SomeMethod()
        {
            Console.WriteLine("Starting...");
            objAuto.WaitOne();
            Console.WriteLine("Ending...");
        }
    }
}
