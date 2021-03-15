using System.Collections.Generic;

namespace App.TwoSum
{
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            if (nums.Length == 0)
            {
                return new int[] { };
            }
            
            for (int i = 0; i < nums.Length; i++)
            {
                for (int j = i + 1; j < nums.Length; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        return new[] {i, j};
                    }
                }
            }
            
            return new int[] { };
            
            // var numAndIndex = new Dictionary<int, int>();
            // for(int i = 0; i < nums.Length; i++)
            // {
            //     var curNumber = nums[i];
            //     var numberA = target - curNumber;
            //
            //     if (numAndIndex.ContainsKey(numberA))
            //     {
            //         return new int[] {numAndIndex[numberA], i};
            //     }
            //
            //     numAndIndex[curNumber] = i;
            // }
            // return null;
        }
    }
}