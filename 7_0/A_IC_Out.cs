namespace _7_0
{
    class A_IC_Out
    {
        private int ParseToNumAndPrint()
        {
            string input = "23423";
            if (!int.TryParse(input, out int result))
            {
                return int.MinValue;
            }

           return result;
        }
    }
}


//The most common use for this feature will be the Try pattern. In this pattern, 
//a method returns a bool indicating success or failure and an out variable that provides the result if the method succeeds.

//the declared out variable "leaks" into the outer scope