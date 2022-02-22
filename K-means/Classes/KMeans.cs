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

            MaxiMin.MaxiMin.DistributionDotsByClasters(clasters, dots);
            while (true)
            {
                List<Claster> clastersCopy = new List<Claster>(clasters);
                Centralization(clasters);
                MaxiMin.MaxiMin.FreeingDotsFromClasters(clasters);
                MaxiMin.MaxiMin.DistributionDotsByClasters(clasters, dots);
                if (!ClastersHaveChanged(clasters, clastersCopy))
                {
                    break;
                }
            }

            ChangeDotsColor(clasters, dots);
            for (int i = 0; i < clasters.Count; i++)
            {
                dots.Add(clasters[i].Core);
            }
        }

        private static void ChangeDotsColor(List<Claster> clasters, List<Dot> dots)
        {
            for (int i = 0; i < clasters.Count; i++)
            {
                for (int j = 0; j < clasters[i].ClasterDots.Count; j++)
                {
                    if (dots.Contains(clasters[i].ClasterDots[j]))
                    {
                        dots[dots.IndexOf(clasters[i].ClasterDots[j])].Color = clasters[i].Color;
                    }
                }
            }
        }

        private static bool ClastersHaveChanged(List<Claster> newClasters, List<Claster> oldClasters)
        {
            if (newClasters.Count != oldClasters.Count)
            {
                return true;
            }
            else
            {
                for (int i = 0; i < newClasters.Count; i++)
                {
                    if (!oldClasters.Contains(newClasters[i]))
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        private static void Centralization(List<Claster> clasters)
        {
            for (int i = 0; i < clasters.Count; i++)
            {
                int allX = 0;
                int allY = 0;
                int counter = 0;

                for (int j = 0; j < clasters[i].ClasterDots.Count; j++)
                {
                    allX += clasters[i].ClasterDots[j].X;
                    allY += clasters[i].ClasterDots[j].Y;
                    counter++;
                }

                clasters[i].Core.X = allX / counter;
                clasters[i].Core.Y = allY / counter;
            }
        }
    }
}
