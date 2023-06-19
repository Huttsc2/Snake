namespace SnakeApp
{
    public class MainClass
    {
        private static int StartX = 8;
        private static int StartY = 8;
        private static int StartingSnakeLenght = 3;
        private static int FoodX = 20;
        private static int FoodY = 10;
        private static int Width = 45;
        private static int Height = 22;
        private static string? key = null;
        public static void Main(string[] args)
        {
            Snake snake = new Snake(StartX, StartY, StartingSnakeLenght);
            Area area = new Area(Width, Height);
            Food food = new Food(FoodX, FoodY);
            Drawing drawing = new Drawing(area, snake, food);
            
            while (true)
            {
                snake.UpdateSnakeCoordinats(key);
                if (snake.GetSnakeHeadCoordinats().GetX() == food.GetX() && 
                    snake.GetSnakeHeadCoordinats().GetY() == food.GetY())
                {
                    food.RandomCoordinate();
                    snake.GrowSnake();
                }
                drawing.Draw();
                Thread.Sleep(50);
                Console.Clear();
            }
        }
    }
}
