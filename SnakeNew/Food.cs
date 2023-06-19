using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    public class Food : Point
    {
        protected bool isEaten = false;
        public Food(int x, int y) : base(x, y)
        {
        }

        public void RandomCoordinate()
        {
            Random random = new Random();
            XCoorinate = random.Next(1, 44);
            if (XCoorinate%2 != 0)
            {
                XCoorinate++;
            }
            YCoordiante = random.Next(1, 21);
        }
    }
}
