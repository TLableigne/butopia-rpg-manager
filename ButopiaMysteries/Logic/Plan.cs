using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// Enum for all plans.
    /// </summary>
    public enum Plan
    {
        Thinkers,
        Legates,
        Makers,
        Integrators,
        Traders,
    }
    /// <summary>
    /// Provides extension methods for the Plan enum.
    /// </summary>
    public static class Plan_Operations
    {
        /// <summary>
        /// Returns the French display name of the specified plan.
        /// </summary>
        /// <param name="plan">The plan to evaluate.</param>
        /// <returns>The localized name.</returns>
        public static string Name(this Plan plan)
        {
            return plan switch
            {
                Plan.Thinkers => "Penseurs",
                Plan.Legates => "Légats",
                Plan.Makers => "Faiseurs",
                Plan.Integrators => "Intégrateurs",
                Plan.Traders => "Commerçants",
                _ => "Inconnu"
            };
        }
    }
}
