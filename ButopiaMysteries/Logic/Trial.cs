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
            bool res = false;
            Difficulty difficulté = OpenTrial(character, indicator, skill);
            if (difficulté.MinimumScore() >= difficultéVisée.MinimumScore())
            {
               res = true;
            }
            return res;
        }
    }
}
