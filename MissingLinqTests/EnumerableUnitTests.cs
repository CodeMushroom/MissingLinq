using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MissingLinq;

namespace MissingLinqTests
{
    [TestClass]
    public class EnumerableUnitTests
    {
        [TestMethod]
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
