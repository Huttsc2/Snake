namespace SnakeApp
{
    public class Area
    {
        private int Width { get; set; }
        private int Height { get; set; }
        private List<Point> AreaCells { get; set; }

        public Area(int width, int height)
        {
            Width = width;
            Height = height;
            AreaCells = new();
            SetAreaCells();
        }

        public int GetWidth()
        {
            return Width;
        }

        public int GetHeight()
        {
            return Height;
        }

        public void SetAreaCells()
        {
            for (int i = 1; i < Width-1; i += 2)
            {
                for (int j = 1; j < Height - 1; j++)
                {
                    AreaCells.Add(new Point(i, j));
                }
            }
        }

        public List<Point> GetAreaCells()
        {
            return AreaCells;
        }
    }
}
