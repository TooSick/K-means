using System.Windows.Media;

namespace K_means
{
    class Dot
    {
        private const int width = 2;
        private const int height = 2;
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public Brush Color { get; set; }
    }
}
