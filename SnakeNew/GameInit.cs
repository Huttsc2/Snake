using System.Xml.Linq;

namespace SnakeApp
{
    public class GameInit
    {
        private int SnakeHeadCoordinateX {  get; set; }
        private int SnakeHeadCoordinateY { get; set; }
        private int FoodX { get; set; }
        private int FoodY { get; set; }
        private bool IsEaten { get; set; }
        private string? Key { get; set; }
        private int GameSpeed { get; set; }
        private bool IsAlive { get; set; }
        private int AreaWidth { get; set; }
        private int AreaHigth { get; set; }
        private List<Point> SnakeBodyCoordinates { get; set; }
        Snake Snake { get; set; }
        Food Food { get; set; }
        Drawing Drawing { get; set; }

        public GameInit(Snake snake, Food food, Drawing drawing, Area area, int speed)
        {
            Snake = snake;
            Food = food;
            Drawing = drawing;
            GameSpeed = speed;
            IsEaten = false;
            Key = null;
            IsAlive = true;
            AreaWidth = area.GetWidth();
            AreaHigth = area.GetHeight();
            Food.SetNewFood();
            FoodX = Food.GetNewFood().GetX();
            FoodY = Food.GetNewFood().GetY();
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

        private void UpdateCoordinates()
        {
            Snake.UpdateSnakeCoordinats(Key);
            SnakeHeadCoordinateX = Snake.GetSnakeHeadCoordinats().GetX();
            SnakeHeadCoordinateY = Snake.GetSnakeHeadCoordinats().GetY();
            SnakeBodyCoordinates = Snake.GetSnakeBodyCoordinats();
        }

        private void CheckHeadTouchWall()
        {
            if (SnakeHeadCoordinateX == -1 || SnakeHeadCoordinateY == 0
                    || SnakeHeadCoordinateX == AreaWidth || SnakeHeadCoordinateY == AreaHigth - 1)
            {
                IsAlive = false;
            }
        }

        private void CheckHeadTouchBody()
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
                Food.SetNewFood();
                Snake.GrowSnake();
                IsEaten = true;
            }
        }

        private void SetNewFood()
        {
            if (IsEaten)
            {
                FoodX = Food.GetNewFood().GetX();
                FoodY = Food.GetNewFood().GetY();
                IsEaten = false;
            }
        }
    }
}
