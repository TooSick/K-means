using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows.Media;
using System.Collections.ObjectModel;

namespace K_means.ViewModels
{
    class ViewModel
    {
        public List<Dot> Dots { get; set; }
        public List<Dot> Clasters { get; set; }

        public ViewModel(int numOfDots, int windowWidth, int windowHeight)
        {
            Dots = DotsGenerator.Generation(numOfDots, windowWidth, windowHeight);
            Classes.KMeans.AlgorithmExecution(Dots);
        }
    }
}
