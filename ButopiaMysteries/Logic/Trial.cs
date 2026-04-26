using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// A class stub for trials - dice rolls
    /// </summary>
    public static class Trial
    {
        /// <summary>
        /// The random number generator used for dice rolls.
        /// </summary>
        private static readonly Random random = new Random();

        /// <summary>
        /// Calculates the final numeric score of a trial based on the dice rolled and the character's skill level.
        /// Applies specific face-value modifications depending on the skill tier.
        /// </summary>
        /// <param name="listDé">The list of dice roll results.</param>
        /// <param name="skill">The numeric level of the skill used.</param>
        /// <returns>The total calculated score including the base modifier.</returns>
        public static int NumericResult(List<int>? listDé, int skill)
        {
            if (skill == 0 || listDé == null || listDé.Count == 0)
            {
                return 0;
            }

            int result = 0;
            foreach (int item in listDé)
            {
                int valeurDe = item;
                switch (skill)
                {
                    case 1:
                        if (valeurDe == 1)
                        {
                            valeurDe = 0;
                        }
                        break;
                    case 3:
                        if (valeurDe == 6)
                        {
                            valeurDe = 10;
                        }
                        break;
                    case 4:
                        if (valeurDe == 5 || valeurDe == 6)
                        {
                            valeurDe = 10;
                        }
                        break;
                    case 5:
                        if (valeurDe >= 4)
                        {
                            valeurDe = 10;
                        }
                        break;
                    case 6:
                        if (valeurDe >= 4)
                        {
                            valeurDe = 20;
                        }
                        break;
                }
                result += valeurDe;
            }

            return result;
        }

        /// <summary>
        /// Simulates rolling a specified number of 6-sided dice.
        /// </summary>
        /// <param name="nbDé">The number of dice to roll.</param>
        /// <returns>A list containing the result of each die rolled.</returns>
        public static List<int> Cast(int nbDé)
        {
            List<int> results = new List<int>();

            for (int i = 0; i < nbDé; i++)
            {
                results.Add(random.Next(1, 7));
            }

            return results;
        }

        /// <summary>
        /// Executes an open trial where the goal is to achieve the highest possible difficulty level.
        /// Applies mental health and external penalties to the final result.
        /// </summary>
        /// <param name="character">The character performing the trial.</param>
        /// <param name="indicator">The indicator defining the number of dice to roll.</param>
        /// <param name="skill">The skill defining the modifiers and score calculation.</param>
        /// <param name="malus">An optional penalty applied to the final difficulty level (default is 0).</param>
        /// <returns>The maximum difficulty level achieved by the character.</returns>
        public static Difficulty OpenTrial(MysterySheet character, Indicator indicator, Skill skill, int malus = 0)
        {
            int nbDé = character.Indicators[indicator];
            int skillLevel = character.Skills[skill];
            List<int> resDé = Cast(nbDé);
            int totalScore = NumericResult(resDé, skillLevel);

            Difficulty diffFinale = Difficulty_Operations.GetMaximumDifficulty(totalScore);

            int malusTotal = malus;
            if (character.SanteMentale <= 0)
            {
                malusTotal += 2;
            }

            int indexFinal = (int)diffFinale - malusTotal;
            if (indexFinal < 0)
            {
                indexFinal = 0;
            }

            return (Difficulty)indexFinal;
        }

        /// <summary>
        /// Executes a closed trial against a specific target difficulty.
        /// Handles automatic successes/failures based on skill level and updates the character's mental health accordingly.
        /// </summary>
        /// <param name="character">The character performing the trial.</param>
        /// <param name="indicator">The indicator used for the dice pool.</param>
        /// <param name="skill">The skill used for the trial.</param>
        /// <param name="difficultéVisée">The target difficulty to beat.</param>
        /// <param name="malus">An optional penalty applied to the roll (default is 0).</param>
        /// <returns>True if the trial is successful, false otherwise.</returns>
        public static bool ClosedTrial(MysterySheet character, Indicator indicator, Skill skill, Difficulty difficultéVisée, int malus = 0)
        {
            if (difficultéVisée == Difficulty.None)
            {
                return true;
            }

            int skillLevel = character.Skills[skill];
            bool? resultatAutomatique = null; // Permet de savoir si on a un résultat direct grâce au niveau

            // --- 1. Vérification des réussites et échecs automatiques (Issu de la Version 1) ---
            switch (skillLevel)
            {
                case 0:
                    resultatAutomatique = false;
                    break;
                case 1:
                    if (difficultéVisée >= Difficulty.Exploit) resultatAutomatique = false;
                    break;
                case 2:
                    if (difficultéVisée <= Difficulty.Trivial) resultatAutomatique = true;
                    if (difficultéVisée >= Difficulty.Surhumain) resultatAutomatique = false;
                    break;
                case 3:
                    if (difficultéVisée <= Difficulty.Trivial) resultatAutomatique = true;
                    if (difficultéVisée >= Difficulty.Impossible) resultatAutomatique = false;
                    break;
                case 4:
                    if (difficultéVisée <= Difficulty.Facile) resultatAutomatique = true;
                    break;
                case 5:
                    if (difficultéVisée <= Difficulty.Normal) resultatAutomatique = true;
                    break;
                case 6:
                    if (difficultéVisée <= Difficulty.Complexe) resultatAutomatique = true;
                    break;
            }

            bool res;

            // --- 2. Lancement des dés uniquement si on n'a pas eu de résultat automatique ---
            if (resultatAutomatique.HasValue)
            {
                res = resultatAutomatique.Value;
            }
            else
            {
                Difficulty difficultéObtenue = OpenTrial(character, indicator, skill, malus);
                res = difficultéObtenue.MinimumScore() >= difficultéVisée.MinimumScore();
            }

            // --- 3. Conséquences sur la Santé Mentale (Issu de la Version 2) ---
            if (res == true)
            {
                character.NbVictoirConsecutif++;
                if (character.NbVictoirConsecutif >= 2 && character.SanteMentale < character.SanteMentaleMax)
                {
                    character.SanteMentale++;
                    character.NbVictoirConsecutif = 0;
                }
            }
            else
            {
                character.SanteMentale--;
                character.NbVictoirConsecutif = 0;
                if (character.SanteMentale < 0)
                {
                    character.SanteMentale = 0;
                }
            }

            return res;
        }
    }
}