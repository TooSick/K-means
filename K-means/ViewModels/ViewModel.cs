using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace K_means.ViewModels
{
    class ViewModel : INotifyPropertyChanged
    {
        public List<Dot> Dots { get; set; }

        public ViewModel(int numOfDots, int windowWidth, int windowHeight)
        {
            Dots = DotsGenerator.Generation(numOfDots, windowWidth, windowHeight);
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
