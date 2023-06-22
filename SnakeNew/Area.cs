namespace SnakeApp
{
    public class Area
    {
        private int Width { get; set; }
        private int Height { get; set; }

        public Area(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public int GetWidth()
        {
            return Width;
        }

        public int GetHeight()
        {
            return Height;
        }
    }
}
