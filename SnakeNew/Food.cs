namespace SnakeApp
{
    public class Food : Point
    {
        private static int AreaWight { get; set; }
        private static int AreaHight { get; set; }
        private static Snake Snake { get; set; }
        private static bool IsRelevantCoordinats { get; set; }
        private static Random Random { get; set; }

        public Food(int x, int y, Area area, Snake snake) : base(x, y)
        {
            AreaWight = area.GetWidth();
            AreaHight = area.GetHeight();
            Snake = snake;
            Random = new Random();
        }

        public void SetRandomCoordinate()
        {
            IsRelevantCoordinats = false;
            while (!IsRelevantCoordinats)
            {
                GenerateRandomCoordinates();
                CheckRelevantCoordinats();
            }
        }

        private void GenerateRandomCoordinates()
        {
            IsRelevantCoordinats = true;
            XCoorinate = Random.Next(1, AreaWight - 2);
            if (XCoorinate % 2 == 0)
            {
                XCoorinate++;
                if (XCoorinate > AreaWight - 2)
                {
                    XCoorinate -= 2;
                }
            }
            YCoordiante = Random.Next(1, AreaHight - 1);
        }

        private void CheckRelevantCoordinats()
        {
            if (Snake.GetSnakeCoordinats().Any(s => s.GetX() == XCoorinate && s.GetY() == YCoordiante))
            {
                IsRelevantCoordinats = false;
            }
        }
    }
}
