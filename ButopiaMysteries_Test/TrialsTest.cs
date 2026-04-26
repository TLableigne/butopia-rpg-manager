using NUnit.Framework;
using ButopiaMysteries.Logic;
using System.Collections.Generic;

namespace ButopiaMysteries.Tests
{
    [TestFixture]
    public class TrialTests
    {
        [Test]
        public void Cast_Test()
        {
            List<int> roll = Trial.Cast(4);

            Assert.That(roll.Count, Is.EqualTo(4));
            foreach (int diceResult in roll)
            {
                Assert.That(diceResult, Is.GreaterThanOrEqualTo(1));
                Assert.That(diceResult, Is.LessThanOrEqualTo(6));
            }
        }

        [Test]
        public void NumericalResult_Test()
        {
            Assert.That(Trial.NumericResult(null, 3), Is.EqualTo(0));
            Assert.That(Trial.NumericResult(new List<int>(), 3), Is.EqualTo(0));
            Assert.That(Trial.NumericResult(new List<int> { 3, 5, 6 }, 0), Is.EqualTo(0));
            Assert.That(Trial.NumericResult(new List<int> { 1, 4 }, 1), Is.EqualTo(4));
            Assert.That(Trial.NumericResult(new List<int> { 6, 2 }, 3), Is.EqualTo(17)); 
        }

        [Test]
        public void OpenTrial_Test()
        {
            MysterySheet sheet = new MysterySheet("TestChar", Plan.Thinkers, Sphere.Algebra);
            sheet.RandomGeneration(Rules.Fixed); 
            Difficulty resultat = Trial.OpenTrial(sheet, Indicator.Body, Skill.Feat);
            Assert.That((int)resultat, Is.GreaterThanOrEqualTo(0));
        }

        [Test]
        public void ClosedTrial_Test()
        {
            MysterySheet sheet = new MysterySheet("TestChar", Plan.Thinkers, Sphere.Algebra);
            sheet.RandomGeneration(Rules.Fixed);

            bool resultFail = Trial.ClosedTrial(sheet, Indicator.Body, Skill.Feat, Difficulty.Exploit);

            Assert.That(resultFail, Is.False);
            Assert.That(sheet.SanteMentale, Is.EqualTo(19));

            sheet.Skills[Skill.Feat] = 4;

            bool resultSuccess = Trial.ClosedTrial(sheet, Indicator.Body, Skill.Feat, Difficulty.Facile);

            Assert.That(resultSuccess, Is.True);
            Assert.That(sheet.NbVictoirConsecutif, Is.EqualTo(1));
        }
    }
}