using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Line
{
    public class MyPoint
    {
        public int x;
        public int y;

        public MyPoint()
        {

        }
        public MyPoint(int x, int y)
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
        public void SetX(int inputX)
        {
            x = inputX;
        }
        public void SetY(int inputY)
        {
            y = inputY;
        }
        public void SetXY(int inputX, int inputY)
        {
            x = inputX;
            y = inputY;

        }
        public double distanceWitHCords(int inputX, int inputY)
        {
            double d = Math.Sqrt(Math.Pow((inputX - x), 2) - Math.Pow((inputY - y), 2));
            return d;
        }
        public double distanceWitHObject(MyPoint point)
        {
            double d = Math.Sqrt(Math.Pow((point.x - x), 2) - Math.Pow((point.y - y), 2));
            return d;
        }
        public double distanceWithOrigin(MyPoint point)
        {
            double d = Math.Sqrt(Math.Pow(point.x - x, 2) - Math.Pow((point.y - y), 2));
            return d;
        }
    }
}
