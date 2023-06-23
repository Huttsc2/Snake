namespace SnakeApp
{
    public class MainClass
    {
        private static int SnakeHeadCoordinateX = 7; //only odd numbers
        private static int SnakeHeadCoordinateY = 8;
        private static int StartingSnakeLenght = 5;
        private static int Width = 43; //only odd numbers
        private static int Height = 22;
        private static int GameSpeed = 100; //console update rate in milliseconds

        public static void Main(string[] args)
        {
            Snake snake = new Snake(SnakeHeadCoordinateX, SnakeHeadCoordinateY, StartingSnakeLenght);
            Area area = new Area(Width, Height);
            Food food = new Food(area, snake);
            Drawing drawing = new Drawing(area, snake, food);
            ConsoleInit console = new ConsoleInit(Width, Height);
            GameInit game = new GameInit(snake, food, drawing, area, GameSpeed);

            console.Initiate();
            game.Start();
        }
    }
}
