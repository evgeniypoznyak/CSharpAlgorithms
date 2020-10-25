using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using App.LeetCode.ReverseInteger;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace AppTests.LeetCodeTests.ReverseIntegerTests
{
    public class SolutionTests
    {
        private readonly ITestOutputHelper output;

        public SolutionTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Theory]
        [InlineData(123, 321)]              // InlineData works for constant values
        [MemberData(nameof(Test1Data))]    // MemberData can be a public static method or property
        [ClassData(typeof(TestDataClass))] // TestDataClass must implement IEnumerable<object[]>
        [CustomDataAttribute]              // Any attribute that inherits from DataAttribute
        public void TwoSumTest(int num,  int expected)
        {
            var actual = (new Solution()).Reverse(num);
            Assert.Equal(expected, actual);
        }
        
        // The method can return IEnumerable<object[]>
        // You can use TheoryData to strongly type the result
        public static TheoryData<int, int> Test1Data()
        {
            var data = new TheoryData<int, int>();
            data.Add(18, 81);
            data.Add(13, 31);
            return data;
        }

        public class TestDataClass : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] { 45, 54 };
                yield return new object[] { 200, 2 };
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class CustomDataAttribute : DataAttribute
        {
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
            {
                yield return new object[] { 334, 433 };
                yield return new object[] { -123, -321 };
                yield return new object[] { 1534236469, 0 };
                yield return new object[] { -1563847412, 0 };
                yield return new object[] { -2147483412, -2143847412 };
            }
        }
    }
}