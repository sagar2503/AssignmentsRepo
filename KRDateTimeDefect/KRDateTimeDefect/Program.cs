using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KRDateTimeDefect
{
    class Program
    {
        static void Main(string[] args)
        {
            Testing_MinValue_in_DateTime();
        }


        public static void Testing_MinValue_in_DateTime()
        {
            Action<string> p = Console.WriteLine;

            // This is Now in the current timezone
            var nowOffset = new DateTimeOffset(DateTime.Now);
            p("Current time:");
            p("- current timezone: " + nowOffset);
            p("- UTC equivilent time: " + nowOffset.ToUniversalTime());
            p("");

            // This is the minimum time allowed in the current timezone
            var minOffset = DateTimeOffset.MinValue;
            p("DateTimeOffset.MinValue:");
            p("- current timezone: " + minOffset);
            p("- UTC equivilent time: " + minOffset.ToUniversalTime());
            p("");

            // This is UTC minimum time
            var minValue = DateTime.MinValue;
            p("DateTime.MinValue:");
            p("- current timezone: " + minValue);
            p("- UTC equivilent time: " + minValue.ToUniversalTime());
            p("");
           
            // Converted to the current timezone
            try
            {
                p("Trying to cast DateTime.Min to DateTimeOffset:");

                p(DateTimeOffset.Now.ToString());

                p(minValue.ToString());
                var minDateTimeAsDateTimeOffset = (DateTimeOffset)minValue;
                p("- current timezone: " + minDateTimeAsDateTimeOffset);
                p("- UTC equivilent time: " + minDateTimeAsDateTimeOffset.ToUniversalTime());
              
            }
            catch (Exception ex)
            {
                p("Error: " + ex.Message);
               
            }
            Console.ReadKey();
        }


    }
}
