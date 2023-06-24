using System.Text;

namespace SnakeApp
{
    public class ConsoleInit
    {
        private Area Area { get; set; }

        public ConsoleInit(Area area)
        {
            Area = area;
        }

        public void Initiate()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.SetWindowSize(Area.GetWidth(), Area.GetHeight()+1);
            Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
            Console.CursorVisible = false;
        }
    }
}
