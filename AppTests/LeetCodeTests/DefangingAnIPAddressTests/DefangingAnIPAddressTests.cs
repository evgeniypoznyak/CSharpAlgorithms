using App.LeetCode.DefangingAnIPAddress;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace AppTests.LeetCodeTests.DefangingAnIPAddressTests
{
    public class DefangingAnIpAddressTests
    {
        private readonly ITestOutputHelper output;
        
        [Theory] 
        [MemberData(nameof(TestData))]
        public void DefangIPaddrTest(string num,  string expected)
        {
            var actual = new Solution().DefangIPaddr(num);
            Assert.Equal(expected, actual);
        } 
        
        // The method can return IEnumerable<object[]>
        // You can use TheoryData to strongly type the result
        public static TheoryData<string, string> TestData()
        {
            var data = new TheoryData<string, string>
            {
                {"1.1.1.1", "1[.]1[.]1[.]1"},
                {"255.100.50.0", "255[.]100[.]50[.]0"}
            };
            return data;
        }
    }
}