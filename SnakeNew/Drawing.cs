using System.Text;

namespace SnakeApp
{
    public class Drawing
    {
        private Area Area { get; set; }
        private Snake Snake { get; set; }    
        private Food Food { get; set; }
        private int Height { get; set; }
        private int Width { get; set; }
        private char[,] Array { get; set; }
        private int SnakeHeadCoordinateX { get; set; }
        private int SnakeHeadCoordinateY { get; set; }
        private StringBuilder Buffer { get; set; }

        public Drawing(Area area, Snake snake, Food food)
        {
            Area = area;
            Snake = snake;
            Food = food;
            Height = Area.GetHeight();
            Width = Area.GetWidth();
            Buffer = new StringBuilder();
        }

        public void Draw()
        {
            SetCharArray();
            SetStringBuffer();
            Console.Clear();
            Console.Write(Buffer.ToString());
            Buffer.Clear();
        }

        private void SetCharArray()
        {
            Array = new char[Height, Width];
            SnakeHeadCoordinateX = Snake.GetSnakeHeadCoordinats().GetX();
            SnakeHeadCoordinateY = Snake.GetSnakeHeadCoordinats().GetY(); 
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
                    else if (SnakeHeadCoordinateY == i && SnakeHeadCoordinateX == j)
                    {
                        Array[i, j] = '☻';
                    }
                    else if (Snake.GetSnakeCoordinats().Any(e => e.GetY() == i && e.GetX() == j))
                    {
                        Array[i, j] = '●';
                    }
                    else if (j == Food.GetNewFood().GetX() && i == Food.GetNewFood().GetY())
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

        private void SetStringBuffer()
        {
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Buffer.Append(Array[i, j]);
                }
            }
        }
    }
}
