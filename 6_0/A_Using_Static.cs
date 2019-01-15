using System;
using static System.Console;
using static System.Math;
using static System.String;


namespace _6_0
{
    public class Using_Static
    {
        public static double Sine { get; private set; }
        public static double Cosine { get; private set; }
        public double PiSquared { get; }

        public Using_Static()
        {
            PiSquared = PI * PI;
        }

        static void Main(string[] angles)
        {
            WriteLine("Hey its me here!");
            WriteLine("We are trying to learn something called static imports!");
            WriteLine("Hope you get the idea!");
            Write("That's it!");

            if (IsNullOrWhiteSpace(angles[0]))
                throw new ArgumentException(message: "First param cannot be blank", paramName: nameof(angles));
            if (IsNullOrWhiteSpace(angles[1]))
                throw new ArgumentException(message: "Second param cannot be blank", paramName: nameof(angles));

            Sine = Sin(Convert.ToDouble(angles[0]));
            Cosine = Cos(Convert.ToDouble(angles[1]));

            ReadKey();
        }        
    }
}


//The static using directive also imports any nested types meaning we don't need qualification for nested types.
