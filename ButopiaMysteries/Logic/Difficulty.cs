using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    public enum Difficulty
    {
        Rien,
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

    public static class Difficulty_Operations
    {

        public static string Name(this Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.Rien => "Rien",
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

        public static int MinimumScore(this Difficulty difficulty)
        {
            return difficulty switch
            {
                Difficulty.Rien => 0,
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
            return Difficulty.Rien;
        }
    }
}
