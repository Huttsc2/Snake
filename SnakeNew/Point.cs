namespace SnakeApp
{
    public class Point
    {
        protected int XCoorinate { get; set; }
        protected int YCoordiante { get; set; }

        public Point(int x, int y)
        {
            XCoorinate = x;
            YCoordiante = y;
        }

        public int GetX()
        {
            return XCoorinate;
        }

        public void SetX(int x)
        {
            XCoorinate = x;
        }

        public int GetY()
        {
            return YCoordiante;
        }

        public void SetY(int y)
        {
            YCoordiante = y;
        }
    }
}
