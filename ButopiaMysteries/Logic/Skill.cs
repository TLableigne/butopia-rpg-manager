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
        // global
        Feat, Dodge, Design, Synthesis, Analysis, Expression, Survival, Seduction,
        // thinkers
        Concentration, Abstraction, Visualization, Modeling,
        // legates
        Durability, Perception, Details, Memoization,
        // makers
        Skillfulness, Architecture, Organization, Reification,
        // integratos
        Proprioception, Liaison, Synesthesia, Compilation,
        // merchants
        Endurance, Finance, Expertise, Communication,
        // algebra
        Junction, Induction, Equation, Functional,
        // verb
        Injunction, Formulation, Poetics, Object,
        // transition
        Deconstruction, Anticipation, Argumentation, Optimization,
        // creation
        Adjustment, Drafting, Narration, Data,
        // valorization
        Destruction, Stewardship, Conviction, Testing
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
                // common
                Skill.Feat => "Prouesse",
                Skill.Dodge => "Esquive",
                Skill.Design => "Conception",
                Skill.Synthesis => "Synthèse",
                Skill.Analysis => "Analyse",
                Skill.Expression => "Expression",
                Skill.Survival => "Survie",
                Skill.Seduction => "Séduction",
                // plans
                Skill.Concentration => "Concentration",
                Skill.Abstraction => "Abstraction",
                Skill.Visualization => "Visualisation",
                Skill.Modeling => "Modélisation",
                Skill.Durability => "Pérennité",
                Skill.Perception => "Perception",
                Skill.Details => "Détails",
                Skill.Memoization => "Mémoïsation",
                Skill.Skillfulness => "Habileté",
                Skill.Architecture => "Architecture",
                Skill.Organization => "Organisation",
                Skill.Reification => "Réification",
                Skill.Proprioception => "Proprioception",
                Skill.Liaison => "Liaison",
                Skill.Synesthesia => "Synesthésie",
                Skill.Compilation => "Compilation",
                Skill.Endurance => "Endurance",
                Skill.Finance => "Finance",
                Skill.Expertise => "Expertise",
                Skill.Communication => "Communication",
                // spheres
                Skill.Junction => "Jonction",
                Skill.Induction => "Induction",
                Skill.Equation => "Équation",
                Skill.Functional => "Fonctionnel",
                Skill.Injunction => "Injonction",
                Skill.Formulation => "Formulation",
                Skill.Poetics => "Poétique",
                Skill.Object => "Objet",
                Skill.Deconstruction => "Déconstruction",
                Skill.Anticipation => "Anticipation",
                Skill.Argumentation => "Argumentation",
                Skill.Optimization => "Optimisation",
                Skill.Adjustment => "Ajustement",
                Skill.Drafting => "Conception (Sphère)",
                Skill.Narration => "Narration",
                Skill.Data => "Données",
                Skill.Destruction => "Destruction",
                Skill.Stewardship => "Intendance",
                Skill.Conviction => "Conviction",
                Skill.Testing => "Tests",
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
                //body
                Skill.Feat or Skill.Dodge or Skill.Skillfulness or Skill.Proprioception or
                Skill.Endurance or Skill.Junction or Skill.Injunction or Skill.Deconstruction or
                Skill.Adjustment or Skill.Destruction => Indicator.Body,

                // mind
                Skill.Design or Skill.Synthesis or Skill.Concentration or Skill.Abstraction or
                Skill.Visualization or Skill.Modeling or Skill.Induction or Skill.Equation or
                Skill.Formulation or Skill.Drafting => Indicator.Mind,

                // sense
                Skill.Analysis or Skill.Expression or Skill.Perception or Skill.Details or
                Skill.Synesthesia or Skill.Communication or Skill.Poetics or Skill.Anticipation or
                Skill.Narration or Skill.Conviction => Indicator.Sense,
                // maximum
                Skill.Survival or Skill.Seduction or Skill.Durability or Skill.Memoization or
                Skill.Architecture or Skill.Organization or Skill.Reification or Skill.Liaison or
                Skill.Compilation or Skill.Finance or Skill.Expertise or Skill.Functional or
                Skill.Object or Skill.Argumentation or Skill.Optimization or Skill.Data or
                Skill.Stewardship or Skill.Testing => Indicator.Maximum,

                _ => null,
            };
        }

        public static string GetSkillText(int level)
        {
            return level switch
            {
                0 => "Incompétent",
                1 => "Amateur",
                2 => "Apprenti",
                3 => "Compagnon",
                4 => "Maître",
                5 => "Agrégé",
                6 => "Ministre",
                _ => "Inconnu"
            };
        }

        public static int GetSkillValue(string skill)
        {
            return skill switch {
                "Incompétent" => 0,
                "Amateur" => 0,
                "Apprenti" => 5,
                "Compagnon" => 5,
                "Maître" => 10,
                "Agrégé" => 15,
                "Ministre" => 20,
                "Inconnu" => 0
                }; 
        }
        /// <summary>
        /// Gives all skills satisfying a specified condition.
        /// </summary>
        /// <param name="predicate">the predicate to check</param>
        /// <returns>the constructed list</returns>
        public static List<Skill> AllSkillsSuchAs(Predicate<Skill> predicate)
        {
            List<Skill> allSkills = new List<Skill>();
            foreach (Skill s in Enum.GetValues(typeof(Skill)))
            {
                allSkills.Add(s);
            }
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
