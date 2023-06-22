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
        private static List<Point> SnakeBodyCoordinates { get; set; }
        Snake Snake { get; set; }
        Food Food { get; set; }
        Drawing Drawing { get; set; }


        public GameInit(Snake snake, Food food, Drawing drawing, Area area, int speed)
        {
            Snake = snake;
            Food = food;
            Drawing = drawing;
            FoodX = food.GetX();
            FoodY = food.GetY();
            GameSpeed = speed;
            IsEaten = true;
            SetNewFood();
            Key = null;
            IsAlive = true;
            AreaWidth = area.GetWidth();
            AreaHigth = area.GetHeight();
        }

        public void Start()
        {
            while (IsAlive)
            {
                UpdateCoordinates();
                CheckHeadTouchWall();
                CheckHeadTouchBody();
                if (!IsAlive) break;
                CheckFoodIsEaten();
                SetNewFood();
                Drawing.Draw();
                Thread.Sleep(GameSpeed);
            }
        }

        public void UpdateCoordinates()
        {
            Snake.UpdateSnakeCoordinats(Key);
            SnakeHeadCoordinateX = Snake.GetSnakeHeadCoordinats().GetX();
            SnakeHeadCoordinateY = Snake.GetSnakeHeadCoordinats().GetY();
            SnakeBodyCoordinates = Snake.GetSnakeBodyCoordinats();
        }

        public void CheckHeadTouchWall()
        {
            if (SnakeHeadCoordinateX == -1 || SnakeHeadCoordinateY == 0
                    || SnakeHeadCoordinateX == AreaWidth || SnakeHeadCoordinateY == AreaHigth - 1)
            {
                IsAlive = false;
            }
        }

        public void CheckHeadTouchBody()
        {
            if (SnakeBodyCoordinates.Any(s => s.GetX() == SnakeHeadCoordinateX && s.GetY() == SnakeHeadCoordinateY))
            {
                IsAlive = false;
            }
        }

        private void CheckFoodIsEaten()
        {
            if (SnakeHeadCoordinateX == FoodX && SnakeHeadCoordinateY == FoodY)
            {
                Food.SetRandomCoordinate();
                Snake.GrowSnake();
                IsEaten = true;
            }
        }

        private void SetNewFood()
        {
            if (IsEaten)
            {
                FoodX = Food.GetX();
                FoodY = Food.GetY();
                IsEaten = false;
            }
        }
    }
}
