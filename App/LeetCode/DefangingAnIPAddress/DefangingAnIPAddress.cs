using System.Text.RegularExpressions;

namespace App.LeetCode.DefangingAnIPAddress
{
    public class Solution {
        public string DefangIPaddr(string address)
        {
            Regex pattern = new Regex("[.]");
           return pattern.Replace(address, "[.]");
        }
    }
}