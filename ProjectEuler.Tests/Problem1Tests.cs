using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace ProjectEuler.Tests
{
    [TestFixture]
    public class Problem1Tests
    {
        private Problem1 _problem1;

        [SetUp]
        public void SetUp()
        {
            _problem1 = new Problem1();
        }
        

        [Test]
        public void AddAllNaturalNumbersBelowOneThousandThatAreMultiplesOf3And5()
        {
            var solution = _problem1.Solve();
            Assert.AreEqual(solution.Result, 233168);

            Console.WriteLine(solution.ToString());
        }

    }
}
