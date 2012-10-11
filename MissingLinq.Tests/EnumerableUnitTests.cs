using System;
using System.Collections.Generic;
using System.Linq;
using MissingLinq;
using NUnit.Framework;

namespace MissingLinq.Tests
{
    [TestFixture]
    public class EnumerableUnitTests
    {
        [Test]
        public void AppendTests()
        {
            IEnumerable<int> expected;
            IEnumerable<int> result = null;

            // Test 1
            result = result.Append(0);
            expected = new int[] { 0 };
            Assert.IsTrue(expected.Matches(result));

            // Test 2
            result = new int[] { 0, 1, 2 }.Append(3);
            expected = new int[] { 0, 1, 2, 3 };
            Assert.IsTrue(expected.Matches(result));

            // Test 3
            result = new int[] { 0, 1, 2, 5, 4, 9, 8, 7 }.Append(6).Append(3);
            expected = new int[] { 0, 1, 2, 5, 4, 9, 8, 7, 6, 3 };
            Assert.IsTrue(expected.Matches(result));

            // Test 4
            result = new int[] { 0, 1, 2, 5, 4, 9, 8, 7 }.Append(6).Append(3).Append(new int[] { 10, 11, 12 });
            expected = new int[] { 0, 1, 2, 5, 4, 9, 8, 7, 6, 3, 10, 11, 12 };
            Assert.IsTrue(expected.Matches(result));

            // Test 5
            result = new int[] { 0, 1, 2, 5, 4, 9, 8, 7 }.Append(6).Append(3).Append(new int[] { 10, 11, 12 }).Append(14).Append(new int[] { 13 });
            expected = new int[] { 0, 1, 2, 5, 4, 9, 8, 7, 6, 3, 10, 11, 12, 14, 13 };
            Assert.IsTrue(expected.Matches(result));
        }

        [Test]
        public void DistinctUntilChangedTests()
        {
            int[] integerSet;
            IEnumerable<int> expected;
            IEnumerable<int> result;

            // Test 1
            integerSet = null;
            try
            {
                integerSet.DistinctUntilChanged();
                Assert.Fail("integerSet was null and should have thrown an exception.");
            }
            catch { }

            // Test 2
            integerSet = new int[] { 0, 1, 2, 3, 4 };
            expected = integerSet;
            result = integerSet.DistinctUntilChanged();
            Assert.IsTrue(expected.Matches(result));

            // Test 3
            integerSet = new int[] { 0, 0, 1, 2, 3, 4 };
            expected = new int[] { 0, 1, 2, 3, 4 };
            result = integerSet.DistinctUntilChanged();
            Assert.IsTrue(expected.Matches(result));

            // Test 4
            integerSet = new int[] { 0, 0, 1, 2, 2, 3, 4 };
            expected = new int[] { 0, 1, 2, 3, 4 };
            result = integerSet.DistinctUntilChanged();
            Assert.IsTrue(expected.Matches(result));

            // Test 5
            integerSet = new int[] { 0, 0, 1, 2, 2, 3, 2, 2, 4 };
            expected = new int[] { 0, 1, 2, 3, 2, 4 };
            result = integerSet.DistinctUntilChanged();
            Assert.IsTrue(expected.Matches(result));

            // Test 5
            integerSet = new int[] { 0, 0, 1, 2, 2, 3, 2, 2, 4, 4, 4, 4, 4, 4, 4, 4, 2 };
            expected = new int[] { 0, 1, 2, 3, 2, 4, 2 };
            result = integerSet.DistinctUntilChanged();
            Assert.IsTrue(expected.Matches(result));
        }
    }
}
