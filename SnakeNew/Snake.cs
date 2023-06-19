namespace SnakeApp
{
    public class Snake
    {
        protected List<Dot> SnakeCoordinats = new();
        protected int SnakeLenght = 50;
        static string? lastInput = null;
        

        public Snake(int x, int y)
        {
            for (int i = 0; i < SnakeLenght; i++)
            {
                SnakeCoordinats.Add(new Dot(x, y-i));
            }
        }

        public List<Dot> GetSnakeCoordinats()
        {
            return SnakeCoordinats;
        }

        public void UpdateCoordinats(string key)
        {
            Control control = new Control();
            key = control.CheckInput(lastInput);
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
            for (int i = SnakeLenght-1; i > 0; i--)
            {
                SnakeCoordinats[i].SetY(SnakeCoordinats[i-1].GetY());
                SnakeCoordinats[i].SetX(SnakeCoordinats[i-1].GetX());
            }
        }
    }
}
 