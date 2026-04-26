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
        public static int NumericResult(List<int>? list, int skill=0)
        {
            if (skill == 0 || list == null || list.Count == 0)
            {
                return 0;
            }
            int result = 0;
            foreach (int item in list)
            {
                result += item;
            }
            return result;
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
        public static Difficulty OpenTrial(MysterySheet character, Indicator indicator, Skill skill)
        {
            int nbDé = character.Indicators[indicator];
            int skillLevel = character.Skills[skill];
            List<int> resDé = Cast(nbDé);
            int totalScore = NumericResult(resDé, skillLevel);
            return Difficulty_Operations.GetMaximumDifficulty(totalScore);
        }
        public static bool ClosedTrial(MysterySheet character, Indicator indicator, Skill skill, Difficulty difficultéVisée)
        {
            if (difficultéVisée == Difficulty.None)
            {
                return true;
            }

            int skillLevel = character.Skills[skill];

            switch (skillLevel)
            {
                case 0:
                    return false;

                case 1:
                    if (difficultéVisée >= Difficulty.Exploit) return false;
                    break;

                case 2:
                    if (difficultéVisée <= Difficulty.Trivial) return true;
                    if (difficultéVisée >= Difficulty.Surhumain) return false;
                    break;

                case 3:
                    if (difficultéVisée <= Difficulty.Trivial) return true;
                    if (difficultéVisée >= Difficulty.Impossible) return false;
                    break;

                case 4:
                    if (difficultéVisée <= Difficulty.Facile) return true;
                    break;

                case 5:
                    if (difficultéVisée <= Difficulty.Normal) return true;
                    break;

                case 6:
                    if (difficultéVisée <= Difficulty.Complexe) return true;
                    break;
            }
            Difficulty difficultéObtenue = OpenTrial(character, indicator, skill);
            return difficultéObtenue.MinimumScore() >= difficultéVisée.MinimumScore();
        }
    }
}
