using ButopiaMysteries.Logic;

namespace ButopiaMysteries_Test
{
    public class Tests
    {
        [Test]
        public void MysterySheet_Constructor()
        {
            MysterySheet sheet = new("Test");
            Assert.That(sheet, Is.Not.Null);
            Assert.That(sheet.Name, Is.EqualTo("Test"));
        }
        [Test]
        public void Indicator_Tests()
        {
            Indicator? indicator = Indicator.Body;
            Assert.That(indicator, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(indicator?.Name(), Is.EqualTo("Corps"));
                Assert.That(Indicator_Operations.IndicatorPointsAtLevel(1), Is.EqualTo(2));
                Assert.That(Indicator_Operations.IndicatorPointsAtLevel(2), Is.EqualTo(4));
                Assert.That(Indicator_Operations.IndicatorPointsAtLevel(5), Is.EqualTo(10));
            });
        }
        [Test]
        public void Skill_Tests()
        {
            Skill prouesse = Skill.Feat;

            Assert.AreNotEqual(Skill.None, prouesse);

            Assert.AreEqual("Prouesse", prouesse.Name());
            Assert.AreEqual(Indicator.Body, prouesse.GetIndicator());
            
            Assert.AreEqual(2, Skill_Operations.SkillPointsAtLevel(2));
            Assert.AreEqual(5, Skill_Operations.SkillPointsAtLevel(5));
            Assert.AreEqual(10, Skill_Operations.SkillPointsAtLevel(10));
        }
    }
}