using System;
using System.Collections.Generic;
using System.Text;

namespace K_means.Classes
{
    static class MaxiMin
    {
        public static List<Dot> GetClasters(List<Dot> dots)
        {
            List<Dot> clasters = new List<Dot>();
            Random randClaster = new Random();

            clasters.Add(dots[randClaster.Next(0, dots.Count)]);
            clasters.Add(dots[FindMaxDist(DistancesCalculation(clasters[0], dots))]);

            int thresholdValue = DistancesCalculation(clasters[0], clasters[1]) / 2;

            return clasters;
        }

        private static int[] DistancesCalculation(Dot dot, List<Dot> dots)
        {
            int[] distance = new int[dots.Count];

            for (int i = 0; i < dots.Count; i++)
            {
                distance[i] = (int)Math.Sqrt(Math.Pow(dot.X - dots[i].X, 2) + Math.Pow(dot.Y - dots[i].Y, 2));
            }

            return distance;
        }

        private static int DistancesCalculation(Dot firstDot, Dot secondDot)
        {
            int distance = (int)Math.Sqrt(Math.Pow(firstDot.X - secondDot.X, 2) + Math.Pow(firstDot.Y - secondDot.Y, 2));

            return distance;
        }

        private static int FindMaxDist(int[] distances)
        {
            int dotIndex = 0;
            int maxDist = distances[0];

            for (int i = 1; i < distances.Length; i++)
            {
                if (distances[i] > maxDist)
                {
                    maxDist = distances[i];
                    dotIndex = i;
                }
            }

            return dotIndex;
        }
    }
}
