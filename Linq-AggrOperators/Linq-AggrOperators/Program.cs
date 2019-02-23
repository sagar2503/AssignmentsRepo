using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linq_AggrOperators
{
    class Program
    {
        static void Main(string[] args)
        {

            //https://www.youtube.com/watch?v=ZPgqJvmzigc

            int[] numbers = {1,2,3,4,5,6,7,8,9,10 };

            string[] countries = { "USA", "INDIA", "UK" };

            int sumofAllNumber = numbers.Sum();

            Console.WriteLine("sumofAllNumber : " + sumofAllNumber.ToString());

            int CountOfAllNumber = numbers.Count();

            Console.WriteLine("CountOfAllNumber : " + CountOfAllNumber.ToString());

            int smallestNr = numbers.Min();

            Console.WriteLine("smallestNr : " + smallestNr.ToString());

            int largestNr = numbers.Max();

            Console.WriteLine("largestNr : " + largestNr.ToString());

            double avgOfALl = numbers.Average();

            Console.WriteLine("avgOfAllNumber : " + avgOfALl.ToString());

            int sumofAllEvenNrs = numbers.Where(x => x % 2 == 0).Sum();

            Console.WriteLine("sumofAllEvenNrs : " + sumofAllEvenNrs.ToString());
            
            int sumofAllOdd = numbers.Where(x => x % 2 != 0).Sum();

            Console.WriteLine("sumofAllOdd : " + sumofAllOdd.ToString());

            
            Console.ReadLine();
        }
    }
}
