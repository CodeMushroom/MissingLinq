using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using MissingLinq;

namespace MissingLinq.Tests
{
    [TestFixture]
    public class RangeTests
    {
        [Test]
        [TestCase(1, 10, 55)]
        [TestCase(100, 500, 120300)]
        [TestCase(1, 5000, 12502500)]
        public void TestSumNumberRanges(int start, int end, int expectedSum)
        {
            Assert.AreEqual(expectedSum, start.To(end).Sum());
        }
    }
}
