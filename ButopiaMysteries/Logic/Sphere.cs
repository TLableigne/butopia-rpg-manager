using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ButopiaMysteries.Logic
{
    /// <summary>
    /// Spheres for all skills.
    /// </summary>
    public enum Sphere
    {
        Algebra,
        Verb,
        Transition,
        Creation,
        Valorization,
    }
    /// <summary>
    /// Provides extension methods for the Sphere enum.
    /// </summary>
    public static class Sphere_Operations
    {
        /// <summary>
        /// Returns the French display name of the specified sphere.
        /// </summary>
        /// <param name="sphere">The sphere to evaluate.</param>
        /// <returns>The localized name.</returns>
        public static string Name(this Sphere sphere)
        {
            return sphere switch
            {
                Sphere.Algebra => "Algèbre",
                Sphere.Verb => "Verbe",
                Sphere.Transition => "Transition",
                Sphere.Creation => "Création",
                Sphere.Valorization => "Valorisation",
                _ => "Inconnu"
            };
        }
    }
}
