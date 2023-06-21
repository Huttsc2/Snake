namespace SnakeApp
{
    public class GameInit
    {
        private static int SnakeHeadCoordinateX {  get; set; }
        private static int SnakeHeadCoordinateY { get; set; }
        private static int FoodX { get; set; }
        private static int FoodY { get; set; }
        private static bool IsEaten { get; set; }
        private static string? Key { get; set; }
        private static int GameSpeed { get; set; }
        private static bool IsAlive { get; set; }
        private static int AreaWidth { get; set; }
        private static int AreaHigth { get; set; }
        Snake Snake;
        Food Food;
        Drawing Drawing;


        public GameInit(Snake snake, Food food, Drawing drawing, Area area, int speed)
        {
            Snake = snake;
            Food = food;
            Drawing = drawing;
            FoodX = food.GetX();
            FoodY = food.GetY();
            GameSpeed = speed;
            IsEaten = false;
            Key = null;
            IsAlive = true;
            AreaWidth = area.GetWidth();
            AreaHigth = area.GetHeight();
        }

        public void Start()
        {
            while (IsAlive)
            {
                Snake.UpdateSnakeCoordinats(Key);
                SnakeHeadCoordinateX = Snake.GetSnakeHeadCoordinats().GetX();
                SnakeHeadCoordinateY = Snake.GetSnakeHeadCoordinats().GetY();
                if (SnakeHeadCoordinateX == -1 || SnakeHeadCoordinateY == 0 
                    || SnakeHeadCoordinateX == AreaWidth || SnakeHeadCoordinateY == AreaHigth-1)
                {
                    IsAlive = false;
                    break;
                }
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
