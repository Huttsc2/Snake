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
        private static bool IsGameInit = true;

        public static void Main(string[] args)
        {
            while (IsGameInit)
            {
                Snake snake = new Snake(SnakeHeadCoordinateX, SnakeHeadCoordinateY, StartingSnakeLenght);
                Area area = new Area(Width, Height);
                FreeCellsSearcher searcher = new FreeCellsSearcher(area.GetAreaCells(), snake.GetSnakeCoordinates());
                Food food = new Food(searcher);
                Drawing drawing = new Drawing(area, snake, food);
                ConsoleInit console = new ConsoleInit(area);
                GameInit game = new GameInit(snake, food, drawing, area, searcher, GameSpeed);
                console.Initiate();

                Console.WriteLine("\nPress 1 to start game");
                Console.WriteLine("\nPress 2 to exit game");
                ConsoleKeyInfo startKey = Console.ReadKey();
                if (startKey.KeyChar == '1')
                {
                    game.Start();
                    Console.Clear();
                }
                else if(startKey.KeyChar == '2')
                {
                    IsGameInit = false;
                }
                else
                {
                    Console.Clear();
                }
            }
        }
    }
}
