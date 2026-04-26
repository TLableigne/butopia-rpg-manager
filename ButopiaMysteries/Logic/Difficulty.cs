using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// Represents the various levels of difficulty for a trial.
    /// </summary>
    public enum Difficulty
    {
        None,
        Trivial,
        Facile,
        Normal,
        Complexe,
        Delicat,
        Defi,
        Exploit,
        Surhumain,
        Impossible
    }

    /// <summary>
    /// Provides extension methods and utility operations related to the Difficulty enum.
    /// </summary>
    public static class Difficulty_Operations
    {
        /// <summary>
        /// Returns the French display name for a specific difficulty level.
        /// </summary>
        /// <param name="difficulty">The difficulty to evaluate.</param>
        /// <returns>The localized string of the difficulty.</returns>
        public static string Name(this Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.None => "Aucune",
                Difficulty.Trivial => "Trivial",
                Difficulty.Facile => "Facile",
                Difficulty.Normal => "Normal",
                Difficulty.Complexe => "Complexe",
                Difficulty.Delicat => "Délicat",
                Difficulty.Defi => "Défi",
                Difficulty.Exploit => "Exploit",
                Difficulty.Surhumain => "Surhumain",
                Difficulty.Impossible => "Impossible",
                _ => "Inconnu"
            };
        }

        /// <summary>
        /// Gets the minimum score required to succeed at a specific difficulty level.
        /// </summary>
        /// <param name="difficulty">The target difficulty.</param>
        /// <returns>The threshold score needed for success.</returns>
        public static int MinimumScore(this Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.None => 0,
                Difficulty.Trivial => 5,
                Difficulty.Facile => 10,
                Difficulty.Normal => 15,
                Difficulty.Complexe => 20,
                Difficulty.Delicat => 25,
                Difficulty.Defi => 30,
                Difficulty.Exploit => 50,
                Difficulty.Surhumain => 70,
                Difficulty.Impossible => 100,
                _ => 0
            };
        }

        /// <summary>
        /// Determines the highest difficulty achieved based on a given trial score.
        /// </summary>
        /// <param name="score">The score achieved (typically in an open trial).</param>
        /// <returns>The corresponding maximum difficulty reached.</returns>
        public static Difficulty GetMaximumDifficulty(int score)
        {
            if (score >= 100)
            {
                return Difficulty.Impossible;
            }
            if (score >= 70)
            {
                return Difficulty.Surhumain;
            }
            if (score >= 50)
            {
                return Difficulty.Exploit;
            }
            if (score >= 30)
            {
                return Difficulty.Defi;
            }
            if (score >= 25)
            {
                return Difficulty.Delicat;
            }
            if (score >= 20) 
            {
                return Difficulty.Complexe; 
            } 
            if (score >= 15) 
            {
                return Difficulty.Normal;
            } 
            if (score >= 10) 
            {return Difficulty.Facile; 
            } 
            if (score >= 5) 
            { 
                return Difficulty.Trivial;
            }
            return Difficulty.None;
        }

        /// <summary>
        /// Reduces a difficulty by a specified number of steps, stopping at Difficulty.None.
        /// </summary>
        /// <param name="difficulty">The starting difficulty level.</param>
        /// <param name="crans">The number of steps to reduce.</param>
        /// <returns>The lowered difficulty level.</returns>
        public static Difficulty LoseDfficulty(this Difficulty difficulty, int crans)
        {
            int numActuel = (int)difficulty;
            int nouveauNum = numActuel - crans;
            if (nouveauNum < 0)
            {
                nouveauNum = 0;
            }
            return (Difficulty)nouveauNum;
        }
    }
}
