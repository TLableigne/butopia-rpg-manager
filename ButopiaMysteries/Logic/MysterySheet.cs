using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
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
        public Plan MyPlan { get; init; }
        public Sphere MySphere { get; init; }
        /// <summary>
        /// Mapping: indicators to numeric level.
        /// </summary>
        public Dictionary<Indicator, int> Indicators { get; init; }
        /// <summary>
        /// Mapping: skills to numeric level.
        /// </summary>
        public Dictionary<Skill, int> Skills { get; init; }
        /// <summary>
        /// Parametered constructor.
        /// </summary>
        /// <param name="name">The name of the new character.</param>
        public MysterySheet(string name, Plan plan, Sphere sphere)
        {
            Name = name;
            MyPlan = plan;
            MySphere = sphere;
            Indicators = new Dictionary<Indicator, int>();
            Skills = new Dictionary<Skill, int>();
            Indicators.Add(Indicator.Body, 1);
            Indicators.Add(Indicator.Mind, 1);
            Indicators.Add(Indicator.Sense, 1);
            Indicators.Add(Indicator.Maximum, 1);

        }
        /// <summary>
        /// Generate the indicator and skill levels randomly.
        /// </summary>
        /// <param name="rules">The set of rules used for rng (default: full random)</param>
        public void RandomGeneration(Rules rules = Rules.None)
        {
            Skills.Clear();
            AddSkills(Skill.Feat, Skill.Dodge, Skill.Design, Skill.Synthesis, Skill.Analysis, Skill.Expression, Skill.Survival, Skill.Seduction);

            switch (MyPlan)
            {
                case Plan.Thinkers: AddSkills(Skill.Concentration, Skill.Abstraction, Skill.Visualization, Skill.Modeling); break;
                case Plan.Legates: AddSkills(Skill.Durability, Skill.Perception, Skill.Details, Skill.Memoization); break;
                case Plan.Makers: AddSkills(Skill.Skillfulness, Skill.Architecture, Skill.Organization, Skill.Reification); break;
                case Plan.Integrators: AddSkills(Skill.Proprioception, Skill.Liaison, Skill.Synesthesia, Skill.Compilation); break;
                case Plan.Traders: AddSkills(Skill.Endurance, Skill.Finance, Skill.Expertise, Skill.Communication); break;
            }

            switch (MySphere)
            {
                case Sphere.Algebra: AddSkills(Skill.Junction, Skill.Induction, Skill.Equation, Skill.Functional); break;
                case Sphere.Verb: AddSkills(Skill.Injunction, Skill.Formulation, Skill.Poetics, Skill.Object); break;
                case Sphere.Transition: AddSkills(Skill.Deconstruction, Skill.Anticipation, Skill.Argumentation, Skill.Optimization); break;
                case Sphere.Creation: AddSkills(Skill.Adjustment, Skill.Drafting, Skill.Narration, Skill.Data); break;
                case Sphere.Valorization: AddSkills(Skill.Destruction, Skill.Stewardship, Skill.Conviction, Skill.Testing); break;
            }


            switch (rules)
            {
                case Rules.None:
                    Indicators[Indicator.Body] = GenRandNum(1, 5);
                    Indicators[Indicator.Mind] = GenRandNum(1, 5);
                    Indicators[Indicator.Sense] = GenRandNum(1, 5);

                    foreach (Skill skill in Skills.Keys.ToList())
                    {
                        Skills[skill] = GenRandNum(0, 4);
                    }
                    break;

                case Rules.Fixed:
                    Indicators[Indicator.Body] = 2;
                    Indicators[Indicator.Mind] = 2;
                    Indicators[Indicator.Sense] = 2;

                    foreach (Skill skill in Skills.Keys.ToList())
                    {
                        Skills[skill] = 1;
                    }
                    break;
            }

            Indicators[Indicator.Maximum] = Math.Max(Math.Max(Indicators[Indicator.Body], Indicators[Indicator.Mind]), Indicators[Indicator.Sense]);
        }

        private int GenRandNum(int min = 0, int max=6)
        {
            return random.Next(min, max+1);
        }
        private void AddSkills(params Skill[] skills)
        {
            foreach (Skill s in skills)
            {
                if (!Skills.ContainsKey(s))
                {
                    Skills.Add(s, 0);
                }
            }
        }
    }
}