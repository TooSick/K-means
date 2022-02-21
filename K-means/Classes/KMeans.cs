using System;
using System.Collections.Generic;
using System.Text;
using K_means.MaxiMin;

namespace K_means.Classes
{
    static class KMeans
    {
        public static void AlgorithmExecution(List<Dot> dots)
        {
            List<Claster> clasters = MaxiMin.MaxiMin.GetClasters(dots);
        }
    }
}
