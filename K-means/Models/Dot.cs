using System.Windows.Media;

namespace K_means
{
    class Dot
    {
        private const int width = 5;
        private const int height = 5;
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get { return width; } }
        public int Height { get { return height; } }
        public Brush Color { get; set; } = Brushes.Black;

        public Dot(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Dot(Dot dot)
        {
            X = dot.X;
            Y = dot.Y;
            Color = dot.Color;
        }
    }
}
