namespace SnakeApp
{
    public class Food : Point
    {
        private int AreaWight { get; set; }
        private int AreaHight { get; set; }
        public Food(int x, int y, Area area) : base(x, y)
        {
            AreaWight = area.GetWidth();
            AreaHight = area.GetHeight();
        }

        public void RandomCoordinate()
        {
            Random random = new Random();
            XCoorinate = random.Next(1, AreaWight-2);
            if (XCoorinate%2 == 0)
            {
                XCoorinate++;
                if (XCoorinate > AreaWight-2)
                {
                    XCoorinate-=2;
                }
            }
            YCoordiante = random.Next(2, AreaHight-1);
        }
    }
}
