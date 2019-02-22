using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RefVsOut
{
    class Program
    {
        static void Main(string[] args)
        {
            //https://www.youtube.com/watch?v=lYdcY5zulXA

            int passbyvalue = 10;
            PassByValue(passbyvalue);
            Console.WriteLine("PassByValue: "+ passbyvalue.ToString());

            int passbyref = 10;
            PassByRef(ref passbyref);
            Console.WriteLine("PassByRef: " + passbyref.ToString());

            int outParam ;
            PassAsOutParam(out outParam);
            Console.WriteLine("OutParam: " + outParam.ToString());
            
            Console.ReadLine();

        }

        static void PassByValue(int InsideVar)
        {
            InsideVar = InsideVar + 20;
        }

        static void PassByRef(ref int InsideVar)
        {
            InsideVar = InsideVar + 20;
        }

        static void PassAsOutParam(out int InsideVar)
        {
            InsideVar = 20;
        }
    }
}
