using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// A class storing a roster of several characters.
    /// </summary>
    public class Roster
    {
        /// <summary>
        /// Mapping: name to character sheet.
        /// </summary>
        public Dictionary<string, MysterySheet> Sheets { get; init; } = [];
    }
}
