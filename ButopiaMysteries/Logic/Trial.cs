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
        public static int NumericResult(List<int>? list, int skill=0)
        {
            if (skill == 0 || list == null || list.Count == 0)
            {
                return 0;
            }
            int result = 0;
            foreach (int item in list)
            {
                result += item;
            }
            return result;
        }
    }
}
