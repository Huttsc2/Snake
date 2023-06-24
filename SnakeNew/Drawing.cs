using System.Text;

namespace SnakeApp
{
    public class Drawing
    {
        private Area Area { get; set; }
        private Snake Snake { get; set; }    
        private Food Food { get; set; }
        private char[,] Array { get; set; }
        private StringBuilder Buffer { get; set; }

        public Drawing(Area area, Snake snake, Food food)
        {
            Area = area;
            Snake = snake;
            Food = food;
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
            Array = new char[Area.GetHeight(), Area.GetWidth()];
            for (int i = 0; i < Area.GetHeight(); i++)
            {
                for (int j = 0; j < Area.GetWidth(); j++)
                {
                    if (j == 0 || i == 0 || i == Area.GetHeight() - 1)
                    {
                        Array[i, j] = '▒';
                    }
                    else if (j == Area.GetWidth() - 1)
                    {
                        Array[i, j] = '▒';
                    }
                    else if (Snake.GetSnakeHeadCoordinates().GetY() == i 
                        && Snake.GetSnakeHeadCoordinates().GetX() == j)
                    {
                        Array[i, j] = '☻';
                    }
                    else if (Snake.GetSnakeCoordinates().Any(e => e.GetY() == i && e.GetX() == j))
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
            for (int i = 0; i < Area.GetHeight(); i++)
            {
                for (int j = 0; j < Area.GetWidth(); j++)
                {
                    Buffer.Append(Array[i, j]);
                }
            }
        }
    }
}
