namespace SnakeApp
{
    public class Drawing
    {
        private Area Area;
        private Snake Snake;
        private Food Food;

        public Drawing(Area area, Snake snake, Food food)
        {
            Area = area;
            Snake = snake;
            Food = food;
        }

        public void Draw()
        {
            for (int i = 0; i < Area.GetHeight(); i++)
            {
                for (int j = 0; j < Area.GetWidth(); j++)
                {
                    if (j == 0)
                    {
                        Console.Write("|");
                    }
                    else if (j == Area.GetWidth() - 1)
                    {
                        Console.Write("|\n");
                    }
                    else if (Snake.GetSnakeCoordinats().Any(e => e.GetY() == i && e.GetX() == j))
                    {
                        Console.Write("☻");
                    }
                    else if (j == Food.GetX() && i == Food.GetY())
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
            }
        }
    }
}
