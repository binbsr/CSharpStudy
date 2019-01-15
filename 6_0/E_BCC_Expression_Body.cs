using System;
using System.Collections.Generic;

namespace _6_0
{
    public class Expression_Body
    {
        public string FirstName { get; }
        public string LastName { get; }

        //Works for methods and read-only properties
        public override string ToString() => $"{LastName}, {FirstName}";
        public string FullName => $"{FirstName} {LastName}";

        static void Main()
        {
            var x = new Expression_Body();
            x.ToString();
        }
    }
}
