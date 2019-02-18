using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VarnDynamic
{

    public class TestRef
    {

        public void TestRefMethod(ref object o)
        {
            o = 2;
        }

        public void TestRefMethod(string o)
        {
            o = "string 2";
        }
        public void TestRefMethod(out string o)
        {
            o = "string 2";
        }

    }

    public class SomeMeths

    {
        public int Add(int x,int y)
        {
        return x+y;
        }
    
    }

    // Extension method statis class
    public static class SomeMoreMaths
    {
        // extendion method which extends SomeMeths class
        public static int Substract(this SomeMeths obj, int x,int y)
        {
        
            return x - y;
        }
    
    }
    class Program
    {
        public static readonly int psrInt = 1;
        //internal static const int abc = 2;

        static Program()
        {
            psrInt = 2;
        }

        static void Main(string[] args)
        {
            // Var vs Dynamics

            //var x = "sting1";
            //Console.WriteLine(x.GetType().ToString());
            //Console.WriteLine(x.Length.ToString());

            //dynamic y = 1;
            //Console.WriteLine(y.GetType().ToString());
            //Console.WriteLine(y.Length.ToString());

            // CONST VS READONLY

            //  psrInt = 3;
            Object o = 1;
            TestRef objTestRef = new TestRef();
            objTestRef.TestRefMethod(ref o);

            //Console.WriteLine(((Int32)o).ToString());

            string s = "main method";
            objTestRef.TestRefMethod(s);
            //Console.WriteLine(s);

            string r = "main method";
            objTestRef.TestRefMethod(out r);
            //Console.WriteLine(r);

            SomeMeths sMaths = new SomeMeths();
            //Console.WriteLine(sMaths.Add(1,2).ToString());
            //Console.WriteLine(sMaths.Substract(1,2).ToString());

            int i = 1;
            dynamic d = i;
            Console.WriteLine(d.GetType().ToString());

            Console.Read();
        }
    }
}
