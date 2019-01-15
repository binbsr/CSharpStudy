using static System.Console;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _7_0
{
    class B_IC_Tuples
    {
        static async Task Main()
        {           
            //Scenario1
            var letters = ("a", "b");
            (string Alpha, string Beta) namedLetters = ("a", "b");
            var firstLetters = (Alpha: "a", Beta: "b");
            Write($"{letters.Item1} {letters.Item2}, {namedLetters.Alpha} {namedLetters.Beta}, {firstLetters.Alpha} {firstLetters.Beta}");

            //Scenario2
            var (Max, Min) = GetRange(new int[] { 3, 1, 28, 30, 78, 54 } );

            //Scenario3
            (IEnumerable<Buyer> AllBuyers, IEnumerable<Product> AllProducts) = await GetDashboardData();
        }

        public static (int Max, int Min) GetRange(IEnumerable<int> numbers)
        {
            int min = int.MaxValue;
            int max = int.MinValue;
            foreach (var n in numbers)
            {
                min = (n < min) ? n : min;
                max = (n > max) ? n : max;
            }
            return (max, min);
        }

        public static async Task<(IEnumerable<Buyer> BuyersList, IEnumerable<Product> ProductList)> GetDashboardData()
        {
            var buyers = await Task.FromResult(new List<Buyer>()); //Service/Repo that fetches all buyers
            var products = await Task.FromResult(new List<Product>()); //Service/Repo that fetches all products

            return (buyers, products);
        }
    }

    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }

    }

    public class Buyer
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

//unpackage the members of a tuple - deconstruction
