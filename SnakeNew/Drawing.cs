using System.Text;

namespace SnakeApp
{
    public class Drawing
    {
        private Area Area;
        private Snake Snake;
        private Food Food;
        private int Height;
        private int Width;

        public Drawing(Area area, Snake snake, Food food)
        {
            Area = area;
            Snake = snake;
            Food = food;
            Height = Area.GetHeight();
            Width = Area.GetWidth();
        }

        public void DrawByConsoleWrite()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (j == 0 || i == 0 || i == Height - 1)
                    {
                        Console.Write("▒");
                    }
                    
                    else if (j == Width - 1)
                    {
                        Console.Write("▒\n");
                    }
                    else if (Snake.GetSnakeCoordinats().Any(e => e.GetY() == i && e.GetX() == j))
                    {

                        Console.Write("☻");
                    }
                    else if (j == Food.GetX() && i == Food.GetY())
                    {
                        Console.Write("*");
                    }
                    else
                    {
                        Console.Write(' ');
                    }
                }
            }
        }

        public void DrawByStringBuilder()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                sb.Clear();
                for (int j = 0; j < Width; j++)
                {   
                    if (j == 0 || i == 0 || i == Height - 1)
                    {
                        sb.Append('▒');
                    }
                    else if (j == Width - 1)
                    {
                        sb.Append('▒');
                        sb.Append('\n');
                    }
                    else if (Snake.GetSnakeCoordinats().Any(e => e.GetY() == i && e.GetX() == j)) 
                    {
                        sb.Append('☻');
                    }
                    else if (j == Food.GetX() && i == Food.GetY())
                    {
                        sb.Append('*');
                    }
                    else
                    {
                        sb.Append(' ');
                    }
                }
                Console.SetCursorPosition(0, i);
                Console.WriteLine(sb.ToString());
            }
        }

        public void DrawByCharArray()
        {
            char[,] buffer = new char[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (j == 0 || i == 0 || i == Height - 1)
                    {
                        buffer[i, j] = '▒';
                    }
                    else if (j == Width - 1)
                    {
                        buffer[i, j] = '▒';
                    }
                    else if (Snake.GetSnakeCoordinats().Any(e => e.GetY() == i && e.GetX() == j))
                    {
                        buffer[i, j] = '☻';
                    }
                    else if (j == Food.GetX() && i == Food.GetY())
                    {
                        buffer[i, j] = '*';
                    }
                    else
                    {
                        buffer[i, j] = ' ';
                    }
                }
            }
            Console.CursorVisible = false;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append(buffer[i, j]);
                }
                Console.SetCursorPosition(0, i);
                Console.WriteLine(sb.ToString());
                sb.Clear();
            }
        }
    }
}
