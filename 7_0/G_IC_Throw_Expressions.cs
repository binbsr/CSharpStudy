using System;

namespace _7_0
{
    class G_IC_Throw_Expressions
    {


        //throw has always been a statement not an expression, there were C# constructs e.g. conditional expressions, 
        //null coalescing expressions, and some lambda expressions where we can not use it.

        //The addition of expression-bodied members adds more locations where throw expressions would be useful
        private string name;
        public string Name
        {
            get => name;
            set => name = value ??
                throw new ArgumentNullException(paramName: nameof(value), message: "New name must not be null");
        }

        private ConfigResource loadedConfig = LoadConfigResourceOrDefault() ??
            throw new InvalidOperationException("Could not load config");

        private static ConfigResource LoadConfigResourceOrDefault()
        {
            return new ConfigResource();
        }
    }

    internal class ConfigResource
    {
    }
}
