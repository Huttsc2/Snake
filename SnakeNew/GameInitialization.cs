namespace SnakeApp
{
    public class GameInitialization
    {
        private static int SnakeHeadCoordinateX {  get; set; }
        private static int SnakeHeadCoordinateY { get; set; }
        private static int FoodX { get; set; }
        private static int FoodY { get; set; }
        private static bool IsEaten { get; set; }
        private static string? Key { get; set; }
        private static int GameSpeed { get; set; }
        Snake Snake;
        Food Food;
        Drawing Drawing;

        public GameInitialization(Snake snake, Food food, Drawing drawing, int speed)
        {
            Snake = snake;
            Food = food;
            Drawing = drawing;
            FoodX = food.GetX();
            FoodY = food.GetY();
            GameSpeed = speed;
            IsEaten = false;
            Key = null;
        }

        public void Start()
        {
            while (true)
            {
                Snake.UpdateSnakeCoordinats(Key);
                SnakeHeadCoordinateX = Snake.GetSnakeHeadCoordinats().GetX();
                SnakeHeadCoordinateY = Snake.GetSnakeHeadCoordinats().GetY();
                if (SnakeHeadCoordinateX == FoodX && SnakeHeadCoordinateY == FoodY)
                {
                    Food.SetRandomCoordinate();
                    Snake.GrowSnake();
                    IsEaten = true;
                }
                if (IsEaten)
                {
                    FoodX = Food.GetX();
                    FoodY = Food.GetY();
                    IsEaten = false;
                }
                Drawing.Draw();
                Thread.Sleep(GameSpeed);
            }
        }
    }
}
