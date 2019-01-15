using static System.Console;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _7_0
{
    class C_IC_Discards
    {
        static async Task Main()
        {
            //Tuple deconstruction
            var (_, Min) = B_IC_Tuples.GetRange(new int[] { 3, 1, 28, 30, 78, 54 });
            (IEnumerable<Buyer> AllBuyers, _) = await B_IC_Tuples.GetDashboardData();
            var (_, _, _, pop1, _, pop2) = GetCityInformation("Ktm", 1960, 2010);

            //Object deconstruction
            Person p = new Person("John", "Quincy", "Adams", "Boston", "MA");
            var (fName, lName, city, state) = p;
            var (name, _, cty, _) = p;
            WriteLine($"Hello {fName} {lName} of {city}, {state}!");
        }


        private static (string, double, int, int, int, int) GetCityInformation(string name, int year1, int year2)
        {
            int population1 = 0, population2 = 0;
            double area = 0;

            if (name == "Ktm")
            {
                area = 468.48;
                if (year1 == 1960)
                {
                    population1 = 7781984;
                }
                if (year2 == 2010)
                {
                    population2 = 8175133;
                }
                return (name, area, year1, population1, year2, population2);
            }

            return ("", 0, 0, 0, 0, 0);
        }
    }

    public class Person
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string State { get; set; }

        public Person(string fname, string mname, string lname,
                      string cityName, string stateName)
        {
            FirstName = fname;
            MiddleName = mname;
            LastName = lname;
            City = cityName;
            State = stateName;
        }        

        public void Deconstruct(out string fname, out string lname)
        {
            fname = FirstName;
            lname = LastName;
        }
        public void Deconstruct(out string fname, out string lname,
                                out string city, out string state)
        {
            fname = FirstName;
            lname = LastName;
            city = City;
            state = State;
        }
    }
}

//A discard is a write-only variable whose name is _ (the underscore character); you can assign all of the values that you intend to discard to the single variable. 
//A discard is like an unassigned variable but can't be used in code.

//USAGE
//Tuple and object deconstruction.
//Pattern matching with is and switch.
//Calls to methods with out parameters.
//A standalone _ when no _ is in scope.