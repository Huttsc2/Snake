using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SnakeApp
{
    public class Food : Point
    {
        private int AreaWight;
        private int AreaHight;
        public Food(int x, int y, int areaWidht, int areaHeight) : base(x, y)
        {
            AreaWight = areaWidht;
            AreaHight = areaHeight;
        }

        public void RandomCoordinate()
        {
            Random random = new Random();
            XCoorinate = random.Next(1, AreaWight-2);
            if (XCoorinate%2 == 0)
            {
                XCoorinate++;
                if (XCoorinate > AreaWight-2)
                {
                    XCoorinate-=2;
                }
            }
            YCoordiante = random.Next(2, AreaHight-1);
        }
    }
}
