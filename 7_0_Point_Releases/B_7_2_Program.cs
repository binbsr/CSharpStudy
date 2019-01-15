namespace _7_0_Point_Releases
{
    class Program_2
    {
        static void Main(string[] args)
        {
            //Safe efficient code enhancements
            ///-The 'in' modifier on parameters, to specify that an argument is passed by reference but not modified by the called method.
            ///-The 'ref readonly' modifier on method returns, to indicate that a method returns its value by reference but doesn't allow writes to that object.
            ///-The 'readonly struct' declaration, to indicate that a struct is immutable and should be passed as an in parameter to its member methods.
            ///-The 'ref struct' declaration, to indicate that a struct type accesses managed memory directly and must always be stack allocated

            //Non-trailing named arguments

            //Leading underscores in numeric literals
            int binaryValue = 0b_0101_0101;


            //private protected access modifier
            ///member may be accessed by containing class or derived classes that are declared in the same assembly.
            ///While protected internal allows access by derived classes or classes that are in the same assembly, 
            ///private protected limits access to derived types declared in the same assembly.

            int[] arr = new int[10];
            int[] otherArr = new int[10];

            //Conditional ref expressions
            ///conditional expression may produce a ref result instead of a value result
            ///The variable r is a reference to the first value in either arr or otherArr
            ref var r = ref (arr != null ? ref arr[0] : ref otherArr[0]);
        }


    }
}
