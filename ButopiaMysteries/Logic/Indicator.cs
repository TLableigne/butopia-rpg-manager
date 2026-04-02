using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// Enum for all indicators (Characteristics).
    /// </summary>
    public enum Indicator
    {
        None,
        Body,   
        Mind,   
        Sense,  
        Maximum
    }
    /// <summary>
    /// Companion class for the enum above.
    /// </summary>
    public static class Indicator_Operations
    {
        /// <summary>
        /// The Name associated to the indicator.
        /// </summary>
        /// <param name="indicator">indicator to examine</param>
        /// <returns>the name (in French)</returns>
        public static string Name(this Indicator indicator)
        {
            return indicator switch
            {
                Indicator.Body => "Corps",
                Indicator.Mind => "Esprit",
                Indicator.Sense => "Sens",
                Indicator.Maximum => "Maximum",
                _ => string.Empty,
            };
        }
        /// <summary>
        /// The absolute lower bound for indicators.
        /// </summary>
        public static int MinValue { get; } = 1;
        /// <summary>
        /// The absolute upper bound for indicators.
        /// </summary>
        public static int MaxValue { get; } = 7;
        /// <summary>
        /// The maximum value at creation for an indicator.
        /// </summary>
        public static int CreationThreshold { get; } = 5;
        /// <summary>
        /// The basic value for fixed creation.
        /// </summary>
        public static int BasicValue { get; } = 3;
        /// <summary>
        /// A formula yielding the indicator points necessary for an indicator level.
        /// </summary>
        /// <param name="level">the target level</param>
        /// <returns>the corresponding indicator points</returns>
        public static int IndicatorPointsAtLevel(int level) => level * 2;
    }
}