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
    public static class Sphere_Operations
    {
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
