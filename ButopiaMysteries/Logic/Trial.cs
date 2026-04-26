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
        private static readonly Random random = new Random();

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

            string rankName = Skill_Operations.GetSkillText(skill);
            int bonusModifier = Skill_Operations.GetSkillValue(rankName);

            return result + bonusModifier;
        }

        public static List<int> Cast(int nbDé)
        {
            List<int> results = new List<int>();

            for (int i = 0; i < nbDé; i++)
            {
                results.Add(random.Next(1, 7));
            }

            return results;
        }

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