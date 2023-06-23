using System.Text;

namespace SnakeApp
{
    public class ConsoleInit
    {
        private int Widht { get; set; }
        private int Height { get; set; }
        public ConsoleInit(int widht, int height)
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
