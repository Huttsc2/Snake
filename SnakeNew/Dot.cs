namespace SnakeApp
{
    public class Dot
    {
        protected int XCoorinate { get; set; }
        protected int YCoordiante { get; set; }

        public Dot(int x, int y)
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
