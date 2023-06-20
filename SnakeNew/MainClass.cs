namespace SnakeApp
{
    public class MainClass
    {
        private static int SnakeHeadCoordinateX = 7;
        private static int SnakeHeadCoordinateY = 8;
        private static int StartingSnakeLenght = 3;
        private static int Width = 44; //only even numbers
        private static int Height = 22;
        private static int FoodX = 13; //only odd numbers
        private static int FoodY = 13;
        private static string? key = null;
        private static bool IsEaten = false;
        public static void Main(string[] args)
        {
            Snake snake = new Snake(SnakeHeadCoordinateX, SnakeHeadCoordinateY, StartingSnakeLenght);
            Area area = new Area(Width, Height);
            Food food = new Food(FoodX, FoodY, Width, Height);
            Drawing drawing = new Drawing(area, snake, food);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.SetWindowSize(Width, Height+1);

            while (true)
            {
                snake.UpdateSnakeCoordinats(key);
                SnakeHeadCoordinateX = snake.GetSnakeHeadCoordinats().GetX();
                SnakeHeadCoordinateY = snake.GetSnakeHeadCoordinats().GetY();
                if (SnakeHeadCoordinateX == FoodX && SnakeHeadCoordinateY == FoodY)
                {
                    food.RandomCoordinate();
                    snake.GrowSnake();
                    IsEaten = true;
                }
                if (IsEaten)
                {
                    FoodX = food.GetX();
                    FoodY = food.GetY();
                    IsEaten = false;
                }
                //drawing.Draw();
                //drawing.DrawByStringBuilder();
                drawing.DrawByCharArray();
                Thread.Sleep(100);
                Console.Clear();
            }
        }
    }
}
