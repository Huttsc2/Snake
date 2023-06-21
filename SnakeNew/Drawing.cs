using System.Text;

namespace SnakeApp
{
    public class Drawing
    {
        private static Area Area { get; set; }
        private static Snake Snake { get; set; }    
        private static Food Food { get; set; }
        private static int Height { get; set; }
        private static int Width { get; set; }
        private static char[,] Array { get; set; }
        private static StringBuilder Buffer = new StringBuilder();

        public Drawing(Area area, Snake snake, Food food)
        {
            Area = area;
            Snake = snake;
            Food = food;
            Height = Area.GetHeight();
            Width = Area.GetWidth();
        }

        public void SetCharArray()
        {
            Array = new char[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    if (j == 0 || i == 0 || i == Height - 1)
                    {
                        Array[i, j] = '▒';
                    }
                    else if (j == Width - 1)
                    {
                        Array[i, j] = '▒';
                    }
                    else if (Snake.GetSnakeHeadCoordinats().GetY() == i && Snake.GetSnakeHeadCoordinats().GetX() == j)
                    {
                        Array[i, j] = '☻';
                    }
                    else if (Snake.GetSnakeCoordinats().Any(e => e.GetY() == i && e.GetX() == j))
                    {
                        Array[i, j] = '●';
                    }
                    else if (j == Food.GetX() && i == Food.GetY())
                    {
                        Array[i, j] = '*';
                    }
                    else
                    {
                        Array[i, j] = ' ';
                    }
                }
            }
        }

        public void SetStringBuffer()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Buffer.Append(Array[i, j]);
                }
            }
        }

        public void Draw()
        {
            SetCharArray();
            SetStringBuffer();
            Console.Clear();
            Console.Write(Buffer.ToString());
            Buffer.Clear();
        }
    }
}
