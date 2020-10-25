using System;

namespace App.LeetCode.ReverseInteger
{
    public class Solution
    {
        public int Reverse(int x)
        {
            var negative = x < 0;

            if (x == 0)
            {
                return 0;
            }

            if (negative)
            {
                x = x * -1;
            }
            
            char[] charArray = x.ToString().ToCharArray();
            Array.Reverse(charArray);
            
            try
            {
                var numVal = Int64.Parse(new string(charArray));
                
                if (numVal > Int32.MaxValue)
                {
                    return 0;
                }

                var result = Int32.Parse(numVal.ToString());

                if (negative)
                {
                    result *= -1;
                }
                
                return result;
            }
            catch (FormatException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}