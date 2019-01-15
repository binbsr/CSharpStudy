using static System.Console;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace _7_0
{
    class F_BCC_More_Expression_Body
    {
        private string label;

        //Allowed on constructors, finalizers, and get and set accessors on properties and indexers
        public string Label
        {
            get => label;
            set => label = value ?? "Default label";
        }
        public F_BCC_More_Expression_Body(string label) => Label = label;

        ~F_BCC_More_Expression_Body() => Write("Finalized!");
    }
}
