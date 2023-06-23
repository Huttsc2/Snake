namespace SnakeApp
{
    public class Food
    {
        private int AreaWight { get; set; }
        private int AreaHight { get; set; }
        private Snake Snake { get; set; }
        private List<Point> CurrentPoints { get; set; }
        private Point NewFood { get; set; }

        public Food(Area area, Snake snake)
        {
            AreaWight = area.GetWidth();
            AreaHight = area.GetHeight();
            Snake = snake;
            CurrentPoints = new List<Point>();
            SetAreaPoints();
        }

        public void SetAreaPoints()
        {
            for (int i = 1; i < AreaWight-1; i+=2)
            {
                for (int j = 1; j < AreaHight-1; j++)
                {
                    CurrentPoints.Add(new Point(i, j));
                }
            }
        }

        public void SetFreePointsForFood()
        {
            CurrentPoints.RemoveAll(p => Snake.GetSnakeCoordinats()
            .Any(partial => partial.GetX() == p.GetX() && partial.GetY() == p.GetY()));
        }

        public void SetNewFood()
        {
            SetFreePointsForFood();
            NewFood = CurrentPoints[new Random().Next(CurrentPoints.Count-1)];
        }

        public Point GetNewFood()
        {
            return NewFood;
        }
    }
}
