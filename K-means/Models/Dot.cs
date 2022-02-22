using System.Windows.Media;

namespace K_means
{
    class Dot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Brush Color { get; set; } = Brushes.Black;

        public Dot(int x, int y, int width, int height)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public Dot(Dot dot)
        {
            X = dot.X;
            Y = dot.Y;
            Color = dot.Color;
            Width = dot.Width;
            Height = dot.Height;
        }
    }
}
