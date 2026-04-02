using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// Application data: some names
    /// </summary>
    public static class Names
    {
        /// <summary>
        /// A few stock names.
        /// </summary>
        public static List<string> NameList { get; } = ["Alice", "Bob", "Carol", "Dave", "Elin", "Fabian", "Giuliana", "Hiro", "Isatis", "Jansen",
        "Kaori", "Lambert", "Mana", "Oswald", "Penelope", "Quincy", "Rose", "Sam", "Typhaine", "Uriel", "Vero", "Wolf", "Xiaomei", "Ysmael", "Zoe"];
        /// <summary>
        /// Get a single random name.
        /// </summary>
        public static string RandomName => NameList[new Random().Next(NameList.Count)];
    }
}
