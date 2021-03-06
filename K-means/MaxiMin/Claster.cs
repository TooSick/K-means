using System.Collections.Generic;
using System.Windows.Media;

namespace K_means.MaxiMin
{
    class Claster
    {
        public Dot Core { get; set; }
        public List<Dot> ClasterDots { get; private set; }
        public Dot DotAtMaxDist { get; set; }
        public int DistanceToDotAtMaxDist { get; set; }
        public Brush Color { get; set; }

        public Claster()
        {
            ClasterDots = new List<Dot>();
        }

        public Claster(Dot core) : this()
        {
            Core = core;
        }
    }
}
