using System;
using static System.Console;
using static System.String;

namespace _6_0
{
    public class Name_Of
    {
        private static void Main()
        {
            string lastName = Empty;
            if (IsNullOrWhiteSpace(lastName))
                throw new ArgumentException(message: $"Cannot be blank.", paramName: nameof(lastName));

            Write($"You are in {nameof(_6_0.Name_Of.Main)} method now.");
            ReadKey();
        }
    }
}
