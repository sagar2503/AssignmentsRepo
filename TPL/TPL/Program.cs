using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace TPL
{
    class Program
    {
        static void Main(string[] args)
        {
            //Thread o1 = new Thread(Sample);
            //o1.Start();
            //Console.ReadLine();

            Parallel.For(0, 1000000, x => Sample());
            Console.ReadLine();

        }

        private static void Sample()
        {

            string s = string.Empty;
                for(int i=0;i< 1000000;i++)
                {
                    s = s + "sagar";
                }
        }

    }
}
