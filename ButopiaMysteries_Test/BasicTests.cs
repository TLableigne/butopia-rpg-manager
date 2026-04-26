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
    
        [Test]
        public void Name_Test()
        {
            Assert.That(Difficulty.None.Name(), Is.EqualTo("Aucune"));
            Assert.That(Difficulty.Facile.Name(), Is.EqualTo("Facile"));
            Assert.That(Difficulty.Delicat.Name(), Is.EqualTo("Délicat"));
            Assert.That(Difficulty.Impossible.Name(), Is.EqualTo("Impossible"));
        }

        [Test]
        public void MinimumScore_Test()
        {
            Assert.That(Difficulty.None.MinimumScore(), Is.EqualTo(0));
            Assert.That(Difficulty.Trivial.MinimumScore(), Is.EqualTo(5));
            Assert.That(Difficulty.Normal.MinimumScore(), Is.EqualTo(15));
            Assert.That(Difficulty.Impossible.MinimumScore(), Is.EqualTo(100));
        }
        [Test]
        public void LoseDfficulty_Test()
        {
            Assert.That(Difficulty.Normal.LoseDfficulty(1), Is.EqualTo(Difficulty.Facile));
            Assert.That(Difficulty.Exploit.LoseDfficulty(3), Is.EqualTo(Difficulty.Complexe));
            Assert.That(Difficulty.Facile.LoseDfficulty(5), Is.EqualTo(Difficulty.None));
            Assert.That(Difficulty.None.LoseDfficulty(2), Is.EqualTo(Difficulty.None));
        }

        [Test]
        public void Constants_Test()
        {
            Assert.That(Indicator_Operations.MinValue, Is.EqualTo(1));
            Assert.That(Indicator_Operations.MaxValue, Is.EqualTo(7));
            Assert.That(Indicator_Operations.CreationThreshold, Is.EqualTo(5));
            Assert.That(Indicator_Operations.BasicValue, Is.EqualTo(3));
        }

        [Test]
        public void IndicatorPointsAtLevel_Test()
        {
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(0), Is.EqualTo(0));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(1), Is.EqualTo(2));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(3), Is.EqualTo(6));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(5), Is.EqualTo(10));
            Assert.That(Indicator_Operations.IndicatorPointsAtLevel(7), Is.EqualTo(14));
        }
        [Test]
        public void RandomName_Test()
        {
            Roster roster = new Roster();
            string nomGenere = Names.RandomName(roster);
            Assert.That(Names.NameList, Contains.Item(nomGenere));
            MysterySheet perso = new MysterySheet(nomGenere, Plan.Thinkers, Sphere.Algebra);
            roster.Sheets.Add(nomGenere, perso);
            string deuxiemeNom = Names.RandomName(roster);
            Assert.That(deuxiemeNom, Is.Not.EqualTo(nomGenere));
            Assert.That(Names.NameList, Contains.Item(deuxiemeNom));
        }
        [Test]
        public void GetIndicator_Test()
        {
            Assert.That(Skill.Dodge.GetIndicator(), Is.EqualTo(Indicator.Body));
            Assert.That(Skill.Design.GetIndicator(), Is.EqualTo(Indicator.Mind));
            Assert.That(Skill.Analysis.GetIndicator(), Is.EqualTo(Indicator.Sense));
            Assert.That(Skill.Survival.GetIndicator(), Is.EqualTo(Indicator.Maximum));
            Assert.That(Skill.None.GetIndicator(), Is.Null);
        }

        [Test]
        public void GetSkillText_Test()
        {
            Assert.That(Skill_Operations.GetSkillText(0), Is.EqualTo("Incompétent"));
            Assert.That(Skill_Operations.GetSkillText(3), Is.EqualTo("Compagnon"));
            Assert.That(Skill_Operations.GetSkillText(6), Is.EqualTo("Ministre"));
            Assert.That(Skill_Operations.GetSkillText(10), Is.EqualTo("Inconnu"));
        }

        [Test]
        public void GetSkillValue_Test()
        {
            Assert.That(Skill_Operations.GetSkillValue("Incompétent"), Is.EqualTo(0));
            Assert.That(Skill_Operations.GetSkillValue("Apprenti"), Is.EqualTo(5));
            Assert.That(Skill_Operations.GetSkillValue("Ministre"), Is.EqualTo(20));
            Assert.That(Skill_Operations.GetSkillValue("NimporteQuoi"), Is.EqualTo(0)); 
        }
    }
}
