using NUnit.Framework;
using ButopiaMysteries.Logic;
using System.Collections.Generic;

namespace ButopiaMysteries.Tests
{
    [TestFixture]
    public class BasicLogicTests
    {
        [Test]
        public void SkillPointsAtLevel_Test()
        {
            Assert.That(Skill_Operations.SkillPointsAtLevel(0), Is.EqualTo(0));
            Assert.That(Skill_Operations.SkillPointsAtLevel(3), Is.EqualTo(3));
            Assert.That(Skill_Operations.SkillPointsAtLevel(6), Is.EqualTo(6));
        }

        [Test]
        public void GetMaximumDifficulty_Test()
        {
            Assert.That(Difficulty_Operations.GetMaximumDifficulty(0), Is.EqualTo(Difficulty.None));
            Assert.That(Difficulty_Operations.GetMaximumDifficulty(4), Is.EqualTo(Difficulty.None));
            Assert.That(Difficulty_Operations.GetMaximumDifficulty(5), Is.EqualTo(Difficulty.Trivial));
            Assert.That(Difficulty_Operations.GetMaximumDifficulty(14), Is.EqualTo(Difficulty.Facile));
            Assert.That(Difficulty_Operations.GetMaximumDifficulty(20), Is.EqualTo(Difficulty.Complexe));
            Assert.That(Difficulty_Operations.GetMaximumDifficulty(105), Is.EqualTo(Difficulty.Impossible));
        }
    }
}