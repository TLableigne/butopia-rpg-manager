using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// Class for a character sheet.
    /// </summary>
    public class MysterySheet
    {
        private readonly Random random = new();
        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name { get; init; }
        /// <summary>
        /// Mapping: indicators to numeric level.
        /// </summary>
        public Dictionary<Indicator, int> Indicators { get; init; }
        /// <summary>
        /// Mapping: skills to numeric level.
        /// </summary>
        public Dictionary<Skill, int> Skills { get; init; }

        public bool estEnFormation { get; set; }
        /// <summary>
        /// Parametered constructor.
        /// </summary>
        /// <param name="name">The name of the new character.</param>
        public MysterySheet(string name)
        {
            Name = name;
            Indicators = [];
            Skills = [];
            estEnFormation = false;
        }
        /// <summary>
        /// Generate the indicator and skill levels randomly.
        /// </summary>
        /// <param name="rules">The set of rules used for rng (default: full random)</param>
        public void RandomGeneration(Rules rules=Rules.None)
        {
            switch (rules)
            {
                case Rules.None:
                    {
                        Indicators.Add(Indicator.Body, GenRandNum(1, 5));
                        Indicators.Add(Indicator.Mind, GenRandNum(1, 5));
                        Indicators.Add(Indicator.Sense, GenRandNum(1, 5));
                        Indicators.Add(Indicator.Maximum, Math.Max(
                            Math.Max(Indicators[Indicator.Body], Indicators[Indicator.Mind]),
                            Indicators[Indicator.Sense]));
                        foreach (Skill skill in Skill_Operations.AllSkillsSuchAs(_ => true))
                        {
                            Skills.Add(skill, GenRandNum(0, 4));
                        }

                        break;
                    }
                case Rules.Fixed:
                    {
                        Indicators.Add(Indicator.Body, 2);
                        Indicators.Add(Indicator.Mind, 2);
                        Indicators.Add(Indicator.Sense, 2);
                        Indicators.Add(Indicator.Maximum, Math.Max(
                            Math.Max(Indicators[Indicator.Body], Indicators[Indicator.Mind]),
                            Indicators[Indicator.Sense]));
                        foreach (Skill skill in Skill_Operations.AllSkillsSuchAs(_ => true))
                        {
                            Skills.Add(skill,1);
                        }
                        break;
                    }
            }
        }

        private int GenRandNum(int min = 0, int max=6)
        {
            return random.Next(min, max+1);
        }
    }
}