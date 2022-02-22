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
            List<Brush> colors = new List<Brush>()
            {
                Brushes.Red,
                Brushes.Green,
                Brushes.Yellow,
                Brushes.Blue,
                Brushes.DarkBlue,
                Brushes.Gray,
                Brushes.Brown,
                Brushes.Pink,
                Brushes.Lavender,
                Brushes.Silver,
                Brushes.Coral,
            };

            clasters.Add(new Claster(new Dot(dots[randClaster.Next(0, dots.Count)])));
            clasters[^1].Core.Width = clasters[^1].Core.Width * 2;
            clasters[^1].Core.Height = clasters[^1].Core.Height * 2;
            clasters[^1].Color = colors[randClaster.Next(0, colors.Count)];
            clasters.Add(new Claster(new Dot(GetDotAtMaxDist(clasters[^1].Core, dots))));
            clasters[^1].Core.Width = clasters[^1].Core.Width * 2;
            clasters[^1].Core.Height = clasters[^1].Core.Height * 2;
            clasters[^1].Color = colors[randClaster.Next(0, colors.Count)];

            int absoluteMaxDist = 0;
            do
            {
                DistributionDotsByClasters(clasters, dots);
                FindAndSetDotAtMaxDist(clasters);
                absoluteMaxDist = GetAbsoluteMaxDist(clasters);
                if (absoluteMaxDist > GetArithmeticMean(clasters) / 2)
                {
                    clasters.Add(new Claster(new Dot(GetDotAtAbsoluteMaxDist(clasters))));
                    clasters[^1].Core.Width = clasters[^1].Core.Width * 2;
                    clasters[^1].Core.Height = clasters[^1].Core.Height * 2;
                    clasters[^1].Color = colors[randClaster.Next(0, colors.Count)];
                }
                FreeingDotsFromClasters(clasters);
            }
            while (absoluteMaxDist > GetArithmeticMean(clasters) / 2);

            return clasters;
        }

        public static void FreeingDotsFromClasters(List<Claster> clasters)
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

        public static void DistributionDotsByClasters(List<Claster> clasters, List<Dot> dots)
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

        public static int GetDistance(Dot firstDot, Dot secondDot)
        {
            return (int)Math.Sqrt(Math.Pow(firstDot.X - secondDot.X, 2) + Math.Pow(firstDot.Y - secondDot.Y, 2));
        }
    }
}
