namespace SnakeApp
{
    public class MainClass
    {
        private static int StartX = 7;
        private static int StartY = 7;
        private static int Width = 45;
        private static int Height = 22;
        private static string? key = null;
        public static void Main(string[] args)
        {
            Snake snake = new Snake(StartX, StartY);
            Area area = new Area(Width, Height);
            Drawing drawing = new Drawing(area, snake);
            while (true)
            {
                snake.UpdateCoordinats(key);
                drawing.Draw();
                Thread.Sleep(50);
                Console.Clear();
            }
        }
    }
}
