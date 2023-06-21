using System.Text;

namespace SnakeApp
{
    public class ConsoleInitialization
    {
        private int Widht;
        private int Height;
        public ConsoleInitialization(int widht, int height)
        {
            Widht = widht;
            Height = height;
        }

        public void Initiate()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(Widht, Height+1);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;
        }
    }
}
