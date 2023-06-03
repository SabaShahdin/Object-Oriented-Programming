using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace self_Assesment_2.BL
{
    public class Point
    {
        public int x;
        public int y;

        public Point()
        {

        }
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public int getX()
        {
            return x;
        }
        public int getY()
        {
            return y;
        }
        public int setX(int x)
        {
            this.x = x;
            return x;
        }
        public int setY(int y)
        {
            this.y = y;
            return y;
        }
        public Point setXY(int x ,int y)
        {
            Point p = new Point();
            p.x = x;
            p.y = y;
            return p;
        }

    }
}
