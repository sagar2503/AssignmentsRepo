using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConstVsReadOnly
{
    class Program
    {
        public const int staticconstInt = 10; // compile time
        public static readonly int StaticReadOnlyInt = 20; // runtime const
        public readonly int readonlyint = 30; // runtime const
        
        public Program()
        {
            Console.WriteLine("StaticReadOnlyInt in BEFORE DEFAULT CONSTRUCTOR: " + readonlyint.ToString());

            readonlyint = 100;
            Console.WriteLine("StaticReadOnlyInt in AFTER DEFAULT CONSTRUCTOR: " + readonlyint.ToString());

        }

        static Program()
        {

            Console.WriteLine("StaticReadOnlyInt in BEFORE STATIC CONSTRUCTOR: " + StaticReadOnlyInt.ToString());

            StaticReadOnlyInt = 200;
            Console.WriteLine("StaticReadOnlyInt in AFTER  STATIC CONSTRUCTOR: " + StaticReadOnlyInt.ToString());

        }


        static void Main(string[] args)
        {
            //https://www.youtube.com/watch?v=vNPBWNNlDwM

            //cant assign 
            //constInt = 100;

            //cant
            //StaticReadOnlyInt = 100;

            Console.WriteLine("StaticReadOnlyInt in MAIN : " + StaticReadOnlyInt.ToString());

            // Create object to invoke default constructor
            Program p = new Program();

            Console.ReadLine();
        }
    }
}
