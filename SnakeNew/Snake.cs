namespace SnakeApp
{
    public class Snake
    {
        private static List<Point> SnakeCoordinats = new();
        private static int StartingSnakeLenght;
        private static string? lastInput = null;
        private static Control Control = new Control();
        

        public Snake(int x, int y, int lenght)
        {
            StartingSnakeLenght = lenght;
            for (int i = 0; i < StartingSnakeLenght; i++)
            {
                SnakeCoordinats.Add(new Point(x, y-i));
            }
        }

        public List<Point> GetSnakeCoordinats()
        {
            return SnakeCoordinats;
        }

        public Point GetSnakeHeadCoordinats()
        {
            return SnakeCoordinats[0];
        }

        public void GrowSnake()
        {
            SnakeCoordinats.Add(new Point(SnakeCoordinats[SnakeCoordinats.Count-1].GetX(), SnakeCoordinats[SnakeCoordinats.Count - 1].GetY()));
        }

        public void UpdateSnakeCoordinats(string? key)
        {
            key = Control.CheckInput(lastInput);
            if (key != null)
            {
                lastInput = key;
            }
            switch (lastInput)
            {
                case "w":
                    SetBodyCoordinate();
                    SnakeCoordinats[0].SetY(SnakeCoordinats[0].GetY()-1);
                    break;
                case "s":
                    SetBodyCoordinate();
                    SnakeCoordinats[0].SetY(SnakeCoordinats[0].GetY()+1);
                    break;
                case "d":
                    SetBodyCoordinate();
                    SnakeCoordinats[0].SetX(SnakeCoordinats[0].GetX()+2);
                    break;
                case "a":
                    SetBodyCoordinate();
                    SnakeCoordinats[0].SetX(SnakeCoordinats[0].GetX()-2);
                    break;
            }
        }

        public void SetBodyCoordinate()
        {
            for (int i = SnakeCoordinats.Count-1; i > 0; i--)
            {
                SnakeCoordinats[i].SetY(SnakeCoordinats[i-1].GetY());
                SnakeCoordinats[i].SetX(SnakeCoordinats[i-1].GetX());
            }
        }
    }
}
 