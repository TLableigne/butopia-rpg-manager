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
        public static Difficulty OpenTrial(MysterySheet character, Indicator indicator, Skill skill, int malus = 0)
        {
            int nbDé = character.Indicators[indicator];
            int skillLevel = character.Skills[skill];
            List<int> resDé = Cast(nbDé);
            int totalScore = NumericResult(resDé, skillLevel);
            Difficulty baseDiff = Difficulty_Operations.GetMaximumDifficulty(totalScore);
            int indexFinal = (int)baseDiff - malus;
            if (indexFinal < 0)
            {
                indexFinal = 0;
            }
            return (Difficulty)indexFinal;
        }
        public static bool ClosedTrial(MysterySheet character, Indicator indicator, Skill skill, Difficulty difficultéVisée, int malus = 0)
        {
            bool res = false;
            Difficulty difficulté = OpenTrial(character, indicator, skill,malus);
            if (difficulté.MinimumScore() >= difficultéVisée.MinimumScore())
            {
               res = true;
            }
            return res;
        }
    }
}
