using System;
using System.Collections.Generic;
using System.Windows.Media;
using System.Collections.ObjectModel;


namespace K_means.ViewModels
{
    static class DotsGenerator
    {
        public static List<Dot> Generation(int numOfDots, int windowWidth, int windowHeight)
        {
            List<Dot> dots = new List<Dot>();
            Random randCoordinates = new Random();

            for (int i = 0; i < numOfDots; i++)
            {
                dots.Add(new Dot(randCoordinates.Next(0, windowWidth), randCoordinates.Next(0, windowHeight), 2, 2));
            }

            return dots;
        }
    }
}
