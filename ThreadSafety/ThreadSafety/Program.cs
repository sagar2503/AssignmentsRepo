using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ThreadSafety
{
    class Program
    {

        static Maths ObjM = new Maths();
        static void Main(string[] args)
        {
            Thread t = new Thread(ObjM.Divide);
            t.Start(); // Child

            ObjM.Divide();
            t.Join();
            Console.ReadLine();
        }

    }

    public class Maths
    {
        int Num1;
        int Num2;
        Random o = new Random();
            
        public void Divide()
        {
            
            lock (this)
            {

                for (long l = 0; l < 100000; l++)
                {

                    Num1 = o.Next(1, 2);
                    Num2 = o.Next(1, 2);
                    int result = Num1 / Num2;

                    Num1 = 0;
                    Num2 = 0;



                }
            }
        }
        
    
    }
}
