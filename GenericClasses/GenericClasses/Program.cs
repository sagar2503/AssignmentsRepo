using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClasses
{
    class Program
    {
        class Check<TypeToCheck>
        {
            public bool Compare(TypeToCheck i, TypeToCheck j)
            {
                if (i.GetType().ToString().ToLower().Contains("string"))
                {
                    return i.Equals(j);
                    
                }
                //if (i.GetType().ToString().Contains("int"))
                //{ 
                //    return ;
                
                //}
                return false;
            }
        
        }

        static void Main(string[] args)
        {
            Check<string> c = new Check<string>();

            if(c.Compare("sagar","sagar"))
                Console.WriteLine("Strings are same");
            else
                Console.WriteLine("Strings are NOT same");
            Console.Read();
        }
    }
}
