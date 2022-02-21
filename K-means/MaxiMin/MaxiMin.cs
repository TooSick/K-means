using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;

namespace K_means.MaxiMin
{
    static class MaxiMin
    {

        public static List<Claster> GetClasters(List<Dot> dots)
        {
            Random randClaster = new Random();
            List<Claster> clasters = new List<Claster>();

            clasters.Add(new Claster(new Dot(dots[randClaster.Next(0, dots.Count)])));
            clasters.Add(new Claster(new Dot(GetDotAtMaxDist(clasters[^1].Core, dots))));

            int absoluteMaxDist = 0;
            do
            {
                DistributionDotsByClasters(clasters, dots);
                FindAndSetDotAtMaxDist(clasters);
                absoluteMaxDist = GetAbsoluteMaxDist(clasters);
                if (absoluteMaxDist > GetArithmeticMean(clasters) / 2)
                {
                    clasters.Add(new Claster(new Dot(GetDotAtAbsoluteMaxDist(clasters))));
                    FreeingDotsFromClasters(clasters);
                }
            }
            while (absoluteMaxDist > GetArithmeticMean(clasters) / 2);

            return clasters;
        }

        private static void FreeingDotsFromClasters(List<Claster> clasters)
        {
            for (int i = 0; i < clasters.Count; i++)
            {
                clasters[i].ClasterDots.Clear();
            }
        }

        private static Dot GetDotAtAbsoluteMaxDist(List<Claster> clasters)
        {
            int index = 0;
            int maxDist = clasters[0].DistanceToDotAtMaxDist;

            for (int i = 1; i < clasters.Count; i++)
            {
                if (clasters[i].DistanceToDotAtMaxDist > maxDist)
                {
                    maxDist = clasters[i].DistanceToDotAtMaxDist;
                    index = i;
                }
            }

            return clasters[index].DotAtMaxDist;
        }

        private static int GetAbsoluteMaxDist(List<Claster> clasters)
        {
            int maxDist = clasters[0].DistanceToDotAtMaxDist;

            for (int i = 1; i < clasters.Count; i++)
            {
                if (clasters[i].DistanceToDotAtMaxDist > maxDist)
                {
                    maxDist = clasters[i].DistanceToDotAtMaxDist;
                }
            }

            return maxDist;
        }

        private static void DistributionDotsByClasters(List<Claster> clasters, List<Dot> dots)
        {
            for (int i = 0; i < dots.Count; i++)
            {
                int minDist = GetDistance(clasters[0].Core, dots[i]);
                int clasterIndex = 0;
                for (int j = 1; j < clasters.Count; j++)
                {
                    int tempMinDist = GetDistance(clasters[j].Core, dots[i]);
                    if (tempMinDist < minDist)
                    {
                        minDist = tempMinDist;
                        clasterIndex = j;
                    }
                }

                clasters[clasterIndex].ClasterDots.Add(dots[i]);
            }
        }

        private static void FindAndSetDotAtMaxDist(List<Claster> clasters)
        {
            for (int i = 0; i < clasters.Count; i++)
            {
                clasters[i].DotAtMaxDist = GetDotAtMaxDist(clasters[i].Core, clasters[i].ClasterDots);
                clasters[i].DistanceToDotAtMaxDist = GetDistance(clasters[i].Core, clasters[i].DotAtMaxDist);
            }
        }

        private static int GetDotIndexWhisMaxDist(Dot core, List<Dot> dots)
        {
            int index = 0;
            int maxDist = 0;

            for (int i = 0; i < dots.Count; i++)
            {
                int tempMaxDist = GetDistance(core, dots[i]);
                if (maxDist < tempMaxDist)
                {
                    maxDist = tempMaxDist;
                    index = i;
                }
            }

            return index;
        }

        private static Dot GetDotAtMaxDist(Dot core, List<Dot> dots)
        {
            return dots[GetDotIndexWhisMaxDist(core, dots)];
        }

        private static int GetArithmeticMean(List<Claster> clasters)
        {
            int arithmeticMean = 0;
            int counter = 0;

            for (int i = 0; i < clasters.Count - 1; i++)
            {
                for (int j = i + 1; j < clasters.Count; j++)
                {
                    arithmeticMean += GetDistance(clasters[i].Core, clasters[j].Core);
                    counter++;
                }
            }

            return arithmeticMean / counter;
        }

        private static int GetDistance(Dot firstDot, Dot secondDot)
        {
            return (int)Math.Sqrt(Math.Pow(firstDot.X - secondDot.X, 2) + Math.Pow(firstDot.Y - secondDot.Y, 2));
        }
    }
}
