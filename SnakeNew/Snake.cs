namespace SnakeApp
{
    public class Snake
    {
        private List<Point> SnakeCoordinats { get; set; }
        private List<Point> SnakeBodyCoordinates { get; set; }
        private int StartingSnakeLenght { get; set; }
        private Control Control { get; set; }
        

        public Snake(int x, int y, int lenght)
        {
            SnakeCoordinats = new();
            StartingSnakeLenght = lenght;
            Control = new Control();
            for (int i = 0; i < StartingSnakeLenght; i++)
            {
                SnakeCoordinats.Add(new Point(x, y-i));
            }
        }

        public void UpdateSnakeCoordinates(string? key)
        {
            Control.SetLastInput();
            switch (Control.GetLastInput())
            {
                case "w":
                    SetSnakeCoordinate();
                    SnakeCoordinats[0].SetY(SnakeCoordinats[0].GetY() - 1);
                    break;
                case "s":
                    SetSnakeCoordinate();
                    SnakeCoordinats[0].SetY(SnakeCoordinats[0].GetY() + 1);
                    break;
                case "d":
                    SetSnakeCoordinate();
                    SnakeCoordinats[0].SetX(SnakeCoordinats[0].GetX() + 2);
                    break;
                case "a":
                    SetSnakeCoordinate();
                    SnakeCoordinats[0].SetX(SnakeCoordinats[0].GetX() - 2);
                    break;
            }
        }

        public List<Point> GetSnakeCoordinates()
        {
            return SnakeCoordinats;
        }

        public List<Point> GetSnakeBodyCoordinates()
        {
            SetSnakeBodyCoordinates();
            return SnakeBodyCoordinates;
        }

        private void SetSnakeBodyCoordinates()
        {
            SnakeBodyCoordinates = new(GetSnakeCoordinates());
            SnakeBodyCoordinates.RemoveAt(0);
        }

        public Point GetSnakeHeadCoordinates()
        {
            return SnakeCoordinats[0];
        }

        public void GrowSnake()
        {
            SnakeCoordinats.Add(new Point(SnakeCoordinats[SnakeCoordinats.Count-1].GetX(), 
                SnakeCoordinats[SnakeCoordinats.Count - 1].GetY()));
        }

        private void SetSnakeCoordinate()
        {
            for (int i = SnakeCoordinats.Count - 1; i > 0; i--)
            {
                SnakeCoordinats[i].SetY(SnakeCoordinats[i - 1].GetY());
                SnakeCoordinats[i].SetX(SnakeCoordinats[i - 1].GetX());
            }
        }
    }
}
 