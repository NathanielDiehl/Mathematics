using System;
using System.Collections.Generic;


namespace Mathematics
{
    internal class General
    {
        public static int GetNumberOfDigets(double num)
        {
            if(num == 0)
                return 1;
            return (int)Math.Log10(Math.Abs(num))+1;
        }
    }
}