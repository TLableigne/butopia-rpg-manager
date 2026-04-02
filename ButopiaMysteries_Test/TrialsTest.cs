using ButopiaMysteries.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries_Test
{
    public class TrialsTest
    {
        [Test]
        public void NumericalResult_Test()
        {
            NumericalResult_TestMethod(null, 2, 0);
            NumericalResult_TestMethod(new List<int>(), 2, 0);
            NumericalResult_TestMethod(new List<int> { 2, 4, 6 }, 0, 0);
            NumericalResult_TestMethod(new List<int> { 2, 4, 6 }, 3, 12);
        }
        private void NumericalResult_TestMethod(List<int> list, int skill=0, int sum = 0)
        {
            if (list == null) // Case: null list
            {
                Assert.That(Trial.NumericResult(list, skill), Is.EqualTo(0));
                return;
            }
            if (list.Count == 0) // Case: empty list
            {
                Assert.That(Trial.NumericResult(list, skill), Is.EqualTo(0));
                return;
            }
            if (skill == 0) // Case: void skill
            {
                Assert.That(Trial.NumericResult(list, skill), Is.EqualTo(0));
                return;
            }
            // Nominal case
            Assert.That(Trial.NumericResult(list, skill), Is.EqualTo(sum));
        }
    }
}