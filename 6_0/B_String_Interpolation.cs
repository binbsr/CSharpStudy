using System;
using System.Globalization;
using static System.Globalization.CultureInfo;
using static System.Console;

namespace _6_0
{
    public class String_Interpolation
    {
        static void Main()
        {
            //Scenario1.1
            string name = "Bishnu Rawal";
            bool isMarried = false;
            string newsOfaDay = $"Tax status of {name} is {(isMarried ? " married.": " unmarried.")}";
            Write(newsOfaDay);

            //Scenario1.2
            WriteLine($"|{"Left",-7}|{"Right",7}|");

            const int FieldWidthRightAligned = 20;
            WriteLine($"{Math.PI,FieldWidthRightAligned} - default formatting of the pi number");
            WriteLine($"{Math.PI,FieldWidthRightAligned:F3} - display only three decimal digits of the pi number");

            //Scenario2
            Product product = new Product
            {
                Name = "Water Filter",
                Acronym = "WF",
                Price = 2350.45
            };

            Write($"Product 1: {product.ProductDescFormatted}, {product.DiscountFormatted}");

            //Scenario3
            FormattableString str = $"Product desc is {product.ProductDescFormatted}";
            var gradeStr = str.ToString(new CultureInfo("de-DE"));

            //Scenario4
            var cultures = new CultureInfo[]
            {
                GetCultureInfo("en-US"),
                GetCultureInfo("en-GB"),
                GetCultureInfo("nl-NL"),
                InvariantCulture
            };

            var date = DateTime.Now;
            var number = 31_415_926.536;
            FormattableString message = $"{date,20}{number,20:N3}";
            foreach (var culture in cultures)
            {
                var cultureSpecificMessage = message.ToString(culture);
                WriteLine($"{culture.Name,-10}{cultureSpecificMessage}");
            }

            ReadKey();
        }
    }

    public class Product
    {
        public string Name { get; set; }
        public string Acronym { get; set; }
        public double Price { get; set; }
        public bool HasDiscount { get; } = true;
        public string ProductDescFormatted => $"{Acronym}, {Name}, Price = {Price:F2}";
        public string DiscountFormatted => $"Discount = {(HasDiscount ? GetDiscount(this) : double.NaN):F2}";

        private double GetDiscount(Product product) => product.Price * 0.1;
    }
}


//{<interpolatedExpression>[,<alignment>][:<formatString>]}
//To include a brace, "{" or "}", in the text produced by an interpolated string, use two braces, "{{" or "}}".