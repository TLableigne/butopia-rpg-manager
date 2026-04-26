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
    public static class Plan_Operations
    {
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
