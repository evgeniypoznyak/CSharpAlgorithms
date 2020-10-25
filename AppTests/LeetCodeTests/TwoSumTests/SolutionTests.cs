using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using App.TwoSum;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace AppTests.LeetCodeTests.TwoSumTests
{
    public class SolutionTests
    {
        private readonly ITestOutputHelper output;

        public SolutionTests(ITestOutputHelper output)
        {
            this.output = output;
        }
        
        [Theory]
        [InlineData(new[] {2, 7, 11, 15}, 9, new[] {0, 1})]
        [MemberData(nameof(Test1Data))] // MemberData can be a public static method or property
        [ClassData(typeof(TestDataClass))] // TestDataClass must implement IEnumerable<object[]>
        [CustomDataAttribute] // Any attribute that inherits from DataAttribute
        public void TwoSumTest(int[] nums, int target, int[] expected)
        {
            var actual = (new Solution()).TwoSum(nums, target);
            Assert.Equal(expected, actual);
        }

        // The method can return IEnumerable<object[]>
        // You can use TheoryData to strongly type the result
        public static TheoryData<int[], int, int[]> Test1Data()
        {
            var data = new TheoryData<int[], int, int[]>();
            data.Add(new[] {3, 2, 4}, 6, new[] {1, 2});
            data.Add(new[] {3, 3}, 6, new[] {0, 1});
            return data;
        }

        public class TestDataClass : IEnumerable<object[]>
        {
            public IEnumerator<object[]> GetEnumerator()
            {
                yield return new object[] {new[] {0, 4, 3, 0}, 0, new[] {0, 3}};
            }

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        }

        private class CustomDataAttribute : DataAttribute
        {
            public override IEnumerable<object[]> GetData(MethodInfo testMethod)
            {
                yield return new object[] {new[] {-1, -2, -3, -4, -5}, -8, new[] {2, 4}};
            }
        }
    }
}