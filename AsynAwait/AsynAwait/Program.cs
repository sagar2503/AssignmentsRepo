using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace AsynAwait
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processing file , please wait");
            if (ReadFile())
            {
                Console.WriteLine("Processing complete.......");
            
            }
            Console.ReadLine();
        }

        static bool ReadFile()
        {
            int count;
            using (StreamReader sr = new StreamReader("sampledata.txt"))
            {
                string filecontent = sr.ReadToEnd();
                count = filecontent.Length;
                Thread.Sleep(5000);
            }
                return true;
            
        }
    }
}
