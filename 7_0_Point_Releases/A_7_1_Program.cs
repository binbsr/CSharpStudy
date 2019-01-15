using System;
using System.Threading.Tasks;

namespace _7_0_Point_Releases
{
    class Program_1
    {
        //An async main method enables you to use await in your Main method
        static async Task<int> Main(string[] args)
        {
            int.TryParse(args[0], out int waitInMS);
            
            await Task.Delay(waitInMS);
            Console.WriteLine($"Waiting {waitInMS} to print 'Hello World!'");
               
            //Default literal expressions
            Func<string, bool> whereClause = default;

            //Inferred tuple element names
            int count = 5;
            string label = "Colors used in the map";
            var pair = (count, label); // Its same as, var pair = (count: count, label: label);

            return 0;
        }
    }
}
