using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// Enum for all skills.
    /// </summary>
    public enum Skill
    {
        None,
        Feat,
        Dodge,
        Design,
        Synthesis,
        Analysis,
        Expression,
        Survival,
        Seduction
    }
    /// <summary>
    /// Companion class for the enum above.
    /// </summary>
    public static class Skill_Operations
    {
        /// <summary>
        /// The Name associated to the skill.
        /// </summary>
        /// <param name="skill">skill to examine</param>
        /// <returns>the name (in French)</returns>
        public static string Name(this Skill skill)
        {
            return skill switch
            {
                Skill.Feat => "Prouesse",
                Skill.Dodge => "Esquive",
                Skill.Design => "Conception",
                Skill.Synthesis => "Synthèse",
                Skill.Analysis => "Analyse",
                Skill.Expression => "Expression",
                Skill.Survival => "Survie",
                Skill.Seduction => "Séduction",
                _ => string.Empty
            };
        }
        /// <summary>
        /// The Indicator associated to the skill.
        /// </summary>
        /// <param name="skill">skill to examine</param>
        /// <returns>the indicator (or null)</returns>

        public static Indicator? GetIndicator(this Skill skill)
        {
            return skill switch
            {
                Skill.Feat => Indicator.Body,
                Skill.Dodge => Indicator.Body,
                Skill.Design => Indicator.Mind,
                Skill.Synthesis => Indicator.Mind,
                Skill.Analysis => Indicator.Sense,
                Skill.Expression => Indicator.Sense,
                Skill.Survival => Indicator.Maximum,
                Skill.Seduction => Indicator.Maximum,
                _ => null,
            };
        }
        /// <summary>
        /// Gives all skills satisfying a specified condition.
        /// </summary>
        /// <param name="predicate">the predicate to check</param>
        /// <returns>the constructed list</returns>
        public static List<Skill> AllSkillsSuchAs(Predicate<Skill> predicate)
        {
            List<Skill> allSkills = [Skill.Feat, Skill.Dodge, Skill.Design, Skill.Synthesis,
                Skill.Analysis, Skill.Expression, Skill.Survival, Skill.Seduction];
            return allSkills.FindAll(predicate);
        }
        /// <summary>
        /// The absolute lower bound for skills.
        /// </summary>
        public static int MinValue { get; } = 0;
        /// <summary>
        /// The absolute upper bound for skills.
        /// </summary>
        public static int MaxValue { get; } = 6;
        /// <summary>
        /// The maximum value at creation for a skill.
        /// </summary>
        public static int CreationThreshold { get; } = 4;
        /// <summary>
        /// The basic value for fixed creation.
        /// </summary>
        public static int BasicValue { get; } = 2;
        /// <summary>
        /// A formula yielding the skill points necessary for a skill level.
        /// </summary>
        /// <param name="level">the target level</param>
        /// <returns>the corresponding skill points</returns>
        public static int SkillPointsAtLevel(int level) => level;
    }
}
