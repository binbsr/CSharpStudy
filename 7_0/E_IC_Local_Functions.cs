using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _7_0
{
    class E_IC_Local_Functions
    {  
        public static IEnumerable<char> AlphabetSubset(char start, char end)
        {
            if (start < 'a' || start > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(start), message: "start must be a letter");
            if (end < 'a' || end > 'z')
                throw new ArgumentOutOfRangeException(paramName: nameof(end), message: "end must be a letter");
            if (end <= start)
                throw new ArgumentException($"{nameof(end)} must be greater than {nameof(start)}");

            return AlphabetSubsetImplementation();

            IEnumerable<char> AlphabetSubsetImplementation()
            {
                for (char c = start; c < end; c++)
                    yield return c;
            }
        }

        public Task<string> PerformLongRunningWork(string address, int index, string name)
        {
            if (string.IsNullOrWhiteSpace(address))
                throw new ArgumentException(message: "An address is required", paramName: nameof(address));
            if (index < 0)
                throw new ArgumentOutOfRangeException(paramName: nameof(index), message: "The index must be non-negative");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException(message: "You must supply a name", paramName: nameof(name));

            return longRunningWorkImplementation();

            async Task<string> longRunningWorkImplementation()
            {
                var firstResult = await FirstWork(address);
                var secondResult = await SecondStep(index, name);
                return $"The results are {firstResult} and {secondResult}. Enjoy.";
            }
        }

        private Task<string> SecondStep(int index, string name)
        {
            Task.Delay(100);
            return Task.FromResult($"Used {index} and {name}");
        }

        private Task<string> FirstWork(string address)
        {
            Task.Delay(100);
            return Task.FromResult($"Used {address}");
        }


        //Lambda expressions and local functions
        //While local functions may seem redundant to lambda expressions, they actually serve different purposes and have different uses.
        public static int LocalFunctionFactorial(int n)
        {
            return nthFactorial(n);

            int nthFactorial(int number) => (number < 2) ?
                1 : number * nthFactorial(number - 1);
        }
        public static int LambdaFactorial(int n)
        {
            Func<int, int> nthFactorial = default(Func<int, int>);

            nthFactorial = (number) => (number < 2) ?
                1 : number * nthFactorial(number - 1);

            return nthFactorial(n);
        }

        //The local functions have names. The lambda expressions are anonymous methods that are assigned to variables that are Func or Action types.
        //Local functions have different rules for definite assignment than lambda expressions
        //Compiler can perform static analysis that enables local functions to definitely assign captured variables in the enclosing scope.
        //local functions can avoid heap allocations that are always necessary for lambda expressions
        //local functions can be implemented as iterators, using the yield return syntax to produce a sequence of values. The yield return statement is not allowed in lambda expressions.
    }
}

//Local functions enable us to declare methods inside the context of another method. 
//This makes it easier for readers of the class to see that the local method is only called from the context in which is it declared.
//There are two very common use cases for local functions: public iterator methods and public async methods. 

