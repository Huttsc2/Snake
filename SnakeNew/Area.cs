namespace SnakeApp
{
    public class Area
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private List<Point> Point { get; set; }

        public Area(int width, int height)
        {
            Width = width;
            Height = height;
            Point = new List<Point>();
            SetWallCoordinates();
        }

        public int GetWidth()
        {
            return Width;
        }

        public int GetHeight()
        {
            return Height;
        }

        public List<Point> GetWallCoordinates()
        {
            return Point;
        }

        public void SetWallCoordinates()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = -1; j < Width; j++)
                {
                    if (i == 0 || i == Height - 1 || j == -1 || j == Width - 1)
                    {
                        Point.Add(new Point(j, i));
                    }
                }
            }
        }
    }
}
